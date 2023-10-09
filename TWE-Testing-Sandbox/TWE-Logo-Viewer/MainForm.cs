using Pfim;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TWE.LogoViewer
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}


		private void appExitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void contentLoadButton_Click(object sender, EventArgs e)
		{
			FillJpegImagesContent();
			contentPictureBox.BackColor = Color.Azure;
			contentLoadButton.Enabled = false;
		}

		private void contentClearButton_Click(object sender, EventArgs e)
		{
			if (contentPictureBox.Image != null)
			{
				contentPictureBox.Image.Dispose();
				contentPictureBox.Image = null;
			}

			contentPictureBox.BackColor = Color.Black;
			contentListBox.Items.Clear();
		}

		private void FillJpegImagesContent()
		{
			// 1. Generate JPEG images from TGA splashes.

			List<string> tga_images = FindAllTargaImages();

			for (int i = 0; i < tga_images.Count; i++)
			{
				string img = Directory.GetCurrentDirectory() + "\\image_" + i.ToString() + ".png";
				ConvertTgaImageToPng(tga_images[i], img);
			}

			// 2. Load all JPEG images to the program.

			List<string> jpeg_images = FindAllPngImages();

			foreach (var image in jpeg_images)
			{
				contentListBox.Items.Add(image);
			}
		}

		private List<string> FindAllPngImages()
		{
			string png_image_extension = ".png";
			var jpeg_images = new List<string>();

			foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory()))
			{
				if (file.EndsWith(png_image_extension))
				{
					jpeg_images.Add(file);
				}
			}

			return jpeg_images;
		}

		private List<string> FindAllTargaImages()
		{
			string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
		
			string tga_image_extension = ".tga";
			var tga_images = new List<string>();
			foreach (var file in files)
			{
				if (file.EndsWith(tga_image_extension))
				{
					tga_images.Add(file);
				}
			}
		
			return tga_images;
		}

		private void ConvertTgaImageToPng(string path, string png_image_filename)
		{
			using (var image = Pfimage.FromFile(path))
			{
				//PixelFormat format;

				// Convert from Pfim's backend agnostic image format into GDI+'s image format

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
						// see the sample for more details
						throw new NotImplementedException();
				}
		
				// Pin pfim's data array so that it doesn't get reaped by GC, unnecessary
				// in this snippet but useful technique if the data was going to be used in
				// control like a picture box
				var handle = GCHandle.Alloc(image.Data, GCHandleType.Pinned);
				try
				{
					var data = Marshal.UnsafeAddrOfPinnedArrayElement(image.Data, 0);
					var bitmap = new Bitmap(image.Width, image.Height, image.Stride, format, data);

					//bitmap.Save(Path.ChangeExtension(path, ".jpeg"), System.Drawing.Imaging.ImageFormat.Jpeg);

					//string image_filename = path.Replace(".tga", ".jpeg");
					bitmap.Save(png_image_filename, System.Drawing.Imaging.ImageFormat.Png);
				}
				finally
				{
					handle.Free();
				}
			}
		}

		private void contentListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (contentPictureBox.Image != null)
			{
				contentPictureBox.Image.Dispose();
				contentPictureBox.Image = null;
			}

			contentPictureBox.Load(contentListBox.SelectedItem.ToString());
		}
	}
}
