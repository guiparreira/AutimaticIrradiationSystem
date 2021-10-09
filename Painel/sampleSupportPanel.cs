using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace autoDif
{
    public partial class sampleSupportPanel : Form
    {

        public sampleSupportPanel()
        {
            InitializeComponent();
        }


    
        private void sampleSupportPanel_Load(object sender, EventArgs e)
        {
            //lblAngVal.Text = Machine.angA + " °";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSetAng_Click(object sender, EventArgs e)
        {
            MainForm.sendAngleCmd(Convert.ToSingle(numAng.Value));
        }

        private void gbAng_Enter(object sender, EventArgs e)
        {

        }

        private void btnStepLeft_Click(object sender, EventArgs e)
        {
            MainForm.sendAngleCmd(Machine.angA - Convert.ToDouble(numAngStep.Value));
        }

        private void btnStepRight_Click(object sender, EventArgs e)
        {
            MainForm.sendAngleCmd(Machine.angA + Convert.ToDouble(numAngStep.Value));
        }
    }
}
