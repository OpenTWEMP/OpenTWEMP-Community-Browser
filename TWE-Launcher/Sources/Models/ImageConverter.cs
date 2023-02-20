using Pfim;
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;

namespace TWE_Launcher.Models
{
	public static class ImageConverter
	{
		public static void ConvertTgaToPng(string sourceTgaImagePath, string destPngImagePath)
		{
			using (var image = Pfimage.FromFile(sourceTgaImagePath))
			{
				PixelFormat format;

				switch (image.Format)
				{
					case Pfim.ImageFormat.Rgba32:
						format = PixelFormat.Format32bppArgb;
						break;
					case Pfim.ImageFormat.Rgb24:
						format = PixelFormat.Format24bppRgb;
						break;
					case Pfim.ImageFormat.R5g5b5:
						format = PixelFormat.Format16bppRgb555;
						break;
					default:
						format = PixelFormat.DontCare;
						break;
				}

				var handle = GCHandle.Alloc(image.Data, GCHandleType.Pinned);

				try
				{
					var data = Marshal.UnsafeAddrOfPinnedArrayElement(image.Data, 0);
					var bitmap = new Bitmap(image.Width, image.Height, image.Stride, format, data);

					bitmap.Save(destPngImagePath, System.Drawing.Imaging.ImageFormat.Png);
				}
				finally
				{
					handle.Free();
				}
			}
		}
	}
}
