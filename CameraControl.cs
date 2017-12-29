using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace rec.robotino.api2.examples.camera
{
    /// <summary>
    /// This control listens for camera events and displays incoming images.
    /// </summary>
    public partial class CameraControl : UserControl
    {
        protected readonly Robot robot;
        private volatile Image img;
 //       private Bitmap temp;
		private PixelColor pixelColor = new PixelColor();
//		private DrivelnCircles drivelnCircles = new DrivelnCircles();
        public CameraControl(Robot robot)
        {
            this.robot = robot;
            robot.ImageReceived += new Robot.ImageReceivedEventHandler(robot_ImageReceived);

            InitializeComponent();
        }

		void robot_ImageReceived(Robot sender, Image img)
		{
			if (pixelColor.robotLaserSpot(img))
			{
				try
				{
					int z = 0;
					z = pixelColor.getLaserSpot(img);
					robot.drive(z);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
			}
			this.img = img;
			if (this.InvokeRequired)
				this.Invoke(new MethodInvoker(Invalidate));
		}

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

			if (img != null) // && !pixelColor.robotLaserSpot(img)
				if (pixelColor.robotLaserSpot(img)) //  
				{
					e.Graphics.DrawImage(img, new Rectangle(new Point(0, 0), Size));
					Font font = new Font("Arial", 16);
					SolidBrush brushBlack = new SolidBrush(Color.Black);
					e.Graphics.DrawString("I see a laser spot...", font, brushBlack, Width / 2 - 80, Height / 2 - 20);
				} else
            {
                e.Graphics.DrawImage(img, new Rectangle(new Point(0, 0), Size));
            }
            else
            {
                SolidBrush brushWhite = new SolidBrush(Color.White);
                e.Graphics.FillRectangle(brushWhite, new Rectangle(new Point(0, 0), Size));

                Font font = new Font("Arial", 16);
                SolidBrush brushBlack = new SolidBrush(Color.Black);
                e.Graphics.DrawString("No camera image", font, brushBlack, Width / 2 - 80, Height / 2 - 20);
            }
        }

        private void CameraControl_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
