namespace autoDif
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gbSerialConn = new System.Windows.Forms.GroupBox();
            this.btnRefreshCOMList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbComPort = new System.Windows.Forms.ComboBox();
            this.btnSerialConnect = new System.Windows.Forms.Button();
            this.numProbeSize = new System.Windows.Forms.NumericUpDown();
            this.btnStepRight = new System.Windows.Forms.Button();
            this.btnStepLeft = new System.Windows.Forms.Button();
            this.btnStepUp = new System.Windows.Forms.Button();
            this.btnStepDown = new System.Windows.Forms.Button();
            this.btnStepForw = new System.Windows.Forms.Button();
            this.btnStepBack = new System.Windows.Forms.Button();
            this.numStepLen = new System.Windows.Forms.NumericUpDown();
            this.btnGoToRadPos = new System.Windows.Forms.Button();
            this.btnToggleEnableXYZ = new System.Windows.Forms.Button();
            this.btnToggleEnableA = new System.Windows.Forms.Button();
            this.cbAngComp = new System.Windows.Forms.CheckBox();
            this.numTargetDist = new System.Windows.Forms.NumericUpDown();
            this.lblTemp = new System.Windows.Forms.Label();
            this.gbPosit = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblOffsetZ = new System.Windows.Forms.Label();
            this.cbSampleSupport = new System.Windows.Forms.ComboBox();
            this.lblOffsetY = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblOffsetX = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rbAutoPos = new System.Windows.Forms.RadioButton();
            this.rbAutoManual = new System.Windows.Forms.RadioButton();
            this.lblPosA = new System.Windows.Forms.Label();
            this.btnSampleSupport = new System.Windows.Forms.Button();
            this.tbFocus = new System.Windows.Forms.TrackBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label4 = new System.Windows.Forms.Label();
            this.tbExp = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAutoFocus = new System.Windows.Forms.CheckBox();
            this.cbAutoExp = new System.Windows.Forms.CheckBox();
            this.btnSetDist = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDistmm = new System.Windows.Forms.Label();
            this.gbCameraControl = new System.Windows.Forms.GroupBox();
            this.gbGetDist = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBEstTrackingScore = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doseRateCalculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.lblPosZ = new System.Windows.Forms.Label();
            this.lblPosY = new System.Windows.Forms.Label();
            this.lblPosX = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbAlign = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelCameraAux = new System.Windows.Forms.Panel();
            this.devicesComboAux = new System.Windows.Forms.ComboBox();
            this.connectAuxCameraBtn = new System.Windows.Forms.Button();
            this.videoSourcePlayerAux = new Accord.Controls.VideoSourcePlayer();
            this.alignTab = new System.Windows.Forms.TabPage();
            this.panelCameraAlign = new System.Windows.Forms.Panel();
            this.devicesCombo = new System.Windows.Forms.ComboBox();
            this.connectAlignCameraBtn = new System.Windows.Forms.Button();
            this.videoSourcePlayerAlign = new Accord.Controls.VideoSourcePlayer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.gbSerialConn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numProbeSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStepLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetDist)).BeginInit();
            this.gbPosit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFocus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbExp)).BeginInit();
            this.gbCameraControl.SuspendLayout();
            this.gbGetDist.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbAlign.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelCameraAux.SuspendLayout();
            this.alignTab.SuspendLayout();
            this.panelCameraAlign.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 100;
            // 
            // gbSerialConn
            // 
            this.gbSerialConn.Controls.Add(this.btnRefreshCOMList);
            this.gbSerialConn.Controls.Add(this.label1);
            this.gbSerialConn.Controls.Add(this.cbComPort);
            this.gbSerialConn.Controls.Add(this.btnSerialConnect);
            this.gbSerialConn.Location = new System.Drawing.Point(811, 43);
            this.gbSerialConn.Name = "gbSerialConn";
            this.gbSerialConn.Size = new System.Drawing.Size(186, 104);
            this.gbSerialConn.TabIndex = 42;
            this.gbSerialConn.TabStop = false;
            this.gbSerialConn.Text = "Connection";
            this.toolTip.SetToolTip(this.gbSerialConn, "Serial Connection");
            // 
            // btnRefreshCOMList
            // 
            this.btnRefreshCOMList.Location = new System.Drawing.Point(103, 40);
            this.btnRefreshCOMList.Name = "btnRefreshCOMList";
            this.btnRefreshCOMList.Size = new System.Drawing.Size(72, 21);
            this.btnRefreshCOMList.TabIndex = 26;
            this.btnRefreshCOMList.Text = "Refresh";
            this.btnRefreshCOMList.UseVisualStyleBackColor = true;
            this.btnRefreshCOMList.Click += new System.EventHandler(this.btnRefreshCOMList_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Serial Port";
            // 
            // cbComPort
            // 
            this.cbComPort.FormattingEnabled = true;
            this.cbComPort.Location = new System.Drawing.Point(12, 40);
            this.cbComPort.Name = "cbComPort";
            this.cbComPort.Size = new System.Drawing.Size(85, 21);
            this.cbComPort.TabIndex = 25;
            // 
            // btnSerialConnect
            // 
            this.btnSerialConnect.Location = new System.Drawing.Point(12, 67);
            this.btnSerialConnect.Name = "btnSerialConnect";
            this.btnSerialConnect.Size = new System.Drawing.Size(163, 28);
            this.btnSerialConnect.TabIndex = 20;
            this.btnSerialConnect.Text = "Connect Serial";
            this.btnSerialConnect.UseVisualStyleBackColor = true;
            this.btnSerialConnect.Click += new System.EventHandler(this.button2_Click);
            // 
            // numProbeSize
            // 
            this.numProbeSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numProbeSize.Location = new System.Drawing.Point(77, 54);
            this.numProbeSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numProbeSize.Name = "numProbeSize";
            this.numProbeSize.Size = new System.Drawing.Size(42, 20);
            this.numProbeSize.TabIndex = 21;
            this.toolTip.SetToolTip(this.numProbeSize, "Tracking area size");
            this.numProbeSize.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // btnStepRight
            // 
            this.btnStepRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStepRight.Location = new System.Drawing.Point(91, 78);
            this.btnStepRight.Name = "btnStepRight";
            this.btnStepRight.Size = new System.Drawing.Size(34, 31);
            this.btnStepRight.TabIndex = 0;
            this.btnStepRight.Text = "→";
            this.toolTip.SetToolTip(this.btnStepRight, "Move right (-X)");
            this.btnStepRight.UseVisualStyleBackColor = true;
            this.btnStepRight.Click += new System.EventHandler(this.btnStepRight_Click);
            // 
            // btnStepLeft
            // 
            this.btnStepLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStepLeft.Location = new System.Drawing.Point(11, 78);
            this.btnStepLeft.Name = "btnStepLeft";
            this.btnStepLeft.Size = new System.Drawing.Size(34, 31);
            this.btnStepLeft.TabIndex = 1;
            this.btnStepLeft.Text = "←";
            this.toolTip.SetToolTip(this.btnStepLeft, "Move left (+X)");
            this.btnStepLeft.UseVisualStyleBackColor = true;
            this.btnStepLeft.Click += new System.EventHandler(this.btnStepLeft_Click);
            // 
            // btnStepUp
            // 
            this.btnStepUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStepUp.Location = new System.Drawing.Point(51, 41);
            this.btnStepUp.Name = "btnStepUp";
            this.btnStepUp.Size = new System.Drawing.Size(34, 31);
            this.btnStepUp.TabIndex = 2;
            this.btnStepUp.Text = "↑";
            this.toolTip.SetToolTip(this.btnStepUp, "Move up (+Z)");
            this.btnStepUp.UseVisualStyleBackColor = true;
            this.btnStepUp.Click += new System.EventHandler(this.btnStepUp_Click);
            // 
            // btnStepDown
            // 
            this.btnStepDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStepDown.Location = new System.Drawing.Point(51, 78);
            this.btnStepDown.Name = "btnStepDown";
            this.btnStepDown.Size = new System.Drawing.Size(34, 31);
            this.btnStepDown.TabIndex = 3;
            this.btnStepDown.Text = "↓";
            this.toolTip.SetToolTip(this.btnStepDown, "Move down (-Z)");
            this.btnStepDown.UseVisualStyleBackColor = true;
            this.btnStepDown.Click += new System.EventHandler(this.btnStepDown_Click);
            // 
            // btnStepForw
            // 
            this.btnStepForw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStepForw.Location = new System.Drawing.Point(168, 41);
            this.btnStepForw.Name = "btnStepForw";
            this.btnStepForw.Size = new System.Drawing.Size(34, 31);
            this.btnStepForw.TabIndex = 4;
            this.btnStepForw.Text = "↑";
            this.toolTip.SetToolTip(this.btnStepForw, "Move back (-Y)");
            this.btnStepForw.UseVisualStyleBackColor = true;
            this.btnStepForw.Click += new System.EventHandler(this.btnStepForw_Click);
            // 
            // btnStepBack
            // 
            this.btnStepBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStepBack.Location = new System.Drawing.Point(168, 78);
            this.btnStepBack.Name = "btnStepBack";
            this.btnStepBack.Size = new System.Drawing.Size(34, 31);
            this.btnStepBack.TabIndex = 5;
            this.btnStepBack.Text = "↓";
            this.toolTip.SetToolTip(this.btnStepBack, "Move forward (+Y)");
            this.btnStepBack.UseVisualStyleBackColor = true;
            this.btnStepBack.Click += new System.EventHandler(this.btnStepBack_Click);
            // 
            // numStepLen
            // 
            this.numStepLen.DecimalPlaces = 2;
            this.numStepLen.Location = new System.Drawing.Point(69, 159);
            this.numStepLen.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numStepLen.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numStepLen.Name = "numStepLen";
            this.numStepLen.Size = new System.Drawing.Size(50, 20);
            this.numStepLen.TabIndex = 9;
            this.toolTip.SetToolTip(this.numStepLen, "Step length");
            this.numStepLen.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numStepLen.ValueChanged += new System.EventHandler(this.numStepLen_ValueChanged);
            // 
            // btnGoToRadPos
            // 
            this.btnGoToRadPos.Location = new System.Drawing.Point(9, 103);
            this.btnGoToRadPos.Name = "btnGoToRadPos";
            this.btnGoToRadPos.Size = new System.Drawing.Size(133, 31);
            this.btnGoToRadPos.TabIndex = 12;
            this.btnGoToRadPos.Text = "Move to X-Ray";
            this.toolTip.SetToolTip(this.btnGoToRadPos, "Move sample to irradiation position.");
            this.btnGoToRadPos.UseVisualStyleBackColor = true;
            this.btnGoToRadPos.Click += new System.EventHandler(this.btnGoToRadPos_Click);
            // 
            // btnToggleEnableXYZ
            // 
            this.btnToggleEnableXYZ.Location = new System.Drawing.Point(10, 121);
            this.btnToggleEnableXYZ.Name = "btnToggleEnableXYZ";
            this.btnToggleEnableXYZ.Size = new System.Drawing.Size(100, 26);
            this.btnToggleEnableXYZ.TabIndex = 14;
            this.btnToggleEnableXYZ.Text = "Turn Off XYZ";
            this.toolTip.SetToolTip(this.btnToggleEnableXYZ, "Toggle power on X Y and Z stepper motors");
            this.btnToggleEnableXYZ.UseVisualStyleBackColor = true;
            this.btnToggleEnableXYZ.Click += new System.EventHandler(this.btnToggleEnableXYZ_Click);
            // 
            // btnToggleEnableA
            // 
            this.btnToggleEnableA.Location = new System.Drawing.Point(116, 121);
            this.btnToggleEnableA.Name = "btnToggleEnableA";
            this.btnToggleEnableA.Size = new System.Drawing.Size(86, 26);
            this.btnToggleEnableA.TabIndex = 15;
            this.btnToggleEnableA.Text = "Turn Off A";
            this.toolTip.SetToolTip(this.btnToggleEnableA, "Toggle power on sample support (A) stepper motor.");
            this.btnToggleEnableA.UseVisualStyleBackColor = true;
            this.btnToggleEnableA.Click += new System.EventHandler(this.btnToggleEnableA_Click);
            // 
            // cbAngComp
            // 
            this.cbAngComp.AutoSize = true;
            this.cbAngComp.Checked = true;
            this.cbAngComp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAngComp.Location = new System.Drawing.Point(126, 161);
            this.cbAngComp.Name = "cbAngComp";
            this.cbAngComp.Size = new System.Drawing.Size(81, 17);
            this.cbAngComp.TabIndex = 20;
            this.cbAngComp.Text = "Ang, Comp.";
            this.toolTip.SetToolTip(this.cbAngComp, "Toggle X-Ray Angle Compensation");
            this.cbAngComp.UseVisualStyleBackColor = true;
            this.cbAngComp.CheckedChanged += new System.EventHandler(this.cbAngComp_CheckedChanged);
            // 
            // numTargetDist
            // 
            this.numTargetDist.Location = new System.Drawing.Point(100, 77);
            this.numTargetDist.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numTargetDist.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTargetDist.Name = "numTargetDist";
            this.numTargetDist.Size = new System.Drawing.Size(42, 20);
            this.numTargetDist.TabIndex = 23;
            this.toolTip.SetToolTip(this.numTargetDist, "Step length");
            this.numTargetDist.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numTargetDist.ValueChanged += new System.EventHandler(this.numTargetDist_ValueChanged);
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemp.Location = new System.Drawing.Point(10, 59);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(104, 24);
            this.lblTemp.TabIndex = 4;
            this.lblTemp.Text = "Temp: 0 °C";
            this.toolTip.SetToolTip(this.lblTemp, "Ambient temperature");
            this.lblTemp.Click += new System.EventHandler(this.lblTemp_Click);
            this.lblTemp.DoubleClick += new System.EventHandler(this.lblTemp_DoubleClick);
            // 
            // gbPosit
            // 
            this.gbPosit.Controls.Add(this.label16);
            this.gbPosit.Controls.Add(this.lblOffsetZ);
            this.gbPosit.Controls.Add(this.cbSampleSupport);
            this.gbPosit.Controls.Add(this.lblOffsetY);
            this.gbPosit.Controls.Add(this.label12);
            this.gbPosit.Controls.Add(this.lblOffsetX);
            this.gbPosit.Controls.Add(this.label11);
            this.gbPosit.Controls.Add(this.numTargetDist);
            this.gbPosit.Controls.Add(this.rbAutoPos);
            this.gbPosit.Controls.Add(this.rbAutoManual);
            this.gbPosit.Controls.Add(this.btnGoToRadPos);
            this.gbPosit.Location = new System.Drawing.Point(1030, 153);
            this.gbPosit.Name = "gbPosit";
            this.gbPosit.Size = new System.Drawing.Size(148, 193);
            this.gbPosit.TabIndex = 23;
            this.gbPosit.TabStop = false;
            this.gbPosit.Text = "Positioning";
            this.toolTip.SetToolTip(this.gbPosit, "teste");
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(11, 155);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 16);
            this.label16.TabIndex = 5;
            this.label16.Text = "Offset:";
            // 
            // lblOffsetZ
            // 
            this.lblOffsetZ.AutoSize = true;
            this.lblOffsetZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOffsetZ.Location = new System.Drawing.Point(61, 171);
            this.lblOffsetZ.Name = "lblOffsetZ";
            this.lblOffsetZ.Size = new System.Drawing.Size(54, 16);
            this.lblOffsetZ.TabIndex = 7;
            this.lblOffsetZ.Text = "Z: 0 mm";
            this.lblOffsetZ.Click += new System.EventHandler(this.label13_Click);
            // 
            // cbSampleSupport
            // 
            this.cbSampleSupport.DisplayMember = "0";
            this.cbSampleSupport.FormattingEnabled = true;
            this.cbSampleSupport.Items.AddRange(new object[] {
            "Small",
            "Heavy"});
            this.cbSampleSupport.Location = new System.Drawing.Point(59, 48);
            this.cbSampleSupport.Name = "cbSampleSupport";
            this.cbSampleSupport.Size = new System.Drawing.Size(83, 21);
            this.cbSampleSupport.TabIndex = 25;
            this.cbSampleSupport.SelectedIndexChanged += new System.EventHandler(this.cbSampleSupport_SelectedIndexChanged);
            // 
            // lblOffsetY
            // 
            this.lblOffsetY.AutoSize = true;
            this.lblOffsetY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOffsetY.Location = new System.Drawing.Point(61, 155);
            this.lblOffsetY.Name = "lblOffsetY";
            this.lblOffsetY.Size = new System.Drawing.Size(55, 16);
            this.lblOffsetY.TabIndex = 6;
            this.lblOffsetY.Text = "Y: 0 mm";
            this.lblOffsetY.Click += new System.EventHandler(this.lblOffsetY_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Support:";
            // 
            // lblOffsetX
            // 
            this.lblOffsetX.AutoSize = true;
            this.lblOffsetX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOffsetX.Location = new System.Drawing.Point(61, 139);
            this.lblOffsetX.Name = "lblOffsetX";
            this.lblOffsetX.Size = new System.Drawing.Size(54, 16);
            this.lblOffsetX.TabIndex = 5;
            this.lblOffsetX.Text = "X: 0 mm";
            this.lblOffsetX.Click += new System.EventHandler(this.label15_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Target dist. (mm):";
            // 
            // rbAutoPos
            // 
            this.rbAutoPos.AutoSize = true;
            this.rbAutoPos.Checked = true;
            this.rbAutoPos.Location = new System.Drawing.Point(9, 20);
            this.rbAutoPos.Name = "rbAutoPos";
            this.rbAutoPos.Size = new System.Drawing.Size(47, 17);
            this.rbAutoPos.TabIndex = 21;
            this.rbAutoPos.TabStop = true;
            this.rbAutoPos.Text = "Auto";
            this.rbAutoPos.UseVisualStyleBackColor = true;
            this.rbAutoPos.CheckedChanged += new System.EventHandler(this.rbAutoPos_CheckedChanged);
            // 
            // rbAutoManual
            // 
            this.rbAutoManual.AutoSize = true;
            this.rbAutoManual.Location = new System.Drawing.Point(82, 20);
            this.rbAutoManual.Name = "rbAutoManual";
            this.rbAutoManual.Size = new System.Drawing.Size(60, 17);
            this.rbAutoManual.TabIndex = 22;
            this.rbAutoManual.Text = "Manual";
            this.rbAutoManual.UseVisualStyleBackColor = true;
            // 
            // lblPosA
            // 
            this.lblPosA.AutoSize = true;
            this.lblPosA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosA.Location = new System.Drawing.Point(10, 26);
            this.lblPosA.Name = "lblPosA";
            this.lblPosA.Size = new System.Drawing.Size(49, 24);
            this.lblPosA.TabIndex = 3;
            this.lblPosA.Text = "A: 0°";
            this.toolTip.SetToolTip(this.lblPosA, "Sample support angle");
            // 
            // btnSampleSupport
            // 
            this.btnSampleSupport.FlatAppearance.BorderSize = 0;
            this.btnSampleSupport.Location = new System.Drawing.Point(5, 538);
            this.btnSampleSupport.Name = "btnSampleSupport";
            this.btnSampleSupport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSampleSupport.Size = new System.Drawing.Size(124, 38);
            this.btnSampleSupport.TabIndex = 13;
            this.btnSampleSupport.Text = "Sample Support Control";
            this.toolTip.SetToolTip(this.btnSampleSupport, "Open sample support control menu.");
            this.btnSampleSupport.UseVisualStyleBackColor = true;
            this.btnSampleSupport.Click += new System.EventHandler(this.btnSampleSupport_Click);
            // 
            // tbFocus
            // 
            this.tbFocus.Enabled = false;
            this.tbFocus.LargeChange = 1;
            this.tbFocus.Location = new System.Drawing.Point(9, 120);
            this.tbFocus.Maximum = 150;
            this.tbFocus.Name = "tbFocus";
            this.tbFocus.Size = new System.Drawing.Size(198, 45);
            this.tbFocus.TabIndex = 10;
            this.tbFocus.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Focus";
            // 
            // tbExp
            // 
            this.tbExp.Enabled = false;
            this.tbExp.LargeChange = 1;
            this.tbExp.Location = new System.Drawing.Point(6, 49);
            this.tbExp.Maximum = -2;
            this.tbExp.Minimum = -11;
            this.tbExp.Name = "tbExp";
            this.tbExp.Size = new System.Drawing.Size(201, 45);
            this.tbExp.TabIndex = 15;
            this.tbExp.Value = -5;
            this.tbExp.Scroll += new System.EventHandler(this.tbExposure_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Exposure";
            // 
            // cbAutoFocus
            // 
            this.cbAutoFocus.AutoSize = true;
            this.cbAutoFocus.Checked = true;
            this.cbAutoFocus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoFocus.Location = new System.Drawing.Point(157, 100);
            this.cbAutoFocus.Name = "cbAutoFocus";
            this.cbAutoFocus.Size = new System.Drawing.Size(48, 17);
            this.cbAutoFocus.TabIndex = 18;
            this.cbAutoFocus.Text = "Auto";
            this.cbAutoFocus.UseVisualStyleBackColor = true;
            this.cbAutoFocus.CheckedChanged += new System.EventHandler(this.cbAutoFocus_CheckedChanged);
            // 
            // cbAutoExp
            // 
            this.cbAutoExp.AutoSize = true;
            this.cbAutoExp.Checked = true;
            this.cbAutoExp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoExp.Location = new System.Drawing.Point(157, 26);
            this.cbAutoExp.Name = "cbAutoExp";
            this.cbAutoExp.Size = new System.Drawing.Size(48, 17);
            this.cbAutoExp.TabIndex = 19;
            this.cbAutoExp.Text = "Auto";
            this.cbAutoExp.UseVisualStyleBackColor = true;
            this.cbAutoExp.CheckedChanged += new System.EventHandler(this.cbAutoExp_CheckedChanged);
            // 
            // btnSetDist
            // 
            this.btnSetDist.Location = new System.Drawing.Point(12, 81);
            this.btnSetDist.Name = "btnSetDist";
            this.btnSetDist.Size = new System.Drawing.Size(188, 25);
            this.btnSetDist.TabIndex = 29;
            this.btnSetDist.Text = "Get distance";
            this.btnSetDist.UseVisualStyleBackColor = true;
            this.btnSetDist.Click += new System.EventHandler(this.button7_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Distance:";
            // 
            // lblDistmm
            // 
            this.lblDistmm.AutoSize = true;
            this.lblDistmm.Location = new System.Drawing.Point(60, 30);
            this.lblDistmm.Name = "lblDistmm";
            this.lblDistmm.Size = new System.Drawing.Size(53, 13);
            this.lblDistmm.TabIndex = 33;
            this.lblDistmm.Text = "Unknown";
            // 
            // gbCameraControl
            // 
            this.gbCameraControl.Controls.Add(this.tbFocus);
            this.gbCameraControl.Controls.Add(this.label4);
            this.gbCameraControl.Controls.Add(this.tbExp);
            this.gbCameraControl.Controls.Add(this.label5);
            this.gbCameraControl.Controls.Add(this.cbAutoFocus);
            this.gbCameraControl.Controls.Add(this.cbAutoExp);
            this.gbCameraControl.Location = new System.Drawing.Point(811, 352);
            this.gbCameraControl.Name = "gbCameraControl";
            this.gbCameraControl.Size = new System.Drawing.Size(213, 171);
            this.gbCameraControl.TabIndex = 36;
            this.gbCameraControl.TabStop = false;
            this.gbCameraControl.Text = "Alignment Camera Control";
            // 
            // gbGetDist
            // 
            this.gbGetDist.Controls.Add(this.label10);
            this.gbGetDist.Controls.Add(this.numProbeSize);
            this.gbGetDist.Controls.Add(this.label8);
            this.gbGetDist.Controls.Add(this.btnSetDist);
            this.gbGetDist.Controls.Add(this.lblBEstTrackingScore);
            this.gbGetDist.Controls.Add(this.label2);
            this.gbGetDist.Controls.Add(this.label7);
            this.gbGetDist.Controls.Add(this.lblDistmm);
            this.gbGetDist.Location = new System.Drawing.Point(811, 529);
            this.gbGetDist.Name = "gbGetDist";
            this.gbGetDist.Size = new System.Drawing.Size(213, 115);
            this.gbGetDist.TabIndex = 20;
            this.gbGetDist.TabStop = false;
            this.gbGetDist.Text = "Get Distance";
            this.gbGetDist.Enter += new System.EventHandler(this.gbGetDist_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(125, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "px";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Probe size:";
            // 
            // lblBEstTrackingScore
            // 
            this.lblBEstTrackingScore.AutoSize = true;
            this.lblBEstTrackingScore.Location = new System.Drawing.Point(156, 30);
            this.lblBEstTrackingScore.Name = "lblBEstTrackingScore";
            this.lblBEstTrackingScore.Size = new System.Drawing.Size(10, 13);
            this.lblBEstTrackingScore.TabIndex = 35;
            this.lblBEstTrackingScore.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Score:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1188, 24);
            this.menuStrip1.TabIndex = 38;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçõesToolStripMenuItem,
            this.rulerToolStripMenuItem,
            this.customCommandToolStripMenuItem,
            this.doseRateCalculatorToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.configToolStripMenuItem.Text = "Options";
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.configuraçõesToolStripMenuItem.Text = "Settings";
            this.configuraçõesToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesToolStripMenuItem_Click);
            // 
            // rulerToolStripMenuItem
            // 
            this.rulerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verticalToolStripMenuItem,
            this.horizontalToolStripMenuItem});
            this.rulerToolStripMenuItem.Name = "rulerToolStripMenuItem";
            this.rulerToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.rulerToolStripMenuItem.Text = "Ruler";
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.verticalToolStripMenuItem.Text = "Vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // customCommandToolStripMenuItem
            // 
            this.customCommandToolStripMenuItem.Name = "customCommandToolStripMenuItem";
            this.customCommandToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.customCommandToolStripMenuItem.Text = "Custom command";
            this.customCommandToolStripMenuItem.Click += new System.EventHandler(this.customCommandToolStripMenuItem_Click);
            // 
            // doseRateCalculatorToolStripMenuItem
            // 
            this.doseRateCalculatorToolStripMenuItem.Name = "doseRateCalculatorToolStripMenuItem";
            this.doseRateCalculatorToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.doseRateCalculatorToolStripMenuItem.Text = "Dose Rate Calculator";
            this.doseRateCalculatorToolStripMenuItem.Click += new System.EventHandler(this.doseRateCalculatorToolStripMenuItem_Click);
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.lblTemp);
            this.gbInfo.Controls.Add(this.lblPosA);
            this.gbInfo.Controls.Add(this.lblPosZ);
            this.gbInfo.Controls.Add(this.lblPosY);
            this.gbInfo.Controls.Add(this.lblPosX);
            this.gbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInfo.Location = new System.Drawing.Point(1030, 352);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(148, 171);
            this.gbInfo.TabIndex = 39;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Info";
            // 
            // lblPosZ
            // 
            this.lblPosZ.AutoSize = true;
            this.lblPosZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosZ.Location = new System.Drawing.Point(10, 141);
            this.lblPosZ.Name = "lblPosZ";
            this.lblPosZ.Size = new System.Drawing.Size(79, 24);
            this.lblPosZ.TabIndex = 2;
            this.lblPosZ.Text = "Z: 0 mm";
            // 
            // lblPosY
            // 
            this.lblPosY.AutoSize = true;
            this.lblPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosY.Location = new System.Drawing.Point(10, 117);
            this.lblPosY.Name = "lblPosY";
            this.lblPosY.Size = new System.Drawing.Size(79, 24);
            this.lblPosY.TabIndex = 1;
            this.lblPosY.Text = "Y: 0 mm";
            // 
            // lblPosX
            // 
            this.lblPosX.AutoSize = true;
            this.lblPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosX.Location = new System.Drawing.Point(10, 93);
            this.lblPosX.Name = "lblPosX";
            this.lblPosX.Size = new System.Drawing.Size(81, 24);
            this.lblPosX.TabIndex = 0;
            this.lblPosX.Text = "X: 0 mm";
            this.lblPosX.Click += new System.EventHandler(this.lblPosX_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::autoDif.Properties.Resources.logo_FEI;
            this.pictureBox2.Location = new System.Drawing.Point(1034, 543);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(142, 92);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 40;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.DoubleClick += new System.EventHandler(this.pictureBox2_DoubleClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(1003, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 104);
            this.button1.TabIndex = 14;
            this.button1.Text = "STOP\r\n\r\nEMERGENCY";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(163, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Dist. (Y)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Step (mm)";
            // 
            // gbAlign
            // 
            this.gbAlign.Controls.Add(this.cbAngComp);
            this.gbAlign.Controls.Add(this.btnToggleEnableA);
            this.gbAlign.Controls.Add(this.btnToggleEnableXYZ);
            this.gbAlign.Controls.Add(this.numStepLen);
            this.gbAlign.Controls.Add(this.label9);
            this.gbAlign.Controls.Add(this.label6);
            this.gbAlign.Controls.Add(this.label3);
            this.gbAlign.Controls.Add(this.btnStepBack);
            this.gbAlign.Controls.Add(this.btnStepForw);
            this.gbAlign.Controls.Add(this.btnStepDown);
            this.gbAlign.Controls.Add(this.btnStepUp);
            this.gbAlign.Controls.Add(this.btnStepLeft);
            this.gbAlign.Controls.Add(this.btnStepRight);
            this.gbAlign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAlign.Location = new System.Drawing.Point(811, 153);
            this.gbAlign.Name = "gbAlign";
            this.gbAlign.Size = new System.Drawing.Size(213, 193);
            this.gbAlign.TabIndex = 37;
            this.gbAlign.TabStop = false;
            this.gbAlign.Text = "Aim";
            this.gbAlign.Enter += new System.EventHandler(this.gbPosControl_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Alignment (X, Z)";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelCameraAux);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(773, 582);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Auxiliar";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelCameraAux
            // 
            this.panelCameraAux.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCameraAux.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelCameraAux.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCameraAux.Controls.Add(this.devicesComboAux);
            this.panelCameraAux.Controls.Add(this.connectAuxCameraBtn);
            this.panelCameraAux.Controls.Add(this.videoSourcePlayerAux);
            this.panelCameraAux.Location = new System.Drawing.Point(0, 0);
            this.panelCameraAux.Name = "panelCameraAux";
            this.panelCameraAux.Size = new System.Drawing.Size(773, 590);
            this.panelCameraAux.TabIndex = 9;
            this.panelCameraAux.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCameraAux_Paint);
            // 
            // devicesComboAux
            // 
            this.devicesComboAux.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devicesComboAux.FormattingEnabled = true;
            this.devicesComboAux.Location = new System.Drawing.Point(352, 8);
            this.devicesComboAux.Name = "devicesComboAux";
            this.devicesComboAux.Size = new System.Drawing.Size(329, 21);
            this.devicesComboAux.TabIndex = 1;
            this.devicesComboAux.SelectedIndexChanged += new System.EventHandler(this.devicesComboAux_SelectedIndexChanged);
            // 
            // connectAuxCameraBtn
            // 
            this.connectAuxCameraBtn.Location = new System.Drawing.Point(687, 8);
            this.connectAuxCameraBtn.Name = "connectAuxCameraBtn";
            this.connectAuxCameraBtn.Size = new System.Drawing.Size(79, 23);
            this.connectAuxCameraBtn.TabIndex = 6;
            this.connectAuxCameraBtn.Text = "Connect";
            this.connectAuxCameraBtn.UseVisualStyleBackColor = true;
            this.connectAuxCameraBtn.Click += new System.EventHandler(this.connectAuxCameraBtn_Click);
            // 
            // videoSourcePlayerAux
            // 
            this.videoSourcePlayerAux.AutoSizeControl = true;
            this.videoSourcePlayerAux.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSourcePlayerAux.ForeColor = System.Drawing.Color.DarkRed;
            this.videoSourcePlayerAux.KeepAspectRatio = true;
            this.videoSourcePlayerAux.Location = new System.Drawing.Point(224, 173);
            this.videoSourcePlayerAux.Name = "videoSourcePlayerAux";
            this.videoSourcePlayerAux.Size = new System.Drawing.Size(322, 242);
            this.videoSourcePlayerAux.TabIndex = 0;
            this.videoSourcePlayerAux.VideoSource = null;
            this.videoSourcePlayerAux.NewFrame += new Accord.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayerAux_NewFrame);
            this.videoSourcePlayerAux.Click += new System.EventHandler(this.videoSourcePlayerAux_Click);
            this.videoSourcePlayerAux.Paint += new System.Windows.Forms.PaintEventHandler(this.videoSourcePlayerAux_Paint);
            this.videoSourcePlayerAux.StyleChanged += new System.EventHandler(this.videoSourcePlayerAux_StyleChanged);
            // 
            // alignTab
            // 
            this.alignTab.Controls.Add(this.panelCameraAlign);
            this.alignTab.Location = new System.Drawing.Point(4, 22);
            this.alignTab.Name = "alignTab";
            this.alignTab.Padding = new System.Windows.Forms.Padding(3);
            this.alignTab.Size = new System.Drawing.Size(773, 582);
            this.alignTab.TabIndex = 0;
            this.alignTab.Text = "Alignment";
            this.alignTab.UseVisualStyleBackColor = true;
            // 
            // panelCameraAlign
            // 
            this.panelCameraAlign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCameraAlign.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelCameraAlign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelCameraAlign.Controls.Add(this.btnSampleSupport);
            this.panelCameraAlign.Controls.Add(this.devicesCombo);
            this.panelCameraAlign.Controls.Add(this.connectAlignCameraBtn);
            this.panelCameraAlign.Controls.Add(this.videoSourcePlayerAlign);
            this.panelCameraAlign.Location = new System.Drawing.Point(0, 0);
            this.panelCameraAlign.Name = "panelCameraAlign";
            this.panelCameraAlign.Size = new System.Drawing.Size(773, 582);
            this.panelCameraAlign.TabIndex = 8;
            this.panelCameraAlign.Click += new System.EventHandler(this.panel1_Click);
            this.panelCameraAlign.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // devicesCombo
            // 
            this.devicesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devicesCombo.FormattingEnabled = true;
            this.devicesCombo.Location = new System.Drawing.Point(352, 8);
            this.devicesCombo.Name = "devicesCombo";
            this.devicesCombo.Size = new System.Drawing.Size(329, 21);
            this.devicesCombo.TabIndex = 1;
            this.devicesCombo.SelectedIndexChanged += new System.EventHandler(this.devicesCombo_SelectedIndexChanged);
            // 
            // connectAlignCameraBtn
            // 
            this.connectAlignCameraBtn.Location = new System.Drawing.Point(687, 8);
            this.connectAlignCameraBtn.Name = "connectAlignCameraBtn";
            this.connectAlignCameraBtn.Size = new System.Drawing.Size(79, 23);
            this.connectAlignCameraBtn.TabIndex = 6;
            this.connectAlignCameraBtn.Text = "Connect";
            this.connectAlignCameraBtn.UseVisualStyleBackColor = true;
            this.connectAlignCameraBtn.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // videoSourcePlayerAlign
            // 
            this.videoSourcePlayerAlign.AutoSizeControl = true;
            this.videoSourcePlayerAlign.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSourcePlayerAlign.ForeColor = System.Drawing.Color.DarkRed;
            this.videoSourcePlayerAlign.Location = new System.Drawing.Point(225, 170);
            this.videoSourcePlayerAlign.Name = "videoSourcePlayerAlign";
            this.videoSourcePlayerAlign.Size = new System.Drawing.Size(322, 242);
            this.videoSourcePlayerAlign.TabIndex = 0;
            this.videoSourcePlayerAlign.VideoSource = null;
            this.videoSourcePlayerAlign.Click += new System.EventHandler(this.videoSourcePlayer_Click);
            this.videoSourcePlayerAlign.Paint += new System.Windows.Forms.PaintEventHandler(this.videoSourcePlayer_Paint);
            this.videoSourcePlayerAlign.DoubleClick += new System.EventHandler(this.videoSourcePlayerAlign_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.alignTab);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(781, 608);
            this.tabControl1.TabIndex = 41;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1188, 651);
            this.Controls.Add(this.gbPosit);
            this.Controls.Add(this.gbSerialConn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.gbAlign);
            this.Controls.Add(this.gbGetDist);
            this.Controls.Add(this.gbCameraControl);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(535, 440);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.gbSerialConn.ResumeLayout(false);
            this.gbSerialConn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numProbeSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStepLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetDist)).EndInit();
            this.gbPosit.ResumeLayout(false);
            this.gbPosit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFocus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbExp)).EndInit();
            this.gbCameraControl.ResumeLayout(false);
            this.gbCameraControl.PerformLayout();
            this.gbGetDist.ResumeLayout(false);
            this.gbGetDist.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbAlign.ResumeLayout(false);
            this.gbAlign.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panelCameraAux.ResumeLayout(false);
            this.alignTab.ResumeLayout(false);
            this.panelCameraAlign.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TrackBar tbFocus;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbExp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbAutoFocus;
        private System.Windows.Forms.CheckBox cbAutoExp;
        private System.Windows.Forms.Button btnSerialConnect;
        private System.Windows.Forms.Button btnSetDist;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDistmm;
        private System.Windows.Forms.GroupBox gbCameraControl;
        private System.Windows.Forms.GroupBox gbGetDist;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblPosA;
        private System.Windows.Forms.Label lblPosZ;
        private System.Windows.Forms.Label lblPosY;
        private System.Windows.Forms.Label lblPosX;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbSerialConn;
        private System.Windows.Forms.ComboBox cbComPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefreshCOMList;
        private System.Windows.Forms.Label lblBEstTrackingScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numProbeSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnStepRight;
        private System.Windows.Forms.Button btnStepLeft;
        private System.Windows.Forms.Button btnStepUp;
        private System.Windows.Forms.Button btnStepDown;
        private System.Windows.Forms.Button btnStepForw;
        private System.Windows.Forms.Button btnStepBack;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numStepLen;
        private System.Windows.Forms.Button btnGoToRadPos;
        private System.Windows.Forms.Button btnToggleEnableXYZ;
        private System.Windows.Forms.Button btnToggleEnableA;
        private System.Windows.Forms.CheckBox cbAngComp;
        private System.Windows.Forms.GroupBox gbAlign;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbPosit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numTargetDist;
        private System.Windows.Forms.RadioButton rbAutoPos;
        private System.Windows.Forms.RadioButton rbAutoManual;
        private System.Windows.Forms.ComboBox cbSampleSupport;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblOffsetZ;
        private System.Windows.Forms.Label lblOffsetY;
        private System.Windows.Forms.Label lblOffsetX;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ToolStripMenuItem rulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panelCameraAux;
        private System.Windows.Forms.ComboBox devicesComboAux;
        private System.Windows.Forms.Button connectAuxCameraBtn;
        private Accord.Controls.VideoSourcePlayer videoSourcePlayerAux;
        private System.Windows.Forms.TabPage alignTab;
        private System.Windows.Forms.Panel panelCameraAlign;
        private System.Windows.Forms.Button btnSampleSupport;
        private System.Windows.Forms.ComboBox devicesCombo;
        private System.Windows.Forms.Button connectAlignCameraBtn;
        private Accord.Controls.VideoSourcePlayer videoSourcePlayerAlign;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem customCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doseRateCalculatorToolStripMenuItem;
    }
}

