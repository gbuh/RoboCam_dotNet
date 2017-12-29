using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace rec.robotino.api2.examples.camera
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(new Robot()));
        }
    }
}
/*
using System.Drawing;
using System.Drawing.Imaging;


namespace rec.robotino.api2.examples.camera
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			try
			{
				Image image1 = Image.FromFile("RedLaser1.png", true);

				//TextureBrush texture = new TextureBrush(image1);
				//texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
				//Graphics formGraphics = this.CreateGraphics();
				//formGraphics.FillEllipse(texture,
				//			new RectangleF(90.0F, 110.0F, 100, 100));
				//formGraphics.Dispose();
				PixelColor pixelColor = new PixelColor();
				pixelColor.setRedLaserPicture(image1);
				//pixelColor.setNegativePicture(image1);
				pixelColor.saveImage(image1);
			}
			catch (System.IO.FileNotFoundException)
			{
				MessageBox.Show("There was an error opening the bitmap." +
					"Please check the path.");
			}
		}
	}
}
*/