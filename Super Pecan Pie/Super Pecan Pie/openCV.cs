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


            ImageViewer viewer = new ImageViewer();
            VideoCapture capture = new VideoCapture(0);
            Mat frame = capture.QueryFrame();

            Application.Idle += new EventHandler(delegate (object ss, EventArgs ee)
            {
                
                
                capture.Read(frame);
                //viewer.Image = capture.QueryFrame();
                detectAndDraw( frame, car_Cascade, scale, count,viewer);


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

        void detectAndDraw(Mat frame,CascadeClassifier cascade, double scale, int count, ImageViewer viewer)
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
            CvInvoke.Imshow("cam1", frame);
            //ImageViewer.Show(frame);

            //viewer.Image = capture.QueryFrame();

        }
    }
}
