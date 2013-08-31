using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AForge.Imaging;

namespace ImmunohistochemistryAnalyzer.Clustering
{
	public static class Tools
	{
		public static List<Color> Colors;

		private static void GenerateColors()
		{
			Colors = new List<Color>();
			Colors.Add(Color.Blue);
			Colors.Add(Color.Purple);
			Colors.Add(Color.Yellow);
			Colors.Add(Color.Green);
			Colors.Add(Color.White);
			Colors.Add(Color.YellowGreen);
			Colors.Add(Color.Red);
			Colors.Add(Color.Pink);
			Colors.Add(Color.Plum);
			Colors.Add(Color.PeachPuff);
			Colors.Add(Color.OrangeRed);
			Colors.Add(Color.Orange);
		}

		public static Bitmap ColorClusters(List<List<Antibody>> clusters, List<Antibody> allAntibodies, System.Drawing.Image image, int pointSize=10)
		{
			GenerateColors();

			var analyzedAndColoredImage = Utilities.CreateNonIndexedImage(image);
			
			Graphics g = Graphics.FromImage(analyzedAndColoredImage);

			int total = 0;

			for (int i = 0; i < clusters.Count; i++)
			{
				int count = clusters[i].Count;
				total += count;

				//string plural = (count != 1) ? "s" : "";
				//Console.WriteLine("\nCluster {0} consists of the following {1} point{2} :\n", i + 1, count, plural);
				//Console.WriteLine();

				foreach (var p in clusters[i])
				{
					g.DrawEllipse(new Pen(Colors[i], pointSize), p.X, p.Y, pointSize, pointSize);
				}
			}

			//NOISE
			foreach (var p in allAntibodies)
			{
				if (p.ClusterID == Antibody.NOISE) g.DrawEllipse(new Pen(Color.Gray, pointSize), p.X, p.Y, pointSize, pointSize);
			}

			return analyzedAndColoredImage;
		}
	}
}
