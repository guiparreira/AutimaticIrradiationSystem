using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoDif
{
    public partial class DoseRateCalculator : Form
    {
        public DoseRateCalculator()
        {
            InitializeComponent();
        }

        private void DoseRateCalculator_Load(object sender, EventArgs e)
        {
            update();
        }

        void update()
        {

            double tgCurrent = (double)numCurr.Value;
            double tgDose = (double)numDoseRate.Value;

            double baseDose = tgCurrent * Machine.doseRateCoefA + Machine.doseRateCoefB;


            double irradDist = Machine.doseRateCalibDist * Machine.doseRateCalibDist * baseDose / tgDose;
            irradDist = Math.Sqrt(irradDist);

            lblVoltage.Text = "X-Ray Voltage: " + String.Format("{0:0}", Machine.doseRateCalibVolt) + " kV";
            lblIrradDist.Text = "Irrad. Distance: " + String.Format("{0:0}", irradDist) + " mm";
        }

        private void numDoseRate_ValueChanged(object sender, EventArgs e)
        {
            update();
        }

        private void numCurr_ValueChanged(object sender, EventArgs e)
        {
            update();
        }
    }
}
