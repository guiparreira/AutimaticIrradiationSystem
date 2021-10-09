using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace autoDif
{
    public partial class tutorialForm : Form
    {

        public int tutorialID;
        

        public tutorialForm(int ID)
        {
            InitializeComponent();
            tutorialID = ID;
        }

        public void loadImage(string fileName)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("autoDif.Tutorials."+ fileName);
            pbTutorialImg.Image = new Bitmap(stream);
            pbTutorialImg.Size = pbTutorialImg.Image.Size;
            this.Size = pbTutorialImg.Size;
        }
        private void tutorialForm_Load(object sender, EventArgs e)
        {
            switch(tutorialID)
            {
                //CamBeamVet
                case 0:
                    loadImage("camBeamVert.png");
                    this.Text = "Camera-Beam Vertical Offset";
                    break;

                //CamBeamHor
                case 1:
                    loadImage("camBeamHor.png");
                    this.Text = "Camera-Beam Horizontal Offset";
                    break;

                //Min Dist Small
                case 2:
                    loadImage("minDistSmallSupp.png");
                    this.Text = "Minimum distance allowed for auto-positioning (Small Samples)";
                    break;

                //Min Dist Heavy
                case 3:
                    loadImage("minDistHeavySupp.png");
                    this.Text = "Minimum distance allowed for auto-positioning (Heavy Samples)";
                    break;

            }
        }
    }
}
