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
    public partial class CustomCmd : Form
    {
        public CustomCmd()
        {
            InitializeComponent();
        }
         
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtCmd.Text.Length > 0) MainForm.sendCmd(txtCmd.Text);
        }
    }
}
