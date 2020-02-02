using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Device.Location;
using System.Threading;

namespace Super_Pecan_Pie
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            var functions = new functions1();
            GeoCoordinate coord = functions1.GetLocationProperty();
            string APIREQUEST;
            APIREQUEST = functions.API_request(coord, "Disneyland");
            ActDataB dataB = new ActDataB();
            List<Accident> test = dataB.getAccidentsNearBy(29.626945f, -82.372390f, 0.02414016f);
            List<Accident> danger = dataB.dangerSpots();
            functions.API_Call(APIREQUEST, danger);

        }



        private void laodDataBase(object sender, EventArgs e)
        {
        
            //dataB.findCrashesForAllPoints();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            /*
            ImageViewer viewer = new ImageViewer();
            VideoCapture capture = new VideoCapture();
            Application.Idle += new EventHandler(delegate (object ss, EventArgs ee)
            {
               viewer.Image = capture.QueryFrame();
            });
            viewer.ShowDialog();
            CascadeClassifier c = new CascadeClassifier("Files/cars.xml");*/
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

        private void synthesistest(object sender, EventArgs e)
        {
            SpeechSynthesize synthesizerA = new SpeechSynthesize();
        }
        private void vidFeed_Click(object sender, EventArgs e)
        {
            openCV f = new openCV();
            f.findImages();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var functions = new functions1();
            //functions.GetLocation();
        }

    }
    
}
