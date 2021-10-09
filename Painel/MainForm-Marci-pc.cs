// ============== Automatização do difratômetro de raios-x ==============
// ============== Guilherme Parreira Gomes - Eng. Mecânica ==============
// ===================== guigoparreira10@gmail.com ======================
// ================ Centro Universitário FEI - 2020/2021 ================


//Bibliotecas

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Reflection;
//using System.Diagnostics;
using System.Globalization;


//Biblioteca Accord - Utilizada para obter dados e manipular câmera.
//using Accord;
using Accord.Video;
using Accord.Video.DirectShow;

namespace autoDif
{
    public partial class MainForm : Form
    {
        //Accord
        FilterInfoCollection videoDevices; // Lista de dispositivos/câmeras
        VideoCaptureDevice videoDevice; // Câmera de alinhamento
        VideoCaptureDevice videoDeviceAux; // Câmera auxiliar

        VideoCapabilities[] videoCapabilities;
        VideoCapabilities[] videoCapabilitiesAux;

        // ============================================================================================================
        // ========================================= Configurações ====================================================

        // == Crosshair / Mira ==
        int crosshairLineWidth = 2; //Espessura da linha (px)
        Color crosshairColor = Color.Red;
        int crosshairSize = 35; //  (px)

        double maxAcceptablePosError = 0.3;

        // === Régua ===
        bool enableRuler = false;
        bool rulerMode = false; //False - Horizontal ; True - Vertical
        Point rulerP1, rulerP2; //Pontos de medição

        //== Medição de distancia ==

        Color crosshairColor2 = Color.Blue;

        int trackingSampleSize = 50;

        double trackingStep = 10; // (mm)

        double minTrackingScore = 0.9; //Pontuação mínima de comparação de imagem para validar a medição
        double minBrightnessDiff = 0.4; //Diferença de brilho mínima para validar amostra (Pouca variação indica ausência de detalhes)
        double maxDistDif = 15; //Diferença máxima aceitável entre as duas medições (mm)

        int horSearchRange = 200; //Largura da janela de procura da amostra (px)
        int verSearchRange = 6;// Altura da janela de procura da amostra (px)

        int imageSamples = 20; //Quantidade de fotos utilizadas para gerar cada amostra (média)

        int stDevPixel = 1; //Desvio padrao - Medição de descolamento (Px)



        //Arquivos

        static string filePath = Application.StartupPath;

        static string configFileName = "config.txt";

        static string configFilePath;

        Stream configFile;


        //========================================= Váriaveis  ===================================================


        bool DEBUG_MODE = false;

        Bitmap trackingSample;
        Bitmap matchingSample;


        bool distMeasurementMode = false;
        int distMeasurementModeState = 0; // 0 - Selecionar ponto ; 1 - Calibração ; 2 - Mover ; 3 - Segunda medição ; 4 - Retornar
        
        Point initialTrackingPoint = new Point(1920 / 2, 1080 / 2);
        dPoint finalTrackingPoint = new dPoint(0, 0);

        double distEstm1 = 0; // Estimativa inicial da distância - Usada para definir passo adicional para garantir desvio padrao baixo
        double distEstm = 0; 

        double bestTrackingScore = 0;

        static SerialPort serialPort1;


        // == Lista de comandos ==
        //A lista de comandos é utilizada para executar dois ou mais comandos em sequência

        string[] cmdList; //Lista de comandos a serem executados
        bool[] cmdListExpResult; // Resultado esperado por cada comando - true indica que lista de comandos será abortada se o comando falhar. False indica que a lista seguirá em caso de falha
        bool isCmdListRunning = false; //Indica se a lista está em execução
        int cmdListIndex = 0; //Posição de execução na lista

        void manageCmdList()
        {
            sendCmd(cmdList[cmdListIndex]);
            if(cmdListIndex == cmdList.Length-1)
            {
                isCmdListRunning = false;
            }
        }


        //Carrega configurações - config.txt
        void loadConfig()
        {
            try
            {
                string[] config = File.ReadAllLines(Path.Combine(filePath, configFileName));

                //Orgem de leitura dever ser igual a ordem de salvamento

                Machine.cameraHalfAng = Convert.ToDouble(config[0]);
                Machine.lensToSensorOffset = Convert.ToDouble(config[1]);
                Machine.cameraToXRayVerOffset = Convert.ToDouble(config[2]);
                Machine.cameraToXRayHorOffset = Convert.ToDouble(config[3]);
                Machine.directPosMinDistSmall = Convert.ToDouble(config[4]);
                Machine.directPosMinDistHeavy = Convert.ToDouble(config[5]);
            }
            catch
            {
                saveConfig();
                return;
            }


        }

        //Salva configurações - config.txt
        public static void saveConfig()
        {
            string[] config = { Machine.cameraHalfAng.ToString(), Machine.lensToSensorOffset.ToString(), Machine.cameraToXRayVerOffset.ToString(),
                Machine.cameraToXRayHorOffset.ToString(), Machine.directPosMinDistSmall.ToString(),  Machine.directPosMinDistHeavy.ToString()};

            File.WriteAllLines(Path.Combine(filePath, configFileName), config);
        }


        //Calcula distancia entre coordenadas
        double dist(int x1, int y1, int x2, int y2)
        {
            double c1 = Math.Pow(x2 - x1, 2);
            double c2 = Math.Pow(y2 - y1, 2);
            return (Math.Sqrt(c1 + c2));
        }

        static int boolToInt(bool b)
        {
            if (b) return 1;
            else return 0;
        }
        static bool intToBool(int i)
        {
            if (i == 1) return true;
            else return false;
        }


        //Desvio padrao da leitura de distancia (mm) - (Válido até 470 mm)
        double getStDev(double rDist)
        {
            if (rDist <= 300) return 2 * stDevPixel;
            if (rDist <= 370) return 3 * stDevPixel;
            if (rDist <= 400) return 4 * stDevPixel;
            return 5 * stDevPixel; //Até 470 mm
        }

        //Passo adicional
        double bonusTrackStep(double rawDist)
        {
            if (rawDist <= 170) return 0; //10
            if (rawDist <= 210) return 5; //15
            if (rawDist <= 240) return 10; //20
            if (rawDist <= 270) return 15; //25
            return 20; //30
        }

        //Clicar no video
        private void videoSourcePlayer_Click(object sender, EventArgs e)
        {
            System.Drawing.Point p = videoSourcePlayerAlign.PointToClient(Cursor.Position);

            if(enableRuler)
            {
                //Vertical
                if(rulerMode)
                {
                    if (p.X < Machine.cameraWidth / 2) rulerP1.X = p.X;
                    else rulerP2.X = p.X;
                }
                //Horizontal
                else
                {
                    if (p.Y < Machine.cameraHeight / 2) rulerP1.Y = p.Y;
                    else rulerP2.Y = p.Y;
                }
                return;
            }
            
            if(distMeasurementMode && distMeasurementModeState == 0)
            {
                initialTrackingPoint.X = p.X;
                initialTrackingPoint.Y = p.Y;
            }
        }


        //Clique duplo no video
        private void videoSourcePlayerAlign_DoubleClick(object sender, EventArgs e)
        {
            if (distMeasurementMode) return;
            if (Machine.sampleInPos) return;
            if (Machine.manualPosMode) return;
            if (enableRuler) return;


            System.Drawing.Point p = videoSourcePlayerAlign.PointToClient(Cursor.Position);
            
            if(Machine.isSampleDistSet)
            {

                double x = (p.X - videoSourcePlayerAlign.Width / 2) * Machine.mmPerPixel();
                double y = (p.Y - videoSourcePlayerAlign.Height / 2) * Machine.mmPerPixel();


                sendStepCmd(x, 0, y);
            }
            else
            {
                MessageBox.Show("Distance is unknown.");
            }
        }


