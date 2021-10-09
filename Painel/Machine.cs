using System;
using System.Collections.Generic;
using System.Text;



namespace autoDif
{

    //Armazena todas as varíaveis de estado da máquina
    public static class Machine
    {

        public static bool machineReady = true; //False se máquina estiver execuntado alguma ação / impede que outros cmds sejam enviados
        public static bool sampleInPos = false; //True se a amostra estiver posicionada no raio-X, falso para modo de ajuste

        public static Vector3D pos = new Vector3D(); //Posição atual
        public static Vector3D lastPos = new Vector3D(); //Posição anterior
        public static Vector3D targetPos = new Vector3D(); //Posição alvo - de irradiação

        public static Vector3D alignmentPos = new Vector3D(); // Posição inicial de alinhamento

        public static double angA = 0; //Ângulo do suporte

        public static double rawSampleDist = 0; //Distância do foco da câmera até a amostra

        public static double distStDev = 0;
        public static double sampleDist() //Distância do raio-X até a amostra
        {
            return rawSampleDist - lensToSensorOffset - cameraToXRayHorOffset;
        }

        public static double targetSampleDist = 0;
        public static double rawSampleTargetDist() //Distância alvo - foco até amostra
        {
            return targetSampleDist + lensToSensorOffset + cameraToXRayHorOffset;
        }

        public static bool isSampleDistSet = false;

        public static double angVelA = 0;
        public static bool constRotA = false;

        public static double temperature = 0; //Temperatura

        public static bool isMotorEnabledA = false; //Motor A ligado/desligado
        public static bool isMotorEnabledXYZ = false; //Motores XYZ ligados/desligados

        //Limit Switch: -1, 0 ou 1 
        public static int limitSwitchX = 0;
        public static int limitSwitchY = 0;
        public static int limitSwitchZ = 0;



        // ====== Configs =======

        //Câmera - resolução
        public static int cameraWidth = 1920;
        public static int cameraHeight = 1080;


        public static double lensToSensorOffset = 4.8327; //(mm) Distância entre lente da camera (vidro frontal) e vertice do ângulo de visão 

        public static double cameraHalfAng = 33.615;//33.46366; //Metade do ângulo da câmera (Graus)

        public static double cameraToXRayHorOffset = 49; // (mm) Distância horizontal entre câmera e raio-X (Paralela ao feixe)
        public static double cameraToXRayVerOffset = 88.5; //(mm) Distância vertical entre câmera e raio-X (Perpendicular ao solo)

        public static double beamAngle = 6; //Angulo da linha central do raio-x em relação a base (Graus)


        //Fatores de ajuste para calculo da projeção do Raio-X
        // altura = dist * projHAdjFacA + projHAdjFacB

        //altura
        public static double projHeightAdjFacA = 0.072;
        public static double projHeightAdjFacB = 5.502;

        //largura total
        public static double projWidthAdjFacA = 0.048;
        public static double projWidthAdjFacB = 13.518;

        //largura útil
        public static double projUWidthAdjFacA = 0.04;
        public static double projUWidthAdjFacB = 5.34;

        //Cálculo de dose
        public static double doseRateCalibDist = 120; //(mm) Distância de calibração da dose
        public static double doseRateCalibVolt = 20; //(kV) Tensão do Raio X de calibração da dose
        public static double doseRateCoefA = 3.8294;
        public static double doseRateCoefB = -1.2154;



        // Distâncias / Limites (Posicionamento da amostra)

        public static double directPosMinDistSmall = 210; // (Amostra Pequena) Distância mínima permitida para posicionamento direto da amostra (Único movimento vertical)
        public static double directPosMinDistHeavy = 140; // (Placa pesada) Distância mínima permitida para posicionamento direto da amostra (Único movimento vertical)
        public static int sampleSupportConfig = (int)sampleSupportConfigList.SMALL; //Define configuração do suporte de amostra
        public static bool manualPosMode = false; //Define modo de posicionamento manual
        public static bool autoPos = true;

         
        public enum sampleSupportConfigList : int
        {
            SMALL = 0, //Suporte pequeno
            HEAVY = 1 //Suporte grande
        }


        //Funcs

        public static Vector3D targetOffset()
        {
            Vector3D v = targetPos.copy();
            v.sub(pos);
            v.mult(-1);

            return v;
        }


        public static double mmPerPixel(double d)
        {
            return Math.Tan(cameraHalfAng / 180 * Math.PI) * d / (cameraWidth / 2);
        }

        public static double mmPerPixel()
        {
            return Math.Tan(cameraHalfAng / 180 * Math.PI) * rawSampleDist / (cameraWidth / 2);
        }

        public static double projHeigth()
        {
            return (targetSampleDist * projHeightAdjFacA + projHeightAdjFacB) / mmPerPixel(rawSampleDist);
        }

        public static double projUWidth()
        {
            return (targetSampleDist * projUWidthAdjFacA + projUWidthAdjFacB) / mmPerPixel(rawSampleDist);
        }

        public static double projTWidth()
        {
            return (targetSampleDist * projWidthAdjFacA + projWidthAdjFacB) / mmPerPixel(rawSampleDist);
        }

        public static double angCompAdv(double step)
        {
            double angRad = beamAngle * Math.PI / 180;

            return Math.Tan(angRad) * step;
        }
    }
}
