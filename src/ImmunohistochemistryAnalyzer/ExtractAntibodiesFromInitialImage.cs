using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Imaging;
using AForge.Imaging.Filters;
using System.Drawing;

namespace ImmunohistochemistryAnalyzer
{
	public static class ExtractAntibodiesFromInitialImage
	{
		public static Bitmap ProcessImage(string imagePath)
		{
			var img = AForge.Imaging.Image.FromFile(imagePath);
			
			ContrastStretch filterContrastStretch = new ContrastStretch();
			filterContrastStretch.ApplyInPlace(img);

			try
			{
				img = Grayscale.CommonAlgorithms.BT709.Apply(img);
			}
			catch
			{
				System.Windows.Forms.MessageBox.Show("The image should not be grayscale");
			}

			Opening filterOpening = new Opening();
			filterOpening.ApplyInPlace(img);

			SobelEdgeDetector sobel = new SobelEdgeDetector();
			sobel.ApplyInPlace(img);

			Closing filterClosing = new Closing();
			filterClosing.ApplyInPlace(img);

			Threshold threshold = new Threshold(100);
			threshold.ApplyInPlace(img);

			FillHoles fillHoles = new FillHoles();
			fillHoles.MaxHoleWidth = img.Width;
			fillHoles.MaxHoleHeight = img.Height;
			fillHoles.CoupledSizeFiltering = false;
			fillHoles.ApplyInPlace(img);

			filterOpening.ApplyInPlace(img);

			Erosion filterErosion = new Erosion();
			filterErosion.ApplyInPlace(img);

			return img;
		}
	}
}
