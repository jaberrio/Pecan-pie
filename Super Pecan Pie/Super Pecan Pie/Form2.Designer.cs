using System.Drawing;

namespace Super_Pecan_Pie
{
    partial class Form2
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
        public void updateDriver(int i)
        {
            if (i == 1)
            {
                caution.Image = Image.FromFile("images/decline.png");
                label1.Text = "LEFT";
            }
            if (i == 2)
            {
                caution.Image = Image.FromFile("images/decline.png");
                label1.Text = "RIGHT";
            }
            if (i ==3)
            {
                caution.Image = Image.FromFile("images/decline.png");
                label1.Text = "Forward";
            }
            if (i == 4)
            {
                caution.Image = Image.FromFile("images/decline.png");
                label1.Text = "Backward";
            }
            System.Threading.Thread.Sleep(3000);
            caution.Image = null;
            label1.Text = "";
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.caution = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.caution)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM11";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // caution
            // 
            this.caution.Location = new System.Drawing.Point(552, 100);
            this.caution.Name = "caution";
            this.caution.Size = new System.Drawing.Size(688, 594);
            this.caution.TabIndex = 0;
            this.caution.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Impact", 27.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(678, 651);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 115);
            this.label1.TabIndex = 1;
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(2007, 1104);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.caution);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.RegionChanged += new System.EventHandler(this.Form2_RegionChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.caution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox caution;
        private System.Windows.Forms.Label label1;
    }
}