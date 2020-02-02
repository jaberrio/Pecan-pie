namespace Super_Pecan_Pie
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.vidFeed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 271);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "This is text <3";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 30);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 82);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load Data Base";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.laodDataBase);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(155, 16);
            this.button2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 16);
            this.button2.TabIndex = 2;
            this.button2.Text = "Test Speech";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.speechtest);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(155, 41);
            this.button3.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 17);
            this.button3.TabIndex = 3;
            this.button3.Text = "Test Synthesis";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.synthesistest);
            // 
            // vidFeed
            // 
            this.vidFeed.Location = new System.Drawing.Point(322, 30);
            this.vidFeed.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.vidFeed.Name = "vidFeed";
            this.vidFeed.Size = new System.Drawing.Size(134, 82);
            this.vidFeed.TabIndex = 2;
            this.vidFeed.Text = "START VIDEO FEED";
            this.vidFeed.UseVisualStyleBackColor = true;
            this.vidFeed.Click += new System.EventHandler(this.vidFeed_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.vidFeed);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button vidFeed;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

