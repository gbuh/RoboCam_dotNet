using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace rec.robotino.api2.examples.camera
{
	public class PixelColor
	{
		private Color p;
//		private int a;
		private int r;
		private int g;
		private int b;
		private int width = 320;
		private int height = 240;
		private int porog = 200;
		private Bitmap bitmapImg;

		public Color getP() { return p; }

//		public int getA() { return a; }

		public int getR() { return r; }

		public int getG() { return g; }

		public int getB() { return b; }

		public int getWidth() { return width; }

		public int getHeight() { return height; }

		public int getPorog() { return porog; }

		public Bitmap getBitmapImg() { return bitmapImg; }

		public void setP(Color p) { this.p = p; }

//		public void setA(int a) { this.a = a; }

		public void setR(int r) { this.r = r; }

		public void setG(int g) { this.g = g; }

		public void setB(int b) { this.b = b; }

		public void setWidth(int width) { this.width = width; }

		public void setHeight(int height) { this.height = height; }

		public void setPorog(int porog) { this.porog = porog; }

		public void setBitmapImg(Bitmap bitmapImg) { this.bitmapImg = bitmapImg; }

		public PixelColor()
		{
		}

		public void getPixelColor(Image img, int x, int y)
		{
			bitmapImg = (Bitmap)img;
			p = bitmapImg.GetPixel(x, y);
			//get red
			r = (y * width + x) * 3;
			//get green
			g = (y * width + x) * 3 + 1;
			//get blue
			b = (y * width + x) * 3 + 2;
		}

		public void setPixelColor(Image img, int x, int y, Color p)
		{
			bitmapImg = (Bitmap)img;
			bitmapImg.SetPixel(x, y, p);
		}

		public bool setRedLaserPicture(Image img)
		{
			unsafe
			{
				bitmapImg = (Bitmap)img;
				Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
				BitmapData bitmapData = bitmapImg.LockBits(rect, ImageLockMode.ReadWrite, img.PixelFormat);
				byte* ptr = (byte*)bitmapData.Scan0;
				int byteperpixel = Bitmap.GetPixelFormatSize(bitmapImg.PixelFormat);

				for (int y = 0; y < (img.Width * img.Height * 3); y+=3)
				{
					if ((ptr[y] >= 200 && ptr[y + 1] <= 5 && ptr[y + 2] <= 5) == true)
					{
						return true;

//						drive();
					}

					//{
					//	ptr[y] = 0;
					//	ptr[y + 1] = 0;
					//	ptr[y + 2] = 255;
					//}
					//else
					//{
					//	ptr[y] = 0;
					//	ptr[y + 1] = 0;
					//	ptr[y + 2] = 0;
					//}
				}
				bitmapImg.UnlockBits(bitmapData);
			}
			return false;
		}

	public void rotate(float[] inArray, float[] outArray, float deg)
	{
		float rad = 2 * (float)Math.PI / 360.0f * deg;
		outArray[0] = (float)Math.Cos(rad) * inArray[0] - (float)Math.Sin(rad) * inArray[1];
		outArray[1] = (float)Math.Sin(rad) * inArray[0] + (float)Math.Cos(rad) * inArray[1];
	}

	public void drive()
	{
		Console.Write("Driving .. ");
		float[] startVector = new float[] { 0.2f, 0.0f };
		float[] dir = new float[2];
		float a = 360.0f;

		//rotate 360degrees in 5s
		rotate(startVector, dir, a);

//		Robot.setVelocity(dir[0], dir[1], 0);

//		System.Threading.Thread.Sleep(100);
	   }

		public void setNegativePicture(Image img)
		{
			unsafe
			{
				bitmapImg = (Bitmap)img;
				Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
				BitmapData bitmapData = bitmapImg.LockBits(rect, ImageLockMode.ReadWrite, img.PixelFormat);
				byte* ptr = (byte*)bitmapData.Scan0;
				int byteperpixel = Bitmap.GetPixelFormatSize(bitmapImg.PixelFormat);

				for (int y = 0; y < (width * height * 3); y++)
				{
					
					ptr[y] = (byte)(255 - ptr[y]);
				}
				bitmapImg.UnlockBits(bitmapData);
			}
}

		public void saveImage(Image img)
		{
			int index = 1;
			Bitmap bmp1 = new Bitmap(img);
			bmp1.Save("RedLaserOut" + index + ".png", System.Drawing.Imaging.ImageFormat.Png);
		}
	}
}