        struct dPoint
        {
            public double X, Y;
            public dPoint(double _x, double _y)
            {
                X = _x;
                Y = _y;
            }

        };



        Bitmap frame;

        async Task searchProcedure(int rangeHor, int rangeVer, double rStep) //Range = distancia maxima de procura (px)
        {
            Rectangle rect;
            Bitmap obs = new Bitmap(1,1);
            //frame = videoSourcePlayerAlign.GetCurrentVideoFrame();

            double bestScore = 0;
            int bestScoreDist = 0;
            int bestScoreLine = 0;
            int searchGap = 15;

            double[,] vals = new double[rangeVer, rangeHor];
            string[] strVals = new string[rangeHor];

            await getSecAvgImg(verSearchRange);


            try
            {
                for (int line = 0; line < rangeVer; line++)
                {
                    for (int i = 0; i < rangeHor; i++)
                    {
                        rect = new Rectangle(x: i, y: line, width: trackingSampleSize, height: trackingSampleSize);

                        obs = frame.Clone(rect, frame.PixelFormat);

                        double v = compareBitmaps(obs, trackingSample);

                        vals[line, i] = v;

                        if (v > bestScore)
                        {
                            bestScore = v;
                            bestScoreDist = i;
                            bestScoreLine = line;
                            matchingSample = obs;
                        }

                        if (line > 0)
                        {
                            if (i < bestScoreDist - searchGap) i = bestScoreDist - searchGap;
                            if (i > bestScoreDist + searchGap) break;
                        }
                    }
                }

                for (int i = 0; i < rangeHor; i++)
                {
                    strVals[i] = i + " " + vals[0, i];
                }
                //File.WriteAllLines(Path.Combine(filePath, "trackingScore.txt"), strVals);
                


                    //Interpolação - Corrige os 3 melhores frames - aproxima por eq. de segundo grau e obtem ponto máximo

                    int x1 = bestScoreDist - 1, x2 = bestScoreDist, x3 = bestScoreDist + 1;
                double y1 = vals[bestScoreLine, x1], y2 = vals[bestScoreLine, x2], y3 = vals[bestScoreLine, x3];



                double a = (x1 * (y3 - y2) + x2 * (y1 - y3) + x3 * (y2 - y1)) / ((x1 - x2) * (x1 - x3) * (x2 - x3));
                double b = (y2 - y1) / (x2 - x1) - a * (x1 + x2);

                double bestScoreDistInterp = Math.Round(-b / (2 * a), 1);


                bestTrackingScore = bestScore;

                finalTrackingPoint.X = initialTrackingPoint.X + bestScoreDistInterp;
                finalTrackingPoint.Y = initialTrackingPoint.Y;

                distEstm = getSampleDistance(rStep);
            }
            catch
            {

            }
        }

       async Task getAvgImg()
        { 
            Rectangle rect = new Rectangle(x: initialTrackingPoint.X - trackingSampleSize / 2,
                       y: initialTrackingPoint.Y - trackingSampleSize / 2, width: trackingSampleSize, height: trackingSampleSize);
            
            
            Bitmap[] bmps = new Bitmap[imageSamples];
            Bitmap avg;
            
            
                for (int i = 0; i < imageSamples; i++)
                {
                    Bitmap b = videoSourcePlayerAlign.GetCurrentVideoFrame();
                    bmps[i] = b.Clone(rect, b.PixelFormat);
                    await Task.Delay(35);
            }

                avg = bmps[0];
                for (int i = 0; i < bmps[0].Width; i++)
                {
                    for (int j = 0; j < bmps[0].Height; j++)
                    {

                        double r = 0, g = 0, b = 0;
                        for (int k = 0; k < imageSamples; k++)
                        {
                            r += bmps[k].GetPixel(i, j).R;
                            g += bmps[k].GetPixel(i, j).G;
                            b += bmps[k].GetPixel(i, j).B;

                        
                        }
                        r /= imageSamples;
                        g /= imageSamples;
                        b /= imageSamples;

                        avg.SetPixel(i, j, Color.FromArgb((int)Math.Round(r), (int)Math.Round(g), (int)Math.Round(b)));
                    }
                }

            trackingSample = avg;
        }

        async Task getSecAvgImg(int rangeVer) //rangeVer precisa ser PAR
        {
            Rectangle rect = new Rectangle(x: initialTrackingPoint.X - trackingSampleSize / 2,
                       y: initialTrackingPoint.Y - trackingSampleSize / 2 - rangeVer/2, width: trackingSampleSize + 200, height: trackingSampleSize + rangeVer);

            Bitmap[] bmps = new Bitmap[imageSamples];
            Bitmap avg;


            for (int i = 0; i < imageSamples; i++)
            {
                Bitmap b = videoSourcePlayerAlign.GetCurrentVideoFrame();
                bmps[i] = b.Clone(rect, b.PixelFormat);
                await Task.Delay(35);

            }

            avg = bmps[0];
            for (int i = 0; i < bmps[0].Width; i++)
            {
                for (int j = 0; j < bmps[0].Height; j++)
                {

                    double r = 0, g = 0, b = 0;
                    for (int k = 0; k < imageSamples; k++)
                    {
                        r += bmps[k].GetPixel(i, j).R;
                        g += bmps[k].GetPixel(i, j).G;
                        b += bmps[k].GetPixel(i, j).B;


                    }
                    r /= imageSamples;
                    g /= imageSamples;
                    b /= imageSamples;

                    avg.SetPixel(i, j, Color.FromArgb((int)Math.Round(r), (int)Math.Round(g), (int)Math.Round(b)));
                }
            }

            frame = avg;
        }


        double totalTraveled = 0;
        async void manageDistMeasurement()
        {
            if (!distMeasurementMode) return;

            switch(distMeasurementModeState)
            {
                //Config / Espera pela confirmação
                case 0:

                    break;

                //Obtem imagem base / Primeiro movimento
                case 1:
                    await getAvgImg();
                    //trackingSample.Save(Path.Combine(filePath, "trackSample.png"));
                    
                    if (!validateTrackingSample())
                    {
                        distMeasurementMode = false;
                        MessageBox.Show("The tracking reference lacks details.");
                        updateDisplayInfo();
                        break;
                    }

                    sendStepCmd(-trackingStep, 0, 0);

                    distMeasurementModeState++;
                    break;

                //Segunda leitura / Segundo passo
                case 2:
                    await Task.Delay(800); //Aguarda estabilização da imagem
                    await searchProcedure(horSearchRange, verSearchRange, trackingStep);

                    //MessageBox.Show(distEstm + " " + bonusTrackStep(distEstm));
                    totalTraveled = trackingStep + bonusTrackStep(distEstm);
                    distEstm1 = distEstm;
                    if (bonusTrackStep(distEstm) == 0)
                    {
                        distMeasurementModeState = 4;
                        manageDistMeasurement();
                        break;
                    }
                    distMeasurementModeState++;
                    sendStepCmd(-bonusTrackStep(distEstm), 0, 0);
                    
                    break;

                //Terceira leitura
                case 3:
                    await Task.Delay(800); //Aguarda estabilização da imagem
                    await searchProcedure (horSearchRange, verSearchRange, totalTraveled);
                    distMeasurementModeState++;
                    manageDistMeasurement();
                    
                    break;

                    //Retorno
                case 4:
                    await Task.Delay(300);

                    sendStepCmd(totalTraveled, 0, 0);
                    distMeasurementMode = false;

                    if(bestTrackingScore >= minTrackingScore && Math.Abs(distEstm1 - distEstm) <= maxDistDif)
                    {
                        Machine.rawSampleDist = distEstm;
                        Machine.distStDev = getStDev(distEstm);
                        Machine.isSampleDistSet = true;

                        numTargetDist.Value = (decimal)Machine.sampleDist();

                        //matchingSample.Save(Path.Combine(filePath, "matchingSample.png"));

                        //frame.Save(Path.Combine(filePath, "trackingArea.png"));
                    }
                    else
                    {
                        Machine.isSampleDistSet = false;
                        MessageBox.Show("Failed to track the sample. Please select a different tracking area.");
                    }

                    break; 
            }
        }

