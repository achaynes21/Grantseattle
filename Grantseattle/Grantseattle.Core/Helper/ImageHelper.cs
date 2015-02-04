using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Core
{
	public class ImageHelper
	{
        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            byte[] byteArray = new byte[0];
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }

		/*public static string CropImage(string source, string destination, int x, int y, int width, int height)
        {
            if (!File.Exists(source)) return string.Empty;

            string fileName = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss_") + Path.GetFileName(source);

            Bitmap image = new Bitmap(source);

            Rectangle rect = new Rectangle(x, y, width, height);

            Bitmap croppedImage = image.Clone(rect, image.PixelFormat);

            try
            {
                if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);

                destination = Path.Combine(destination, fileName);
                croppedImage.Save(destination, ImageFormat.Jpeg);

                croppedImage.Dispose();

                return fileName;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return string.Empty;
        }*/

        public static string CreateAutoThumbnail(string source, string destination, int width, int height)
        {
            if (!File.Exists(source)) return string.Empty;

            string fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(source);

            Bitmap image = new Bitmap(source);

            float x = 0; 
            float y = 0;

            //if (image.Width > width) x = image.Width / 2 - width / 2;
            //if (image.Height > height) y = image.Height / 2 - height / 2;

            Rectangle rect = new Rectangle(0, 0, width, height);

            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            Graphics graphics = Graphics.FromImage(bmp);

            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;

            graphics.DrawImage(image, rect, x, y, width, height, GraphicsUnit.Pixel);

            try
            {
                if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);

                destination = Path.Combine(destination, fileName);

                bmp.Save(destination);

                image.Dispose();
                bmp.Dispose();
                graphics.Dispose();

                return fileName;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return string.Empty;
        }
		public static string CropImage(string source, string destination, int x, int y, int width, int height)
		{
			if (!File.Exists(source)) return string.Empty;

			string fileName = Guid.NewGuid().ToString().Replace("-", "").ToLegalUrl() + Path.GetExtension(source);

			Bitmap image = new Bitmap(source);
            
			Rectangle rect = new Rectangle(0, 0, width, height);

			Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

			Graphics graphics = Graphics.FromImage(bmp);

			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics.CompositingMode = CompositingMode.SourceCopy;
			graphics.CompositingQuality = CompositingQuality.HighQuality;

			graphics.DrawImage(image, rect, x, y, width, height, GraphicsUnit.Pixel);

			try
			{
				if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);

				destination = Path.Combine(destination, fileName);

				bmp.Save(destination);

				image.Dispose();
				bmp.Dispose();
				graphics.Dispose();

				return fileName;
			}
			catch (Exception ex)
			{
				string msg = ex.Message;
			}

			return string.Empty;
		}
		public static Bitmap ReSizeBitmap(Bitmap imgPhoto, int Width, int Height)
		{
			int sourceWidth = imgPhoto.Width;
			int sourceHeight = imgPhoto.Height;
			int sourceX = 0;
			int sourceY = 0;
			int destX = 0;
			int destY = 0;

			float nPercent = 1;
			float nPercentW = 0;
			float nPercentH = 0;
			int destWidth = Width;
			int destHeight = Height;

			if (Height != sourceHeight || Width != sourceWidth)
			{
				destWidth++;
				destHeight++;
				nPercentW = ((float)Width / (float)sourceWidth);
				nPercentH = ((float)Height / (float)sourceHeight);

				if (nPercentH < nPercentW)
				{
					destX = -1;
					nPercent = nPercentW;
					destHeight = (int)((float)sourceHeight * nPercent);
					destY = (int)((Height - destHeight) / 2);

					if (destY == 0 && destHeight == Height)
					{
						destY = -1;
						destHeight = Height + 1;
					}
				}
				else
				{
					destY = -1;
					nPercent = nPercentH;
					destWidth = (int)((float)sourceWidth * nPercent);
					destX = (int)((Width - destWidth) / 2);

					if (destX == 0 && destWidth == Width)
					{
						destX = -1;
						destWidth = Width + 1;
					}
				}
			}

			Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
			bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

			Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto);
			grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

			grPhoto.DrawImage(imgPhoto, new Rectangle(destX, destY, destWidth, destHeight), new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);

			grPhoto.Dispose();
			return bmPhoto;
		}
		public static string CreateThumbnail(string source, string destination, float squareSize)
		{
            if (!File.Exists(source)) return string.Empty;

            string fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(source);

            Bitmap img = new Bitmap(source);


			float width = img.Width;
			float height = img.Height;
			float r = 0;

			if (width < height)
			{
				r = width / squareSize;
				width = squareSize;
				height = (height / r);
			}
			else
			{
				r = height / squareSize;
				width = (width / r);
				height = squareSize;
			}
			int size = (int)squareSize;

			Rectangle rect = new Rectangle(0, 0, size, size);

			Bitmap newImg = new Bitmap(img, (int)width, (int)height);
			Bitmap croppedImg = new Bitmap(size, size, PixelFormat.Format32bppRgb);

			Graphics graphics = Graphics.FromImage(croppedImg);
			graphics.CompositingMode = CompositingMode.SourceCopy;
			graphics.CompositingQuality = CompositingQuality.HighQuality;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.DrawImage(newImg, rect, 0, 0, size, size, GraphicsUnit.Pixel);

            try
            {
                if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);

                destination = Path.Combine(destination, fileName);

                croppedImg.Save(destination);

                img.Dispose();
                newImg.Dispose();
                croppedImg.Dispose();
                graphics.Dispose();

                return fileName;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return string.Empty;
		}
	}
}
