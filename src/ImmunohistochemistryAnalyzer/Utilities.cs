using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImmunohistochemistryAnalyzer
{
	public static class Utilities
	{
		public static Bitmap CreateNonIndexedImage(System.Drawing.Image src)
		{
			Bitmap newBmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			using (Graphics gfx = Graphics.FromImage(newBmp))
			{
				gfx.DrawImage(src, 0, 0);
			}

			return newBmp;
		}
	}
}
