namespace autoDif
{
    partial class sampleSupportPanel
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
            this.gbAng = new System.Windows.Forms.GroupBox();
            this.btnSetAng = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStepLeft = new System.Windows.Forms.Button();
            this.btnStepRight = new System.Windows.Forms.Button();
            this.numAngStep = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearAng = new System.Windows.Forms.Button();
            this.numAng = new System.Windows.Forms.NumericUpDown();
            this.gbAng.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAngStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAng)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAng
            // 
            this.gbAng.Controls.Add(this.btnSetAng);
            this.gbAng.Controls.Add(this.label2);
            this.gbAng.Controls.Add(this.btnStepLeft);
            this.gbAng.Controls.Add(this.btnStepRight);
            this.gbAng.Controls.Add(this.numAngStep);
            this.gbAng.Controls.Add(this.label1);
            this.gbAng.Controls.Add(this.btnClearAng);
            this.gbAng.Controls.Add(this.numAng);
            this.gbAng.Location = new System.Drawing.Point(12, 12);
            this.gbAng.Name = "gbAng";
            this.gbAng.Size = new System.Drawing.Size(249, 163);
            this.gbAng.TabIndex = 1;
            this.gbAng.TabStop = false;
            this.gbAng.Text = "Set Angle";
            this.gbAng.Enter += new System.EventHandler(this.gbAng_Enter);
            // 
            // btnSetAng
            // 
            this.btnSetAng.Location = new System.Drawing.Point(127, 46);
            this.btnSetAng.Name = "btnSetAng";
            this.btnSetAng.Size = new System.Drawing.Size(55, 35);
            this.btnSetAng.TabIndex = 8;
            this.btnSetAng.Text = "Move";
            this.btnSetAng.UseVisualStyleBackColor = true;
            this.btnSetAng.Click += new System.EventHandler(this.btnSetAng_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Angle (°)";
            // 
            // btnStepLeft
            // 
            this.btnStepLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStepLeft.Location = new System.Drawing.Point(127, 123);
            this.btnStepLeft.Name = "btnStepLeft";
            this.btnStepLeft.Size = new System.Drawing.Size(52, 26);
            this.btnStepLeft.TabIndex = 6;
            this.btnStepLeft.Text = "←";
            this.btnStepLeft.UseVisualStyleBackColor = true;
            this.btnStepLeft.Click += new System.EventHandler(this.btnStepLeft_Click);
            // 
            // btnStepRight
            // 
            this.btnStepRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStepRight.Location = new System.Drawing.Point(188, 123);
            this.btnStepRight.Name = "btnStepRight";
            this.btnStepRight.Size = new System.Drawing.Size(52, 26);
            this.btnStepRight.TabIndex = 5;
            this.btnStepRight.Text = "→";
            this.btnStepRight.UseVisualStyleBackColor = true;
            this.btnStepRight.Click += new System.EventHandler(this.btnStepRight_Click);
            // 
            // numAngStep
            // 
            this.numAngStep.DecimalPlaces = 1;
            this.numAngStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAngStep.Location = new System.Drawing.Point(15, 123);
            this.numAngStep.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numAngStep.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.numAngStep.Name = "numAngStep";
            this.numAngStep.Size = new System.Drawing.Size(104, 26);
            this.numAngStep.TabIndex = 4;
            this.numAngStep.Tag = "";
            this.numAngStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numAngStep.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Step (°)";
            // 
            // btnClearAng
            // 
            this.btnClearAng.Location = new System.Drawing.Point(188, 46);
            this.btnClearAng.Name = "btnClearAng";
            this.btnClearAng.Size = new System.Drawing.Size(55, 35);
            this.btnClearAng.TabIndex = 2;
            this.btnClearAng.Text = "Reset";
            this.btnClearAng.UseVisualStyleBackColor = true;
            // 
            // numAng
            // 
            this.numAng.DecimalPlaces = 1;
            this.numAng.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAng.Location = new System.Drawing.Point(15, 46);
            this.numAng.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numAng.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numAng.Name = "numAng";
            this.numAng.Size = new System.Drawing.Size(106, 35);
            this.numAng.TabIndex = 1;
            this.numAng.Tag = "";
            this.numAng.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numAng.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // sampleSupportPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 185);
            this.Controls.Add(this.gbAng);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "sampleSupportPanel";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sample Support Control";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.sampleSupportPanel_Load);
            this.gbAng.ResumeLayout(false);
            this.gbAng.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAngStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAng)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbAng;
        private System.Windows.Forms.Button btnClearAng;
        private System.Windows.Forms.NumericUpDown numAng;
        private System.Windows.Forms.NumericUpDown numAngStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStepLeft;
        private System.Windows.Forms.Button btnStepRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSetAng;
    }
}