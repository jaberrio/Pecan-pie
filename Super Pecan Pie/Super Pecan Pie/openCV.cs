using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.Windows.Forms;

namespace Super_Pecan_Pie
{
    class openCV
    {

        public void findImages()
        {
            
            double scale = 5;
            int count = 0;

            CascadeClassifier car_Cascade = new CascadeClassifier("Files/cars.xml");
            /* if (!vid1.IsOpened)
             {
                 Console.WriteLine("v1 video not read");
             }*/


            ImageViewer viewer1 = new ImageViewer();
            ImageViewer viewer2 = new ImageViewer();
            ImageViewer viewer3 = new ImageViewer();
            ImageViewer viewer4 = new ImageViewer();
            VideoCapture capture1 = new VideoCapture(1);
            VideoCapture capture2= new VideoCapture(2);
            VideoCapture capture3 = new VideoCapture(3);
            VideoCapture capture4 = new VideoCapture(4);
            Mat frame1 = capture1.QueryFrame();
            Mat frame2 = capture2.QueryFrame();
            Mat frame3 = capture3.QueryFrame();
            Mat frame4 = capture4.QueryFrame();

            Application.Idle += new EventHandler(delegate (object ss, EventArgs ee)
            {
                
                
                capture1.Read(frame1);
                capture2.Read(frame2);
                capture3.Read(frame3);
                capture4.Read(frame4);
                //viewer.Image = capture.QueryFrame();
                detectAndDraw( frame1, car_Cascade, scale, count, "cam1");
                detectAndDraw(frame2, car_Cascade, scale, count,"cam2");
                detectAndDraw(frame3, car_Cascade, scale, count,"cam3");
                detectAndDraw(frame4, car_Cascade, scale, count,"cam4");


            });
            
            //Mat frame1 = new Mat();
            //IImage frame1 = new Mat();
            //Mat frame2;
            //Mat frame3 = new Mat();
            //Mat frame4 = new Mat();
            //double scale = 5;
            ////int count = 0;
            
           

            //VideoCapture vid1 = new VideoCapture(0);
            //VideoCapture vid2 = new VideoCapture(0);
            //VideoCapture vid3 = new VideoCapture(2);
            //VideoCapture vid4 = new VideoCapture(3);


            
            /*if (!vid2.IsOpened)
            {
                Console.WriteLine("v2 video not read");
            }
            if (!vid3.IsOpened)
            {
                Console.WriteLine("v3 video not read");
            }
            if (!vid4.IsOpened)
            {
                Console.WriteLine("v4 video not read");
            }*/
            /*ImageViewer m_frmSourceImage = new ImageViewer(frame1, "Original Image");
            while (true)
            {
                vid1.Read(frame1);
                //vid1.Read(frame2);
                //vid1.Read(frame3);
                //vid1.Read(frame4);
                
                //CvInvoke.Imshow("cam1", frame1);
                detectAndDraw(frame1, car_Cascade, scale, count);
                //detectAndDraw(frame2, car_Cascade, scale, count);
                //detectAndDraw(frame3, car_Cascade, scale, count);
                //detectAndDraw(frame4, car_Cascade, scale, count);
                //frame1
                //CvInvoke.Imshow("cam1", frame1);
                
            }*/
            
        }

        void detectAndDraw(Mat frame,CascadeClassifier cascade, double scale, int count,string name)
        {
            Rectangle[] cars = new Rectangle[15];
            Rectangle[] cars2 = new Rectangle[8];
            Mat gray = new Mat();
            Mat smallImg = new Mat();
            CvInvoke.CvtColor(frame, gray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            double fx = 1 / scale;

            CvInvoke.Resize(gray, smallImg, new Size(gray.Width, gray.Height), fx, fx, Emgu.CV.CvEnum.Inter.Linear);
            CvInvoke.EqualizeHist(smallImg, smallImg);
            Size s = new Size(40, 40);
            Size d = new Size(150, 150);
            cars = cascade.DetectMultiScale(smallImg, 1.1, 2, s, d);
            cars2 = cascade.DetectMultiScale(smallImg, 1.1, 3, d);
            

            for (int i = 0; i < cars.Count(); i++)
            {
                Rectangle r = cars[i];
                Mat smallImgROI;
                double aspect_ratio = (double)r.Width / r.Height;
                CvInvoke.Rectangle(frame, cars.ElementAt(i), new MCvScalar(255, 0, 0), thickness: 4);
                smallImgROI = smallImg;
            }
            for (int i = 0; i < cars2.Count(); i++)
            {
                Rectangle r = cars2[i];
                Mat smallImgROI;
                double aspect_ratio = (double)r.Width / r.Height;
                CvInvoke.Rectangle(frame, cars2.ElementAt(i), new MCvScalar(0, 0, 255), thickness:4) ;
                smallImgROI = smallImg;
            }
            CvInvoke.Imshow(name, frame);
        }
    }
}
