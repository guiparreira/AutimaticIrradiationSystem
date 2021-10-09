
namespace autoDif
{
    partial class DoseRateCalculator
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
            this.lblVoltage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIrradDist = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numDoseRate = new System.Windows.Forms.NumericUpDown();
            this.numCurr = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numDoseRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurr)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVoltage
            // 
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoltage.Location = new System.Drawing.Point(12, 9);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(141, 18);
            this.lblVoltage.TabIndex = 0;
            this.lblVoltage.Text = "X-Ray Voltage: -- kV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dose Rate:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(159, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "[krad/h] -> Si";
            // 
            // lblIrradDist
            // 
            this.lblIrradDist.AutoSize = true;
            this.lblIrradDist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIrradDist.Location = new System.Drawing.Point(12, 89);
            this.lblIrradDist.Name = "lblIrradDist";
            this.lblIrradDist.Size = new System.Drawing.Size(111, 18);
            this.lblIrradDist.TabIndex = 4;
            this.lblIrradDist.Text = "Irrad. Distance: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(162, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "[mA]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Current:";
            // 
            // numDoseRate
            // 
            this.numDoseRate.DecimalPlaces = 1;
            this.numDoseRate.Location = new System.Drawing.Point(92, 39);
            this.numDoseRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numDoseRate.Name = "numDoseRate";
            this.numDoseRate.Size = new System.Drawing.Size(61, 20);
            this.numDoseRate.TabIndex = 7;
            this.numDoseRate.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numDoseRate.ValueChanged += new System.EventHandler(this.numDoseRate_ValueChanged);
            // 
            // numCurr
            // 
            this.numCurr.DecimalPlaces = 1;
            this.numCurr.Location = new System.Drawing.Point(92, 63);
            this.numCurr.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numCurr.Name = "numCurr";
            this.numCurr.Size = new System.Drawing.Size(61, 20);
            this.numCurr.TabIndex = 8;
            this.numCurr.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numCurr.ValueChanged += new System.EventHandler(this.numCurr_ValueChanged);
            // 
            // DoseRateCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 120);
            this.Controls.Add(this.numCurr);
            this.Controls.Add(this.numDoseRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblIrradDist);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblVoltage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "DoseRateCalculator";
            this.Text = "Dose Rate Calculator";
            this.Load += new System.EventHandler(this.DoseRateCalculator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDoseRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIrradDist;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numDoseRate;
        private System.Windows.Forms.NumericUpDown numCurr;
    }
}