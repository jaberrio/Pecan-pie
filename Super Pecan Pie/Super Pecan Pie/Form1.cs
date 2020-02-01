using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace Super_Pecan_Pie
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

            
        }



        private void laodDataBase(object sender, EventArgs e)
        {
            ActDataB dataB = new ActDataB();
            List<Accident> test = dataB.getAccidentsNearBy(29.626945f, -82.372390f, 0.02414016f);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ImageViewer viewer = new ImageViewer();
            VideoCapture capture = new VideoCapture();
            Application.Idle += new EventHandler(delegate (object sender, EventArgs e)
            {
                viewer.Image = capture.QueryFrame();
            });
            viewer.ShowDialog();
        }
    }
    
}
