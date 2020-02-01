﻿using System;
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
                detectAndDraw( frame1, car_Cascade, scale, count,viewer1, "cam1");
                detectAndDraw(frame2, car_Cascade, scale, count, viewer2,"cam2");
                detectAndDraw(frame3, car_Cascade, scale, count, viewer3,"cam3");
                detectAndDraw(frame4, car_Cascade, scale, count, viewer4,"cam4");


            });
            
            //Mat frame1 = new Mat();
            //IImage frame1 = new Mat();
            //Mat frame2;
            //Mat frame3 = new Mat();
            //Mat frame4 = new Mat();
            //double scale = 5;
            //int count = 0;
            
           

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

        void detectAndDraw(Mat frame,CascadeClassifier cascade, double scale, int count, ImageViewer viewer,string name)
        {
            Rectangle[] cars = new Rectangle[100];
            Mat gray = new Mat();
            Mat smallImg = new Mat();
            CvInvoke.CvtColor(frame, gray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            double fx = 1 / scale;

            CvInvoke.Resize(gray, smallImg, new Size(gray.Width, gray.Height), fx, fx, Emgu.CV.CvEnum.Inter.Linear);
            CvInvoke.EqualizeHist(smallImg, smallImg);
            Size s = new Size(30, 30);
            cars = cascade.DetectMultiScale(smallImg, 1.1, 2, s);

            for (int i = 0; i < cars.Count(); i++)
            {
                    Rectangle r = cars[i];
                    Mat smallImgROI;
                    // Color for Drawing tool 

                    double aspect_ratio = (double)r.Width / r.Height;

                /*Rectangle(frame,
                    Point(cvRound(r.x * scale), cvRound(r.y * scale)),
                    Point(cvRound((r.x + r.width - 1) * scale), cvRound((r.y + r.height - 1) * scale)),
                    color, 3, 8, 0);*/
                CvInvoke.Rectangle(frame, cars.ElementAt(i), new MCvScalar(255, 0, 0));
                //smallImgROI = smallImg(r);
                //count++;
                //cout << "car Detected: #" << count;
                smallImgROI = smallImg.T();
            }










            //CvInvoke.Rectangle(frame, cars.ElementAt(i), new MCvScalar(0, 255, 0));
            //Rectangle r = cars[i];
            //Mat smallImgROI;
            //MCvScalar color = new MCvScalar(255, 0, 0); // Color for Drawing tool 

            //double aspect_ratio = (double)r.width / r.height;

            //Rectangle(frame,
            //Point(cvRound(r.x * scale), cvRound(r.y * scale)),
            //Point(cvRound((r.x + r.width - 1) * scale), cvRound((r.y + r.height - 1) * scale)),
            //color, 3, 8, 0);
            //smallImgROI = smallImg(r);
            //count++;
            //cout << "car Detected: #" << count;
            //viewer.ShowDialog();
            CvInvoke.Imshow(name, frame);
            //ImageViewer.Show(frame);

            //viewer.Image = capture.QueryFrame();

        }
    }
}
