using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace autoDif
{
    public partial class config : Form
    {
       

        public config()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            config.ActiveForm.Close();
        }


        private void config_Load(object sender, EventArgs e)
        {
            txtCamBeamOffHor.Text = Machine.cameraToXRayHorOffset.ToString();
            txtCamBeamOffVert.Text = Machine.cameraToXRayVerOffset.ToString();

            txtMinDistSmall.Text = Machine.directPosMinDistSmall.ToString();
            txtMinDistHeavy.Text = Machine.directPosMinDistHeavy.ToString();

            txtFOVAng.Text = Machine.cameraHalfAng.ToString();
            txtSenLensOff.Text = Machine.lensToSensorOffset.ToString();

            txtCalibDist.Text = Machine.doseRateCalibDist.ToString();
            txtVolt.Text = Machine.doseRateCalibVolt.ToString();
            txtCoefA.Text = Machine.doseRateCoefA.ToString();
            txtCoefB.Text = Machine.doseRateCoefB.ToString();



        }

        void saveSettings()
        {
            try
            {
                Machine.cameraToXRayHorOffset = Convert.ToDouble(txtCamBeamOffHor.Text);
                Machine.cameraToXRayVerOffset = Convert.ToDouble(txtCamBeamOffVert.Text);

                Machine.directPosMinDistSmall = Convert.ToDouble(txtMinDistSmall.Text);
                Machine.directPosMinDistHeavy = Convert.ToDouble(txtMinDistHeavy.Text);


                Machine.cameraHalfAng = Convert.ToDouble(txtFOVAng.Text);
                Machine.lensToSensorOffset = Convert.ToDouble(txtSenLensOff.Text);

                Machine.doseRateCalibDist = Convert.ToDouble(txtCalibDist.Text);
                Machine.doseRateCalibVolt = Convert.ToDouble(txtVolt.Text);
                Machine.doseRateCoefA = Convert.ToDouble(txtCoefA.Text);
                Machine.doseRateCoefB = Convert.ToDouble(txtCoefB.Text);



                MainForm.saveConfig();
            }
            catch
            {
                MessageBox.Show("Invalid values!");
            }
            

        }

        private void btnHelpConfig1_Click(object sender, EventArgs e)
        {
            tutorialForm t = new tutorialForm(0);
            t.ShowDialog();
        }

        private void btnHelpConfig2_Click(object sender, EventArgs e)
        {
            tutorialForm t = new tutorialForm(1);
            t.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tutorialForm t = new tutorialForm(2);
            t.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tutorialForm t = new tutorialForm(3);
            t.ShowDialog();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            saveSettings();
        }
    }
}
