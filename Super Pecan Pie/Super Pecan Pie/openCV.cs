using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.Structure;

namespace Super_Pecan_Pie
{
    class openCV
    {

        public void findImages()
        {


            Mat frame1 = new Mat();
            Mat frame2 = new Mat();
            Mat frame3 = new Mat();
            Mat frame4 = new Mat();

            CascadeClassifier car_Cascade = new CascadeClassifier("cars.xml");
            int count = 0;
            double scale = 5;

            VideoCapture vid1 = new VideoCapture(1);
            VideoCapture vid2 = new VideoCapture(0);
            VideoCapture vid3 = new VideoCapture(2);
            VideoCapture vid4 = new VideoCapture(3);

            if (!vid1.IsOpened)
            {
                Console.WriteLine("v1 video not read");
            }
            if (!vid2.IsOpened)
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
            }

            while (true)
            {
                vid1.Read(frame1);
                vid1.Read(frame2);
                vid1.Read(frame3);
                vid1.Read(frame4);

                detectAndDraw(frame1, car_Cascade, scale, count);
                detectAndDraw(frame2, car_Cascade, scale, count);
                detectAndDraw(frame3, car_Cascade, scale, count);
                detectAndDraw(frame4, car_Cascade, scale, count);
                //frame1
                CvInvoke.Imshow("cam1", frame1);
            }
        }
        void detectAndDraw(Mat frame, CascadeClassifier cascade, double scale, int count)
        {
            List<Rectangle> cars = new List<Rectangle>();
            Mat gray = new Mat();
            Mat smallImg = new Mat();
            CvInvoke.CvtColor(frame, gray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            double fx = 1 / scale;

            CvInvoke.Resize(gray, smallImg, new Size(gray.Width, gray.Height), fx, fx, Emgu.CV.CvEnum.Inter.Linear);
            CvInvoke.EqualizeHist(smallImg, smallImg);
            Size s = new Size(30, 30);
            cascade.DetectMultiScale(smallImg, 1.1, 2, s);

            for (int i = 0; i < cars.Count(); i++)
            {
                CvInvoke.Rectangle(frame, cars.ElementAt(i), new MCvScalar(0, 255, 0));
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
            }
            CvInvoke.Imshow("cam1", frame);
        }
    }
}
