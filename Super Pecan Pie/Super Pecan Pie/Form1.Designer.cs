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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.vidFeed = new System.Windows.Forms.Button();
            this.imagesInBackground = new System.Windows.Forms.Button();
            this.testLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 72);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(416, 196);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load Data Base";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.laodDataBase);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(123, 439);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(416, 64);
            this.button2.TabIndex = 2;
            this.button2.Text = "Test Speech Recognizer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.speechtest);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(123, 321);
            this.button3.Margin = new System.Windows.Forms.Padding(5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(416, 64);
            this.button3.TabIndex = 3;
            this.button3.Text = "Test Speech Synthesis";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.synthesistest);
            // 
            // vidFeed
            // 
            this.vidFeed.Location = new System.Drawing.Point(961, 72);
            this.vidFeed.Margin = new System.Windows.Forms.Padding(5);
            this.vidFeed.Name = "vidFeed";
            this.vidFeed.Size = new System.Drawing.Size(357, 103);
            this.vidFeed.TabIndex = 2;
            this.vidFeed.Text = "START VIDEO FEED";
            this.vidFeed.UseVisualStyleBackColor = true;
            this.vidFeed.Click += new System.EventHandler(this.vidFeed_Click);
            // 
            // imagesInBackground
            // 
            this.imagesInBackground.Location = new System.Drawing.Point(961, 241);
            this.imagesInBackground.Name = "imagesInBackground";
            this.imagesInBackground.Size = new System.Drawing.Size(357, 99);
            this.imagesInBackground.TabIndex = 4;
            this.imagesInBackground.Text = "Run Images In Background";
            this.imagesInBackground.UseVisualStyleBackColor = true;
            this.imagesInBackground.Click += new System.EventHandler(this.imagesInBackground_Click);
            // 
            // testLabel
            // 
            this.testLabel.AutoSize = true;
            this.testLabel.Location = new System.Drawing.Point(1039, 470);
            this.testLabel.Name = "testLabel";
            this.testLabel.Size = new System.Drawing.Size(70, 32);
            this.testLabel.TabIndex = 5;
            this.testLabel.Text = "Test";
            this.testLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 873);
            this.Controls.Add(this.testLabel);
            this.Controls.Add(this.imagesInBackground);
            this.Controls.Add(this.vidFeed);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button vidFeed;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button imagesInBackground;
        private System.Windows.Forms.Label testLabel;
    }
}

