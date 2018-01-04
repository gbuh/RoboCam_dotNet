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
//		private int light = 200;
		private bool laserSpot = false;
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

		public bool isLaserSpot() { return laserSpot; }

		public void setP(Color p) { this.p = p; }

		//		public void setA(int a) { this.a = a; }

		public void setR(int r) { this.r = r; }

		public void setG(int g) { this.g = g; }

		public void setB(int b) { this.b = b; }

		public void setWidth(int width) { this.width = width; }

		public void setHeight(int height) { this.height = height; }

		public void setPorog(int porog) { this.porog = porog; }

		public void setBitmapImg(Bitmap bitmapImg) { this.bitmapImg = bitmapImg; }

		public void setLaserSpot(bool laserSpot) { this.laserSpot = laserSpot;}

		public PixelColor()
		{
		}

		//public void getPixelColor(Image img, int x, int y)
		//{
		//	bitmapImg = (Bitmap)img;
		//	p = bitmapImg.GetPixel(x, y);
		//	//get red
		//	r = (y * width + x) * 3;
		//	//get green
		//	g = (y * width + x) * 3 + 1;
		//	//get blue
		//	b = (y * width + x) * 3 + 2;
		//}

		//public void setPixelColor(Image img, int x, int y, Color p)
		//{
		//	bitmapImg = (Bitmap)img;
		//	bitmapImg.SetPixel(x, y, p);
		//}
/*
		public bool robotLaserSpot(Image img)
		{
			unsafe
			{
				bitmapImg = (Bitmap)img;
				Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
				BitmapData bitmapData = bitmapImg.LockBits(rect, ImageLockMode.ReadWrite, img.PixelFormat);
				byte* ptr = (byte*)bitmapData.Scan0;
				int byteperpixel = Bitmap.GetPixelFormatSize(bitmapImg.PixelFormat);

				for (int z = 0; z < (width * height * 3); z += 3)
				{
					if ((ptr[z] > 120 && ptr[z] < 150 && ptr[z + 1] > 120 && ptr[z + 1] < 150 && ptr[z + 2] > 200) == true)
//						((ptr[z] > 120 && ptr[z] < 150 && ptr[z + 1] > 120 && ptr[z + 1] < 150 && ptr[z + 2] > 200) == true)
//						if ((ptr[y] > 200 && ptr[y + 1] > 120 && ptr[y + 1] < 150 && ptr[y + 2] > 120 && ptr[y + 2] < 150) == true)
// 						for Robotino® SIM Demo: (ptr[z] > 200 && ptr[z + 1] < 10 && ptr[z + 2] < 10) == true) find red cylinder
					{
//						bitmapImg.UnlockBits(bitmapData);
						return true;
					}
				}
				bitmapImg.UnlockBits(bitmapData);
			}
			return false;
		}
*/
		public int getLaserSpot(Image img)
		{
			unsafe
			{
				bitmapImg = (Bitmap)img;
				Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);
				BitmapData bitmapData = bitmapImg.LockBits(rect, ImageLockMode.ReadWrite, img.PixelFormat);
				byte* ptr = (byte*)bitmapData.Scan0;
				int byteperpixel = Bitmap.GetPixelFormatSize(bitmapImg.PixelFormat);

				for (int z = 0; z < (img.Width * img.Height * 3); z += 3)
				{
					if ((ptr[z] > 110 && ptr[z] < 160 && ptr[z + 1] > 110 && ptr[z + 1] < 160 && ptr[z + 2] > 200) == true)
					//	((ptr[z] > 120 && ptr[z] < 150 && ptr[z + 1] > 120 && ptr[z + 1] < 150 && ptr[z + 2] > 200) == true) find red laser spot
					//	((ptr[y] > 200 && ptr[y + 1] > 120 && ptr[y + 1] < 150 && ptr[y + 2] > 120 && ptr[y + 2] < 150) == true) find blue laser spot
					//  for Robotino® SIM Demo: (ptr[z] < 10 && ptr[z + 1] < 10 && ptr[z + 2] > 200) == true) find red cylinder
					//	for Robotino® SIM Demo: (ptr[z] > 200 && ptr[z + 1] < 10 && ptr[z + 2] < 10) == true) find blue cylinder
					{
						laserSpot = true;
						bitmapImg.UnlockBits(bitmapData);
//						int x = 0;
						if (z <= 960)
						{
							z = z / 3;
//							x = z / 3;
						}
						else
							z = (z % 960) / 3;							
//							x = (z % 960) / 3;
//						Console.WriteLine("X = " + x);
						Console.WriteLine("X = " + z);
//						laserSpot = true;
						return z;
					}
				}
				laserSpot = false;
				bitmapImg.UnlockBits(bitmapData);
			}
			return 0;
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

				for (int z = 0; z < (width * height * 3); z++)
				{
					ptr[z] = (byte)(255 - ptr[z]);
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