        bool validateTrackingSample()
        {
            double maxBr = 0;
            double minBr = 1;

            for (int i = 0; i < trackingSample.Width; i++)
            {
                for (int j = 0; j < trackingSample.Height; j++)
                {
                    double b = trackingSample.GetPixel(i, j).GetBrightness();
                    if (b > maxBr) maxBr = b;
                    if (b < minBr) minBr = b;
                }
            }

            return (maxBr - minBr) >= minBrightnessDiff;
        }

        double compareBitmaps(Bitmap b1, Bitmap b2)
        {
            if (b1.Width != b2.Width || b1.Height != b2.Height) return 0;
            int total = b1.Width * b1.Height * 3;
            double sum = 0.0;
            Color c1, c2;
            int p = 5;

            for(int i = 0; i < b1.Width; i++)
            {
                for (int j = 0; j < b1.Height; j++)
                {
                    c1 = b1.GetPixel(i, j);
                    c2 = b2.GetPixel(i, j);

                    sum += 1.0 - Math.Abs(c1.R - c2.R)/ 255.0; 
                    sum += 1.0 - Math.Abs(c1.G - c2.G) / 255.0;
                    sum += 1.0 - Math.Abs(c1.B - c2.B) / 255.0;
                }
            }
            
            return sum / total;
        }

        double getSampleDistance(double rDist)
        {
            double pixelDist = Math.Abs(initialTrackingPoint.X - finalTrackingPoint.X);
            double mmPerPixel = rDist / (double)pixelDist;

            return 0.5 * videoSourcePlayerAlign.Width * mmPerPixel / Math.Tan(Machine.cameraHalfAng / 180 * Math.PI);
            //MessageBox.Show(mmPerPixel+"");
        }

       

        //Botao definir distância (btnSetDist)
        private void button7_Click(object sender, EventArgs e)
        {
            if (!Machine.machineReady) return;
            if (!serialPort1.IsOpen) return;
            if (!videoSourcePlayerAlign.IsRunning) return;

            if (!distMeasurementMode)
            {
                distMeasurementMode = true;
                distMeasurementModeState = 0;
                updateDisplayInfo();
                return;
            }

            //Confirmar
            if (distMeasurementModeState == 0)
            {
                cbAutoExp.Checked = false;
                cbAutoFocus.Checked = false;

                distMeasurementModeState++;
                manageDistMeasurement();
            }

            updateDisplayInfo();
        }


        public MainForm( )
        {
            InitializeComponent();
        }


        //Obtem informações de dispitivios disponíveis
        void getCameraInfo()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            int defaultCameraIndex = 0;

            devicesCombo.Items.Clear();
            devicesComboAux.Items.Clear();

            if (videoDevices.Count != 0)
            {
                foreach (FilterInfo device in videoDevices)
                {
                    devicesCombo.Items.Add(device.Name);
                    devicesComboAux.Items.Add(device.Name);
                }
            }
            else
            {
                devicesCombo.Items.Add("No cameras detected!");
                devicesComboAux.Items.Add("No cameras detected!");
            }

            devicesCombo.SelectedIndex = defaultCameraIndex;
            devicesComboAux.SelectedIndex = defaultCameraIndex;

        }



        private void MainForm_Load( object sender, EventArgs e )
        {
            getCameraInfo();
            
            serialPort1 = new SerialPort();

            serialPort1.BaudRate = 115200;
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);

            updateCOMList();

            videoDevice = new VideoCaptureDevice();
            videoDeviceAux = new VideoCaptureDevice();

            

            KeyPreview = true; //Habilita input do teclado
            cbSampleSupport.SelectedIndex = 0;

/*#if DEBUG
            filePath = "C:\\Users\\guigo\\Desktop";
#endif*/

            loadConfig();


