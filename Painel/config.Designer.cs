namespace autoDif
{
    partial class config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCamBeamOffVert = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMinDistHeavy = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMinDistSmall = new System.Windows.Forms.TextBox();
            this.btnHelpConfig2 = new System.Windows.Forms.Button();
            this.btnHelpConfig1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCamBeamOffHor = new System.Windows.Forms.TextBox();
            this.txtSenLensOff = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFOVAng = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCoefA = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCoefB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCalibDist = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtVolt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(93, 205);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 26);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Apply";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "• Camera-Beam Vert.";
            // 
            // txtCamBeamOffVert
            // 
            this.txtCamBeamOffVert.Location = new System.Drawing.Point(115, 21);
            this.txtCamBeamOffVert.Name = "txtCamBeamOffVert";
            this.txtCamBeamOffVert.Size = new System.Drawing.Size(56, 20);
            this.txtCamBeamOffVert.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMinDistHeavy);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMinDistSmall);
            this.groupBox1.Controls.Add(this.btnHelpConfig2);
            this.groupBox1.Controls.Add(this.btnHelpConfig1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCamBeamOffHor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCamBeamOffVert);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 129);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Offsets (mm)";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(177, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(21, 20);
            this.button2.TabIndex = 14;
            this.button2.Text = "?";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "• Min. Dist. Heavy";
            // 
            // txtMinDistHeavy
            // 
            this.txtMinDistHeavy.Location = new System.Drawing.Point(115, 99);
            this.txtMinDistHeavy.Name = "txtMinDistHeavy";
            this.txtMinDistHeavy.Size = new System.Drawing.Size(56, 20);
            this.txtMinDistHeavy.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 20);
            this.button1.TabIndex = 11;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "• Min. Dist. Small";
            // 
            // txtMinDistSmall
            // 
            this.txtMinDistSmall.Location = new System.Drawing.Point(115, 73);
            this.txtMinDistSmall.Name = "txtMinDistSmall";
            this.txtMinDistSmall.Size = new System.Drawing.Size(56, 20);
            this.txtMinDistSmall.TabIndex = 10;
            // 
            // btnHelpConfig2
            // 
            this.btnHelpConfig2.Location = new System.Drawing.Point(177, 46);
            this.btnHelpConfig2.Name = "btnHelpConfig2";
            this.btnHelpConfig2.Size = new System.Drawing.Size(21, 20);
            this.btnHelpConfig2.TabIndex = 8;
            this.btnHelpConfig2.Text = "?";
            this.btnHelpConfig2.UseVisualStyleBackColor = true;
            this.btnHelpConfig2.Click += new System.EventHandler(this.btnHelpConfig2_Click);
            // 
            // btnHelpConfig1
            // 
            this.btnHelpConfig1.Location = new System.Drawing.Point(177, 19);
            this.btnHelpConfig1.Name = "btnHelpConfig1";
            this.btnHelpConfig1.Size = new System.Drawing.Size(21, 20);
            this.btnHelpConfig1.TabIndex = 7;
            this.btnHelpConfig1.Text = "?";
            this.btnHelpConfig1.UseVisualStyleBackColor = true;
            this.btnHelpConfig1.Click += new System.EventHandler(this.btnHelpConfig1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "• Camera-Beam Hor.";
            // 
            // txtCamBeamOffHor
            // 
            this.txtCamBeamOffHor.Location = new System.Drawing.Point(115, 47);
            this.txtCamBeamOffHor.Name = "txtCamBeamOffHor";
            this.txtCamBeamOffHor.Size = new System.Drawing.Size(56, 20);
            this.txtCamBeamOffHor.TabIndex = 4;
            // 
            // txtSenLensOff
            // 
            this.txtSenLensOff.Location = new System.Drawing.Point(111, 48);
            this.txtSenLensOff.Name = "txtSenLensOff";
            this.txtSenLensOff.Size = new System.Drawing.Size(75, 20);
            this.txtSenLensOff.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "• Sensor-Lens Offset";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFOVAng);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtSenLensOff);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(224, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 80);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Aligmnent Camera";
            // 
            // txtFOVAng
            // 
            this.txtFOVAng.Location = new System.Drawing.Point(111, 21);
            this.txtFOVAng.Name = "txtFOVAng";
            this.txtFOVAng.Size = new System.Drawing.Size(75, 20);
            this.txtFOVAng.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "• FOV Angle (Deg.)";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 205);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtVolt);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtCalibDist);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtCoefA);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtCoefB);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(224, 98);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(196, 133);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dose rate Calc.";
            // 
            // txtCoefA
            // 
            this.txtCoefA.Location = new System.Drawing.Point(111, 75);
            this.txtCoefA.Name = "txtCoefA";
            this.txtCoefA.Size = new System.Drawing.Size(75, 20);
            this.txtCoefA.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(92, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "a";
            // 
            // txtCoefB
            // 
            this.txtCoefB.Location = new System.Drawing.Point(111, 102);
            this.txtCoefB.Name = "txtCoefB";
            this.txtCoefB.Size = new System.Drawing.Size(75, 20);
            this.txtCoefB.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(92, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "b";
            // 
            // txtCalibDist
            // 
            this.txtCalibDist.Location = new System.Drawing.Point(111, 23);
            this.txtCalibDist.Name = "txtCalibDist";
            this.txtCalibDist.Size = new System.Drawing.Size(75, 20);
            this.txtCalibDist.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "• Calib. Dist. (mm)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "D\' (I) = a * I + b";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(124, 153);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "D\' [krad/h] em Si";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(124, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "I [mA]";
            // 
            // txtVolt
            // 
            this.txtVolt.Location = new System.Drawing.Point(111, 48);
            this.txtVolt.Name = "txtVolt";
            this.txtVolt.Size = new System.Drawing.Size(75, 20);
            this.txtVolt.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "• X-Ray Volt. (kV)";
            // 
            // config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 237);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.config_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCamBeamOffVert;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSenLensOff;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCamBeamOffHor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFOVAng;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnHelpConfig2;
        private System.Windows.Forms.Button btnHelpConfig1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMinDistHeavy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMinDistSmall;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtVolt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCalibDist;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCoefA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCoefB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}