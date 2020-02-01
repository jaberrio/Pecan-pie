using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Speech.Recognition;

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
            Application.Idle += new EventHandler(delegate (object ss, EventArgs ee)
            {
               viewer.Image = capture.QueryFrame();
            });
            viewer.ShowDialog();
        }

        private void speechtest(object sender, EventArgs e)
        {
            SpeechRecognize recognizerA = new SpeechRecognize();
            recognizerA.recognizeB.SpeechRecognized += recognize_SpeechRecognized;
        }

        void recognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        { 
            switch (e.Result.Text)
            {
                case "test":
                    Console.WriteLine("Success");
                    break;

                case "hello":
                    Console.WriteLine("hello heard");
                    break;

            }
        }
    }
    
}