            updateDisplayInfo();
        }

        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(serialPort1.IsOpen) serialPort1.Close();
            disconnectCamera();
            disconnectAuxCamera();

            //Environment.Exit(0);
        }

        //Converte coordenadas do painel (local) em coordenadas da imagem da camera (Usado para desenhar informações adicionais)
        System.Drawing.Point getImgCoord(int x, int y)
        {
            int nx = x + (videoSourcePlayerAlign.Width - panelCameraAlign.Width) / 2;
            int ny = y + (videoSourcePlayerAlign.Height - panelCameraAlign.Height) / 2;

            return new System.Drawing.Point(nx, ny);
        }

        //Converte coordenadas do painel (local) em coordenadas da imagem da camera (Usado para desenhar informações adicionais)
        System.Drawing.Point getImgCoordAux(int x, int y)
        {
            int nx = x + (videoSourcePlayerAux.Width - panelCameraAux.Width) / 2;
            int ny = y + (videoSourcePlayerAux.Height - panelCameraAux.Height) / 2;

            return new System.Drawing.Point(nx, ny);
        }



        Pen penRedLine = new Pen(Color.Red, 1);
        Pen penCrosshair;

        Pen penIntProj = new Pen(Color.Red, 4);
        Pen penOutProj = new Pen(Color.Red, 3);

        Pen penGreenDot = new Pen(Color.Green, 2);

      

        //Texto Distância
        Brush b = new SolidBrush(Color.Red);
        Brush b2 = new SolidBrush(Color.Blue);
        Brush b3 = new SolidBrush(Color.Red);
        Brush brushOffsetGood = new SolidBrush(Color.LawnGreen);
        Brush brushOffsetOff = new SolidBrush(Color.Red);

        Font distFont;
        Font sampInPosFont;
        Font distMModeFont;
        Font offsetGoodFont;
        Font offsetOffFont;
        Font limitSwitchFont;

        StringFormat sf = new StringFormat();


        Stream stream;
        Bitmap cartDir;

        //Desenha sobre o painel do video
        private void videoSourcePlayer_Paint(object sender, PaintEventArgs e)
        {
            distFont = new Font(Font.FontFamily, 16, FontStyle.Regular);
            sampInPosFont = new Font(Font.FontFamily, 30, FontStyle.Regular);
            distMModeFont = new Font("Arial", 20, FontStyle.Regular);

            offsetGoodFont = new Font(Font.FontFamily, 25, FontStyle.Regular);
            offsetOffFont = new Font(Font.FontFamily, 25, FontStyle.Regular);

            limitSwitchFont = new Font(Font.FontFamily, 16, FontStyle.Regular);

            //Direções
            if (cartDir == null)
            {
                stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("autoDif.dir.png");
                cartDir = new Bitmap(stream);
            }
            int dirVecSize = 100;
            e.Graphics.DrawImage(cartDir, getImgCoord(panelCameraAlign.Width, panelCameraAlign.Height).X - (dirVecSize+5), getImgCoord(panelCameraAlign.Width, panelCameraAlign.Height).Y - (dirVecSize+5), dirVecSize, dirVecSize);

            //Crosshair / Mira
            if (!Machine.sampleInPos && !Machine.manualPosMode)
            {
                penCrosshair = new Pen(crosshairColor, crosshairLineWidth);

                e.Graphics.DrawLine(penCrosshair, videoSourcePlayerAlign.Width / 2 - crosshairSize / 2, videoSourcePlayerAlign.Height / 2, videoSourcePlayerAlign.Width / 2 + crosshairSize / 2, videoSourcePlayerAlign.Height / 2);
                e.Graphics.DrawLine(penCrosshair, videoSourcePlayerAlign.Width / 2, videoSourcePlayerAlign.Height / 2 - crosshairSize / 2, videoSourcePlayerAlign.Width / 2, videoSourcePlayerAlign.Height / 2 + crosshairSize / 2);
            }

            if(distMeasurementMode)
            {
                penCrosshair = new Pen(crosshairColor2, crosshairLineWidth);


                e.Graphics.DrawRectangle(penCrosshair, initialTrackingPoint.X - trackingSampleSize / 2,
                      initialTrackingPoint.Y - trackingSampleSize / 2, trackingSampleSize, trackingSampleSize);

                if (distMeasurementModeState == 0)
                {
                    sf.Alignment = StringAlignment.Center;
                    e.Graphics.DrawString("SELECT TRACKING AREA", distMModeFont, b2, getImgCoord(panelCameraAlign.Width / 2, 50), sf);
                    trackingSampleSize = (int)numProbeSize.Value;
                }
                else
                {
                    sf.Alignment = StringAlignment.Center;
                    e.Graphics.DrawString("MEASUREMENT IN PROGRESS", distMModeFont, b2, getImgCoord(panelCameraAlign.Width / 2, 50), sf);
                }

                if (distMeasurementModeState > 2)
                {
                    e.Graphics.DrawLine(penCrosshair, (int)finalTrackingPoint.X - crosshairSize / 2, (int)finalTrackingPoint.Y, (int)finalTrackingPoint.X + crosshairSize / 2, (int)finalTrackingPoint.Y);
                    e.Graphics.DrawLine(penCrosshair, (int)finalTrackingPoint.X, (int)finalTrackingPoint.Y - crosshairSize / 2, (int)finalTrackingPoint.X, (int)finalTrackingPoint.Y + crosshairSize / 2);
                }
            }


            String distTxt;
            if (!Machine.isSampleDistSet) distTxt = "Unknown";
            else distTxt = String.Format("{0:00}", Machine.sampleDist()) + " ±" + Machine.distStDev + " mm";

            e.Graphics.DrawString("Distance: " + distTxt, distFont, b3, getImgCoord(300, panelCameraAlign.Height - 25));

            //Texto - Sem Conexão
            if(!serialPort1.IsOpen)
            {
                e.Graphics.DrawString("MACHINE DISCONNECTED", distFont, b, getImgCoord(10, 15));
            }


            if (Machine.isSampleDistSet && !Machine.sampleInPos && !distMeasurementMode && !Machine.manualPosMode && !enableRuler)
            {
                //Projeção Raio-X


                double projHPx = (Machine.projHeigth() * (videoSourcePlayerAlign.Width) / (2 * (Machine.rawSampleDist) * (Math.Tan(Machine.cameraHalfAng * (Math.PI / 180)))));

                double outProjWPx = (Machine.projUWidth() * (videoSourcePlayerAlign.Width) / (2 * (Machine.rawSampleDist) * (Math.Tan(Machine.cameraHalfAng * (Math.PI / 180)))));

                double inProjWPx = (Machine.projTWidth() * (videoSourcePlayerAlign.Width) / (2 * (Machine.rawSampleDist) * (Math.Tan(Machine.cameraHalfAng * (Math.PI / 180)))));


                Rectangle inProj = new Rectangle((int)(videoSourcePlayerAlign.Width / 2 - Machine.projUWidth() / 2), (int)(videoSourcePlayerAlign.Height / 2 - Machine.projHeigth() / 2), (int)Machine.projUWidth(), (int)Machine.projHeigth());
                Rectangle outProj = new Rectangle((int)(videoSourcePlayerAlign.Width / 2 - Machine.projTWidth() / 2), (int)(videoSourcePlayerAlign.Height / 2 - Machine.projHeigth() / 2), (int)Machine.projTWidth(), (int)Machine.projHeigth());

                e.Graphics.DrawRectangle(penOutProj, outProj);
                e.Graphics.DrawRectangle(penIntProj, inProj);
            }

            if (Machine.sampleInPos)
            {
                sf.Alignment = StringAlignment.Center;

                //TextFormatFlags f = TextFormatFlags.HorizontalCenter;
                e.Graphics.DrawString("SAMPLE IN POSITION", sampInPosFont, b2, getImgCoord(panelCameraAlign.Width / 2, 100), sf);
            }


            if (Machine.manualPosMode)
            {
                //Offset
                sf.Alignment = StringAlignment.Center;
                e.Graphics.DrawString("MANUAL POSITIONING", sampInPosFont, b2, getImgCoord(panelCameraAlign.Width / 2, 50), sf);


                sf.Alignment = StringAlignment.Near;
                string offset = "OFFSET: \nX: " + String.Format("{0:00}", Machine.targetOffset().x) + 
                    "\nY: " + String.Format("{0:00}", Machine.targetOffset().y) +
                    "\nZ: " + String.Format("{0:00}", Machine.targetOffset().z);
                Brush bOffsetX, bOffsetY, bOffsetZ;

                bOffsetX = (Math.Abs(Machine.targetOffset().x) <= maxAcceptablePosError) ? brushOffsetGood : brushOffsetOff;
                bOffsetY = (Math.Abs(Machine.targetOffset().y) <= maxAcceptablePosError) ? brushOffsetGood : brushOffsetOff;
                bOffsetZ = (Math.Abs(Machine.targetOffset().z) <= maxAcceptablePosError) ? brushOffsetGood : brushOffsetOff;

                e.Graphics.DrawString("OFFSET:", offsetOffFont, brushOffsetOff, getImgCoord(10, panelCameraAlign.Height / 2), sf);
                e.Graphics.DrawString("X: " + String.Format("{0:0.0}", Machine.targetOffset().x) + " mm", offsetOffFont, bOffsetX, getImgCoord(10, panelCameraAlign.Height / 2+30), sf);
                e.Graphics.DrawString("Y: " + String.Format("{0:0.0}", Machine.targetOffset().y) + " mm", offsetOffFont, bOffsetY, getImgCoord(10, panelCameraAlign.Height / 2+60), sf);
                e.Graphics.DrawString("Z: " + String.Format("{0:0.0}", Machine.targetOffset().z) + " mm", offsetOffFont, bOffsetZ, getImgCoord(10, panelCameraAlign.Height / 2+90), sf);
            }

            //Limit Switch
            string lmString = "";
            if (Machine.limitSwitchX == -1) lmString += "LIM X-   ";
            if (Machine.limitSwitchX == 1) lmString += "LIM X+    ";

            if (Machine.limitSwitchY == -1) lmString += "LIM Y-   ";
            if (Machine.limitSwitchY == 1) lmString += "LIM Y+    ";

            if (Machine.limitSwitchZ == -1) lmString += "LIM Z-   ";
            if (Machine.limitSwitchZ == 1) lmString += "LIM Z+    ";

            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(lmString, limitSwitchFont, b, getImgCoord(10, 25), sf);


            //Régua
            if(enableRuler)
            {
                int distPX;
                double distMM;

                //Vertical
                if(rulerMode)
                {
                    e.Graphics.DrawLine(penRedLine, rulerP1.X, 0, rulerP1.X, Machine.cameraHeight);
                    e.Graphics.DrawLine(penRedLine, rulerP2.X, 0, rulerP2.X, Machine.cameraHeight);
                    //e.Graphics.DrawLine(penRedLine, Math.Abs(rulerP1.X - rulerP2.X), )
                    distPX = rulerP2.X - rulerP1.X;
                }
                //Horizontal
                else
                {
                    e.Graphics.DrawLine(penRedLine, 0, rulerP1.Y, Machine.cameraWidth, rulerP1.Y);
                    e.Graphics.DrawLine(penRedLine, 0, rulerP2.Y, Machine.cameraWidth, rulerP2.Y);
                    distPX = rulerP2.Y - rulerP1.Y;
                }

                sf.Alignment = StringAlignment.Center;

                e.Graphics.DrawString(distPX + " px", limitSwitchFont, b, Machine.cameraWidth/2, Machine.cameraHeight/2 + 50, sf);

                if (Machine.isSampleDistSet)
                {
                    distMM = distPX * Machine.mmPerPixel();
                    e.Graphics.DrawString(String.Format("{0:0.0}", distMM) + " mm", limitSwitchFont, b, Machine.cameraWidth / 2, Machine.cameraHeight / 2 + 75, sf);
                }

            }

        }

        private void devicesCombo_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( videoDevices.Count != 0 )
            {
                videoDevice = new VideoCaptureDevice(videoDevices[devicesCombo.SelectedIndex].MonikerString);

                videoCapabilities = videoDevice.VideoCapabilities;
            }
        }
        private void devicesComboAux_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoDevices.Count != 0)
            {
                videoDeviceAux = new VideoCaptureDevice(videoDevices[devicesComboAux.SelectedIndex].MonikerString);

                videoCapabilitiesAux = videoDeviceAux.VideoCapabilities;
            }
        }

  
        void connectCamera()
        {
           // if (devicesCombo.SelectedIndex == 0) return;
            if (!videoDevice.IsRunning)
            {
                try
                {
                    videoDevice = new VideoCaptureDevice(videoDevices[devicesCombo.SelectedIndex].MonikerString);
                }
                catch
                {
                    return;
                }
                

                if ((videoCapabilities != null) && (videoCapabilities.Length != 0))
                {
                    int resolutionIndex = 0;

                    for (int i = 0; i < videoCapabilities.Length; i++)
                    {
                        if (videoCapabilities[i].FrameSize.Height > videoCapabilities[resolutionIndex].FrameSize.Height && videoCapabilities[i].AverageFrameRate > 20) //Procura pela resolução 1920 x 1080
                        {
                            resolutionIndex = i;
                        }
                    }
                       videoDevice.VideoResolution = videoCapabilities[resolutionIndex];
                    videoDevice.NewFrame += new NewFrameEventHandler(video_NewFrame);
                }

                
                
                videoSourcePlayerAlign.VideoSource = videoDevice;

             
                videoDevice.Start();
               
            

                int stepSize, minValue, maxValue, defaultValue;

                try
                {
                    videoDevice.GetCameraPropertyRange(CameraControlProperty.Focus, out minValue, out maxValue, out stepSize, out defaultValue, out CameraControlFlags controlFlags);
                    videoDevice.SetCameraProperty(CameraControlProperty.Focus, 0, (cbAutoFocus.Checked) ? CameraControlFlags.Auto : CameraControlFlags.Manual);
                    videoDevice.SetCameraProperty(CameraControlProperty.Exposure, 0, (cbAutoExp.Checked) ? CameraControlFlags.Auto : CameraControlFlags.Manual);
                }
                catch
                {
                    minValue = 0;
                    maxValue = 0;
                    stepSize = 0;
                }

                tbFocus.Minimum = minValue;
                tbFocus.Maximum = maxValue;
                tbFocus.SmallChange = stepSize;

                Machine.cameraWidth = videoDevice.VideoResolution.FrameSize.Width;
                Machine.cameraHeight = videoDevice.VideoResolution.FrameSize.Height;
            }
        }
        void connectAuxCamera()
        {
            if (!videoDeviceAux.IsRunning)
            {
                try
                {
                    videoDeviceAux = new VideoCaptureDevice(videoDevices[devicesComboAux.SelectedIndex].MonikerString);
                }
                catch
                {
                    return;
                }


                if ((videoCapabilitiesAux != null) && (videoCapabilitiesAux.Length != 0))
                {
                    int resolutionIndex = 0;

                    for (int i = 0; i < videoCapabilitiesAux.Length; i++)
                    {
                        if (videoCapabilitiesAux[i].FrameSize.Height > videoCapabilitiesAux[resolutionIndex].FrameSize.Height && videoCapabilitiesAux[i].AverageFrameRate > 20) //Procura pela resolução 1920 x 1080
                        {
                            resolutionIndex = i;
                        }
                    }
                    videoDeviceAux.VideoResolution = videoCapabilitiesAux[resolutionIndex];
                    videoDeviceAux.NewFrame += new NewFrameEventHandler(video_NewFrame);
                }

   

                videoSourcePlayerAux.VideoSource = videoDeviceAux;


                videoDeviceAux.Start();
            }
        }

        //Btn conectar - Camera alinhamento
        private void connectButton_Click( object sender, EventArgs e )
        {
            if (!videoDevice.IsRunning)
                connectCamera();
            else
                disconnectCamera();

            updateDisplayInfo();
        }
        //Btn conectar - Camera auxiliar
        private void connectAuxCameraBtn_Click(object sender, EventArgs e)
        {
            if (!videoDeviceAux.IsRunning)
                connectAuxCamera();
            else
                disconnectAuxCamera();

            updateDisplayInfo();
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {

        }
       


        // Disconnect camera
        private void disconnectCamera()
        {
            if (videoSourcePlayerAlign.VideoSource != null)
            {
                videoDevice.SignalToStop();
                //videoDevice.WaitForStop();
            }

            getCameraInfo();
        }

        private void disconnectAuxCamera()
        {
            if (videoSourcePlayerAux.VideoSource != null)
            {
                videoDeviceAux.SignalToStop();
                //videoDeviceAux.WaitForStop();
            }

            //getCameraInfo();
        }



        //Trackbar - foco
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try { if (!cbAutoFocus.Checked) videoDevice.SetCameraProperty(CameraControlProperty.Focus, tbFocus.Value, CameraControlFlags.Manual); }
            catch { MessageBox.Show("Não foi possível configurar o dispositivo!"); }
        }

        //Trackbar - zoom
        /*private void trackBar2_Scroll(object sender, EventArgs e)
         {
             try { videoDevice.SetCameraProperty(CameraControlProperty.Zoom, tbZoom.Value, CameraControlFlags.Manual); }
             catch { MessageBox.Show("Não foi possível configurar o dispositivo!"); }
         }*/


        //Trackbar - exposição
        private void tbExposure_Scroll(object sender, EventArgs e)
        {
            try { if (!cbAutoExp.Checked) videoDevice.SetCameraProperty(CameraControlProperty.Exposure, tbExp.Value, CameraControlFlags.Manual); }
            catch { MessageBox.Show("Não foi possível configurar o dispositivo!"); }
        }


       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

  

        private void cbAutoExp_CheckedChanged(object sender, EventArgs e)
        {
            //Set auto
            if(cbAutoExp.Checked)
            {
                tbExp.Enabled = false;
                try { videoDevice.SetCameraProperty(CameraControlProperty.Exposure, tbExp.Value, CameraControlFlags.Auto); }
                catch { MessageBox.Show("Não foi possível configurar o dispositivo!"); }
            }
            //Set manual
            else
            {
                tbExp.Enabled = true;
                try
                {

                    int v;
                    CameraControlFlags f;
                    videoDevice.GetCameraProperty(CameraControlProperty.Exposure, out v, out f);
                    tbExp.Value = v;
                    videoDevice.SetCameraProperty(CameraControlProperty.Exposure, tbExp.Value, CameraControlFlags.Manual);
                }
                catch { MessageBox.Show("Não foi possível configurar o dispositivo!"); }
            }
        }


        void updateCOMList()
        {
            string[] ports = SerialPort.GetPortNames();
            cbComPort.Items.Clear();
            cbComPort.Items.AddRange(ports);
            cbComPort.SelectedIndex = 0;
        }

        void serialConnect()
        {
            try
            {
                serialPort1.Open();
                sendCmd("?");
            }
            catch
            {
                MessageBox.Show("Error. Could not connect to the COM port.");
            }
        }

        void serialDisconnect()
        {
            try
            {
                serialPort1.Close();
            }
            catch
            {
                MessageBox.Show("Erro! Tente desconectar e reconectar o cabo USB!");
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(!serialPort1.IsOpen)
            {
                serialPort1.PortName = cbComPort.SelectedItem.ToString();
                serialConnect();
            }
            else
            {
                serialDisconnect();
            }
            

            updateDisplayInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
        }

        //Atualiza valores na tela
        void updateDisplayInfo()
        {
            lblPosX.Text = "X: " + String.Format("{0:0.00}", Machine.pos.x) + " mm";
            lblPosY.Text = "Y: " + String.Format("{0:0.00}", Machine.pos.y) + " mm";
            lblPosZ.Text = "Z: " + String.Format("{0:0.00}", Machine.pos.z) + " mm";
            lblPosA.Text = "A: " + String.Format("{0:0.00}", Machine.angA) + " °";

            lblTemp.Text = "Temp.: " + String.Format("{0:0.0}", Machine.temperature) + " °C";

            if (Machine.isMotorEnabledA) btnToggleEnableA.Text = "Disable A"; else btnToggleEnableA.Text = "Enable A";
            if (Machine.isMotorEnabledXYZ) btnToggleEnableXYZ.Text = "Disable XYZ"; else btnToggleEnableXYZ.Text = "Enable XYZ";

            bool Serial = serialPort1.IsOpen;

            if (!Serial) btnSerialConnect.Text = "Connect Serial";
            else btnSerialConnect.Text = "Disconnect";

            //gbPosControl.Enabled = Serial;
            //gbInfo.Enabled = Serial;
            //gbGetDist.Enabled = Serial;



            //Aligment Camera
            if (videoDevice.IsRunning)
            {
                connectAlignCameraBtn.Text = "Disconnect";
            }
            else
            {
                connectAlignCameraBtn.Text = "Connect";
            }

            devicesCombo.Enabled = !videoDevice.IsRunning;

            //Aux. Camera
            if (videoDeviceAux.IsRunning)
            {
                connectAuxCameraBtn.Text = "Disconnect";
            }
            else
            {
                connectAuxCameraBtn.Text = "Connect";
            }

            devicesComboAux.Enabled = !videoDeviceAux.IsRunning;
            //videoResolutionsCombo.Enabled = !videoDeviceAux.IsRunning;


            lblBEstTrackingScore.Text = String.Format("{0:0.000}", bestTrackingScore);



            gbPosit.Enabled = Machine.isSampleDistSet && !distMeasurementMode;

            gbGetDist.Enabled = (!distMeasurementMode || (distMeasurementMode && distMeasurementModeState == 0)) && (serialPort1.IsOpen && videoSourcePlayerAlign.IsRunning);
            gbAlign.Enabled = (!distMeasurementMode || (distMeasurementMode && distMeasurementModeState == 0)) && (serialPort1.IsOpen && videoSourcePlayerAlign.IsRunning) && ((Machine.autoPos && !Machine.sampleInPos) || !Machine.autoPos);

            gbInfo.Enabled = serialPort1.IsOpen;
            gbCameraControl.Enabled = videoSourcePlayerAlign.IsRunning && !(distMeasurementMode && distMeasurementModeState != 0);
            gbSerialConn.Enabled = !(distMeasurementMode && distMeasurementModeState != 0);

            btnSampleSupport.Enabled = gbAlign.Enabled;

            if(DEBUG_MODE)
            {
                gbPosit.Enabled = true;
                gbAlign.Enabled = true;
                gbGetDist.Enabled = true;
                gbInfo.Enabled = true;
                gbCameraControl.Enabled = true;
                gbSerialConn.Enabled = true;
                btnSampleSupport.Enabled = true;

                this.Text = "Last CMD:" + lastSentCmd;
            }

            if (Machine.isSampleDistSet)
            {
                if(!Machine.sampleInPos && !Machine.manualPosMode) getTargetPos();
                lblOffsetX.Text = "X: " + String.Format("{0:0.0}", Machine.targetOffset().x) + " mm";
                lblOffsetY.Text = "Y: " + String.Format("{0:0.0}", Machine.targetOffset().y) + " mm";
                lblOffsetZ.Text = "Z: " + String.Format("{0:0.0}", Machine.targetOffset().z) + " mm";
            }
            else
            {
                lblOffsetX.Text = "0 mm";
                lblOffsetY.Text = "0 mm";
                lblOffsetZ.Text = "0 mm";
            }



            if(Machine.autoPos)
            {
                if (Machine.sampleInPos)
                {
                    btnGoToRadPos.Text = "Return to alignment";
                }
                else
                {
                    btnGoToRadPos.Text = "Move to target";
                }
            }
            else
            {
                if (Machine.manualPosMode)
                {
                    btnGoToRadPos.Text = "Return to alignment";
                }
                else
                {
                    btnGoToRadPos.Text = "Select target";
                }
            }


            if (distMeasurementMode)
            {
                if(distMeasurementModeState == 0)
                {
                    gbSerialConn.Enabled = true;
                    btnSetDist.Text = "Confirm";

                }
            }
            else
            {
                btnSetDist.Text = "Get distance";
            }

            if(Machine.isSampleDistSet)
            {
                lblDistmm.Text = String.Format("{0:00}", Machine.sampleDist()) + " ±" + Machine.distStDev + " mm";
            }
            else
            {
                lblDistmm.Text = "Unknown";
            }

            //Posicionamento manual
            if(Machine.manualPosMode)
            {
                bool manualInPos = true;

                if (Math.Abs(Machine.targetOffset().x) > maxAcceptablePosError) manualInPos = false;
                if (Math.Abs(Machine.targetOffset().y) > maxAcceptablePosError) manualInPos = false;
                if (Math.Abs(Machine.targetOffset().z) > maxAcceptablePosError) manualInPos = false;

                Machine.sampleInPos = manualInPos;
            }




        }



        // ==================== SERIAL ===========================

         //Converte string para double levando em conta tanto '.' como ',' como separador decimal
        double stringToDouble(string str)
        {
            return Double.Parse(str.Replace(',', '.'), CultureInfo.InvariantCulture);
        }

        string serialIncomeData = "";

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            while (serialPort1.BytesToRead > 0)
            {
                serialIncomeData = serialPort1.ReadLine();

                Invoke(new EventHandler(dataMananger));
            }
            
        }

        void dataMananger(object sender, EventArgs e)
        {
            string sMsg = serialIncomeData;
            char[] msg = serialIncomeData.ToCharArray();
            string val = "";
            char cmd = msg[0];

            if(cmd == 'L')
            {
                if (sMsg.Contains("LMX+")) Machine.limitSwitchX = 1;
                if (sMsg.Contains("LMX-")) Machine.limitSwitchX = -1;

                if (sMsg.Contains("LMY+")) Machine.limitSwitchY = 1;
                if (sMsg.Contains("LMY-")) Machine.limitSwitchY = -1;

                if (sMsg.Contains("LMZ+")) Machine.limitSwitchZ = 1;
                if (sMsg.Contains("LMZ-")) Machine.limitSwitchZ = -1;
            }

            if(cmd == '#' || cmd == '*') //Sinal de OK
            {
                bool success = (cmd == '#');
                Machine.machineReady = true;

                //Medição de distância
                if(distMeasurementMode && (distMeasurementModeState == 2 || distMeasurementModeState == 3))
                {
                    if(!success)
                    {
                        distMeasurementMode = false;
                        MessageBox.Show("Limit Switch Detected - Measurement Failed. Please leave at least 35 mm of clearance from (-X) hard limit.");
                    }
                    manageDistMeasurement();
                }

                //Lista de comandos
                if(isCmdListRunning)
                {
                    if(cmdListExpResult[cmdListIndex] && !success)
                    {
                        isCmdListRunning = false;
                        //MessageBox.Show("Limit Switch Detected - Positioning failed");
                    }
                    cmdListIndex++;
                    manageCmdList();
                }

                //Posicionamento automático
                if(Machine.sampleInPos && Machine.autoPos)
                {
                    if(!success)
                    {
                        MessageBox.Show("Limit Switch Detected - Positioning failed");
                        managePositioning();
                    }
                }

                Machine.limitSwitchX = 0;
                Machine.limitSwitchY = 0;
                Machine.limitSwitchZ = 0;

                return;
            }

            if(cmd == 'E') //Estado dos motores (Ativado/Desativado)
            {
                bool b = intToBool(int.Parse(msg[2].ToString()));

                if(msg[1] == 'p') Machine.isMotorEnabledXYZ = b; //XYZ 
                if(msg[1] == 'a') Machine.isMotorEnabledA = b; //A

                return;
            }

            for (int i = 1; i < msg.Length - 1; i++)
            {
                val += msg[i];
            }

            //Valores Numéricos (posição, temp., etc)
            updateInfo(cmd, val);
        }

        void updateInfo(char cmd, string val)
        {
            switch (cmd)
            {
                case 'x':
                    Machine.lastPos.x = Machine.pos.x;
                    Machine.pos.x = stringToDouble(val);
                    break;

                case 'y':
                    Machine.lastPos.y = Machine.pos.y;
                    Machine.pos.y = stringToDouble(val);

                    if (Machine.isSampleDistSet)
                    {
                        Machine.rawSampleDist += (Machine.lastPos.y - Machine.pos.y);
                    }

                    break;

                case 'z':
                    Machine.lastPos.z = Machine.pos.z;
                    Machine.pos.z = stringToDouble(val);

                    break;

                case 'a':
                    Machine.angA = stringToDouble(val);
                    break;

                case 't':
                    Machine.temperature = stringToDouble(val);
                    break;
            }

            updateDisplayInfo();
        }

        public static string lastSentCmd = "";
        public static Boolean sendCmd(string cmd)
        {
            string _cmd = cmd.Replace(',', '.');

            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.WriteLine(_cmd);
                    lastSentCmd = _cmd;
                    return true;
                }
                catch
                {
                    MessageBox.Show("The command could not be sent. Please restart the control panel or the machine");
                    
                }
            }
            return false;
        }

        public static string getAbsPosCmd(double x, double y, double z)
        {
            return "P" + String.Format("{0:0.00}", x) + " " + String.Format("{0:0.00}", y) + " " + String.Format("{0:0.00}", z);
        }
        public static Boolean sendAbsPosCmd(double x, double y, double z)
        {
            if (Machine.machineReady)
            {
                string cmd = getAbsPosCmd(x, y, z);

                if (sendCmd(cmd))
                {
                    Machine.machineReady = false;
                    return true;
                }

            }
            return false;
        }
        public static string getStepCmd(double x, double y, double z)
        {
            return "S" + String.Format("{0:0.00}", x) + " " + String.Format("{0:0.00}", y) + " " + String.Format("{0:0.00}", z);
        }
        public static Boolean sendStepCmd(double x, double y, double z)
        {
            if(Machine.machineReady)
            {
                string cmd = getStepCmd(x, y, z);
                if(sendCmd(cmd))
                {
                    Machine.machineReady = false;
                    return true;
                }
                
            }
            return false;
        }

        
        public static string getAngleCmd(double a)
        {
            return "A" + String.Format("{0:0.00}", a);
        }
       public static Boolean sendAngleCmd(double a)
        {
            if (a == Machine.angA) return true;
            if (Machine.machineReady)
            {
                string cmd = getAngleCmd(a);

                if (sendCmd(cmd))
                {
                    Machine.machineReady = false;
                    return true;
                }
            }
            return false;
        }

        public static Boolean sendAngleVelCmd(float a)
        {
            if (Machine.machineReady)
            {
                string cmd = "R" + String.Format("{0:000.00}", a);

                if (sendCmd(cmd))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool sendToggleEnableCmd(char axis)
        {
            if (Machine.machineReady)
            {
                bool b;
                if (axis == 'p') b = Machine.isMotorEnabledXYZ; else b = Machine.isMotorEnabledA;
                string cmd = "E" + axis + boolToInt(!b);

                if (sendCmd(cmd))
                {
                    return true;
                }
            }
            return false;
        }

        public bool sendEmergencyStopCmd()
        {
            distMeasurementMode = false;

            string cmd = "!";

                if (sendCmd(cmd))
                {
                    return true;
                }
            return false;
        }


        //Retorna cordenada de irradiação baseada na posição atual
       void getTargetPos()
        {
            Vector3D target = Machine.pos.copy();
            
            double deltaDist = Machine.sampleDist() - (double)numTargetDist.Value;
            target.y += deltaDist;
            target.z += Machine.angCompAdv(deltaDist);
            target.z -= Machine.cameraToXRayVerOffset;

            Machine.targetPos = target.copy();
        }

        void toggleSamplePositionModeDirect()
        {
            //Vai para posição de irrad
            if(!Machine.sampleInPos)
            {
                getTargetPos();
                Machine.alignmentPos = Machine.pos.copy();
                sendAbsPosCmd(Machine.targetPos.x, Machine.targetPos.y, Machine.targetPos.z);
                Machine.sampleInPos = true;
            }
            //REtorna para alinhamento
            else
            {
                sendAbsPosCmd(Machine.alignmentPos.x, Machine.alignmentPos.y, Machine.alignmentPos.z);
                Machine.sampleInPos = false;
            }
        }

       /* void toggleSampleManualPosition()
        {
            Machine.manualPosMode = !Machine.manualPosMode;
            //Posicionamento manual
            if (!Machine.manualPosMode)
            {

            }
            //Volta para alinhamento
            else
            {

            }
        }*/

        //Move amostra para feixe / retorna para câmera para ajuste
        void managePositioning()
        {
            if (!Machine.machineReady) return;
            if (!serialPort1.IsOpen) return;

            //Auto
            if (rbAutoPos.Checked)
            {
                //Longe - Posicionamento direto
                if (numTargetDist.Value >= (int)Math.Round(Machine.directPosMinDistSmall) && Machine.sampleSupportConfig == 0 ||
                    numTargetDist.Value >= (int)Math.Round(Machine.directPosMinDistHeavy) && Machine.sampleSupportConfig == 1)
                {
                    toggleSamplePositionModeDirect();
                }
                else
                {
                    MessageBox.Show("Target will be too close to the X-ray emitter. Please use manual positioning.");
                    return;
                }
            }
            //Manual
            else
            {
                Machine.manualPosMode = !Machine.manualPosMode;
                if (!Machine.manualPosMode) Machine.sampleInPos = false;
            }

            updateDisplayInfo();
        }

  

//==================================================================================================================
        private void cbAutoFocus_CheckedChanged(object sender, EventArgs e)
        {
            //Set auto
            if (cbAutoFocus.Checked)
            {
                tbFocus.Enabled = false;
                try { videoDevice.SetCameraProperty(CameraControlProperty.Focus, tbFocus.Value, CameraControlFlags.Auto); }
                catch { MessageBox.Show("Could not config the camera!"); }
            }
            //Set manual
            else
            {
                tbFocus.Enabled = true;
                int v;
                CameraControlFlags f;
                videoDevice.GetCameraProperty(CameraControlProperty.Focus, out v, out f);
                tbFocus.Value = v;
                try { videoDevice.SetCameraProperty(CameraControlProperty.Focus, tbFocus.Value, CameraControlFlags.Manual); }
                catch { MessageBox.Show("Could not config the camera!"); }
            }
        }

        //Z-
        private void btnStepUp_Click(object sender, EventArgs e)
        {
            sendStepCmd(0, 0, Convert.ToSingle(numStepLen.Value));
        }

        //Z+
        private void btnStepDown_Click(object sender, EventArgs e)
        {
            sendStepCmd(0, 0, Convert.ToSingle(-numStepLen.Value));
        }

        //X+
        private void btnStepLeft_Click(object sender, EventArgs e)
        {
            sendStepCmd(Convert.ToSingle(numStepLen.Value), 0, 0);
        }

        //X-
        private void btnStepRight_Click(object sender, EventArgs e)
        {
            sendStepCmd(Convert.ToSingle(-numStepLen.Value), 0, 0);
        }

        //Y+
        private void btnStepBack_Click(object sender, EventArgs e)
        {
            double hComp = Machine.angCompAdv((double)numStepLen.Value);
            if (!cbAngComp.Checked) hComp = 0;

            bool ok = sendStepCmd(0, Convert.ToSingle(numStepLen.Value), hComp);
        }

        //Y-
        private void btnStepForw_Click(object sender, EventArgs e)
        {
            double hComp = Machine.angCompAdv((double)-numStepLen.Value);
            if (!cbAngComp.Checked) hComp = 0;

            bool ok = sendStepCmd(0, Convert.ToSingle(-numStepLen.Value), hComp);
        }


        private void btnGoToRadPos_Click(object sender, EventArgs e)
        {
            managePositioning();
            updateDisplayInfo();
        }

        private void txtDist_TextChanged(object sender, EventArgs e)
        {

        }

        private void videoResolutionsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSampleSupport_Click(object sender, EventArgs e)
        {
            var f = new sampleSupportPanel();
            f.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            sendEmergencyStopCmd();
        }

        private void lblPosX_Click(object sender, EventArgs e)
        {

        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            config c = new config();
            c.ShowDialog();
        }

        private void btnToggleEnableA_Click(object sender, EventArgs e)
        {
            sendToggleEnableCmd('a');
            updateDisplayInfo();
        }

        private void btnToggleEnableXYZ_Click(object sender, EventArgs e)
        {
            sendToggleEnableCmd('p');
            updateDisplayInfo();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //updateDisplayInfo();
            //MessageBox.Show("Guilherme Parreira Gomes - Eng. Mecânica (2021)");
            //CultureInfo.InvariantCulture
        }

      

        private void cbAngComp_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefreshCOMList_Click(object sender, EventArgs e)
        {
            updateCOMList();
        }

        private void numStepLen_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panelCameraAux_Paint(object sender, PaintEventArgs e)
        {

        }

        private void videoSourcePlayerAux_Click(object sender, EventArgs e)
        {
            videoSourcePlayerAux.Size = panelCameraAux.Size;
            videoSourcePlayerAux.Location = new Point(0, 0);
        }

        private void videoSourcePlayerAux_StyleChanged(object sender, EventArgs e)
        {
            
        }

        private void videoSourcePlayerAux_NewFrame(object sender, ref Bitmap image)
        {
            

        }

        private void gbGetDist_Enter(object sender, EventArgs e)
        {

        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == ((char)Keys.Escape))
            {
                if (enableRuler) enableRuler = false;

                if(distMeasurementMode && distMeasurementModeState == 0)
                {
                    distMeasurementMode = false;
                }
                updateDisplayInfo();
            }

            
        }

        private void gbPosControl_Enter(object sender, EventArgs e)
        {

        }

        private void cbSampleSupport_SelectedIndexChanged(object sender, EventArgs e)
        {
            Machine.sampleSupportConfig = cbSampleSupport.SelectedIndex;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void rbAutoPos_CheckedChanged(object sender, EventArgs e)
        {
            Machine.autoPos = rbAutoPos.Checked;
            updateDisplayInfo();
        }

        private void numTargetDist_ValueChanged(object sender, EventArgs e)
        {
            Machine.targetSampleDist = (double)numTargetDist.Value;
            updateDisplayInfo();
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            DEBUG_MODE = true;
            MessageBox.Show("DEBUG MODE ON");

            updateDisplayInfo();
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableRuler = true;
            rulerMode = true;
            rulerP1.X = Machine.cameraWidth / 2 - 100;
            rulerP2.X = Machine.cameraWidth / 2 + 100;

        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableRuler = true;
            rulerMode = false;
            rulerP1.Y = Machine.cameraHeight / 2 - 100;
            rulerP2.Y = Machine.cameraHeight / 2 + 100;
        }

        private void customCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomCmd c = new CustomCmd();
            c.ShowDialog();
        }

        private void videoSourcePlayerAux_Paint(object sender, PaintEventArgs e)
        {
            if(videoSourcePlayerAux.IsRunning && videoSourcePlayerAux.Width != panelCameraAux.Size.Width)
            videoSourcePlayerAux.Size = panelCameraAux.Size;
            videoSourcePlayerAux.Location = new Point(0, 0);

            if (Machine.sampleInPos)
            {
                sf.Alignment = StringAlignment.Center;

                //TextFormatFlags f = TextFormatFlags.HorizontalCenter;
                e.Graphics.DrawString("SAMPLE IN POSITION", sampInPosFont, b2, getImgCoord(panelCameraAlign.Width / 2, 100), sf);
            }


            if (Machine.manualPosMode)
            {
                //Offset
                sf.Alignment = StringAlignment.Center;
                e.Graphics.DrawString("MANUAL POSITIONING", sampInPosFont, b2, getImgCoordAux(panelCameraAlign.Width / 2, 50), sf);


                sf.Alignment = StringAlignment.Near;
                string offset = "OFFSET: \nX: " + String.Format("{0:00}", Machine.targetOffset().x) +
                    "\nY: " + String.Format("{0:00}", Machine.targetOffset().y) +
                    "\nZ: " + String.Format("{0:00}", Machine.targetOffset().z);

                Brush bOffsetX, bOffsetY, bOffsetZ;

                bOffsetX = (Math.Abs(Machine.targetOffset().x) <= maxAcceptablePosError) ? brushOffsetGood : brushOffsetOff;
                bOffsetY = (Math.Abs(Machine.targetOffset().y) <= maxAcceptablePosError) ? brushOffsetGood : brushOffsetOff;
                bOffsetZ = (Math.Abs(Machine.targetOffset().z) <= maxAcceptablePosError) ? brushOffsetGood : brushOffsetOff;

                e.Graphics.DrawString("OFFSET:", offsetOffFont, brushOffsetOff, getImgCoordAux(10, panelCameraAlign.Height / 2), sf);
                e.Graphics.DrawString("X: " + String.Format("{0:0.0}", Machine.targetOffset().x) + " mm", offsetOffFont, bOffsetX, getImgCoordAux(10, panelCameraAlign.Height / 2 + 30), sf);
                e.Graphics.DrawString("Y: " + String.Format("{0:0.0}", Machine.targetOffset().y) + " mm", offsetOffFont, bOffsetY, getImgCoordAux(10, panelCameraAlign.Height / 2 + 60), sf);
                e.Graphics.DrawString("Z: " + String.Format("{0:0.0}", Machine.targetOffset().z) + " mm", offsetOffFont, bOffsetZ, getImgCoordAux(10, panelCameraAlign.Height / 2 + 90), sf);
            }
        }
    }
}
