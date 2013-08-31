using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using AForge.Imaging;
using System.Drawing.Imaging;
using System.IO;
using ImmunohistochemistryAnalyzer.Clustering;

namespace ImmunohistochemistryAnalyzer
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			pictureBoxResultImage.SizeMode = PictureBoxSizeMode.Zoom;

			buttonAnalyzeImage.Enabled = buttonSaveImage.Enabled = false;
		}

		Bitmap image;
		Bitmap analyzedImage;
		string filename;

		private void buttonLoadImage_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				image = new Bitmap(openFileDialog.FileName);
				filename = openFileDialog.FileName;
				pictureBoxResultImage.Image = image;
				this.Text = "Immunohistochemistry analyzer: " + Path.GetFileName(openFileDialog.FileName);
				buttonAnalyzeImage.Enabled = true;
			}
		}

		BlobsFiltering blobFilter = new BlobsFiltering();

		int imageWidth;
		int imageHeight;

		private void buttonAnalyzeImage_Click(object sender, EventArgs e)
		{
			buttonSaveImage.Enabled = true;

			var img = ExtractAntibodiesFromInitialImage.ProcessImage(filename);
			imageWidth = img.Width;
			imageHeight = img.Height;

			ImageStatistics imgStats = new ImageStatistics(img);
			double result = (float)(imgStats.Gray.Values[255]) / (float)(imgStats.Gray.Values[0]);
			labelAnalysis.Text = String.Format("Analysis: {0} / {1} = {2,8:c}%", imgStats.Gray.Values[255], imgStats.Gray.Values[0], result * 100);

			pictureBoxResultImage.Image = analyzedImage = img;

			BlobCounter blobCounter = new BlobCounter(analyzedImage);
			Blob[] blobs = blobCounter.GetObjects(analyzedImage, false);

			double averageWidth = 0;
			double averageHeight = 0;
			double averageArea = 0;

			List<Antibody> antibodies = new List<Antibody>();

			foreach (var blob in blobs)
			{
				averageHeight += (blob.Rectangle.Height);
				averageWidth += (blob.Rectangle.Width);
				averageArea += (blob.Area);

				if ((blob.Rectangle.Width > 1 || blob.Rectangle.Width > 1)) //TO BE REVISED!
				{
					antibodies.Add(new Antibody(blob.Rectangle.Location.X, blob.Rectangle.Y));
				}
				else
				{
					//g.DrawEllipse(new Pen(Color.Red, 10), blob.Rectangle.X, blob.Rectangle.Y, 10, 10);
				}
			}
			averageHeight /= blobs.Length;
			averageWidth /= blobs.Length;
			averageArea /= blobs.Length;

			Console.WriteLine(averageHeight);
			Console.WriteLine(averageWidth);
			Console.WriteLine(averageArea);

			var analyzedImage2 = Utilities.CreateNonIndexedImage(analyzedImage);
			var g = Graphics.FromImage(analyzedImage2);

			foreach (var b in blobs)
			{
				if (b.Area > averageArea*100)
				{
					g.DrawEllipse(new Pen(Color.Red, 2), b.Rectangle.X, b.Rectangle.Y, b.Rectangle.Width, b.Rectangle.Height);
				}
			}

			int dist = 0;
			int total = 0;
			for (int i = 0; i < antibodies.Count; ++i)
			{
				for (int j = 0; j < antibodies.Count; j++)
				{
					if (i != j)
					{
						int differenceX = (int)(antibodies[j].X - antibodies[i].X);
						int differenceY = (int)(antibodies[j].Y - antibodies[i].Y);
						dist += (int)(Math.Sqrt((differenceX * differenceX + differenceY * differenceY)));
						total++;
					}
				}
			}

			double eps = (dist / total)/6;
			Console.WriteLine("EPS: {0}", eps);
			int minPts = 20;
			List<List<Antibody>> clusters = Clustering.DBSCAN.GetClusters(antibodies, eps, minPts);
			pictureBoxResultImage.Image = analyzedImage2 = Tools.ColorClusters(clusters, antibodies, analyzedImage2);




			tabControlImages.TabPages.Add("analyzed");
			PictureBox picBox = new PictureBox();
			picBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
					| System.Windows.Forms.AnchorStyles.Left)
					| System.Windows.Forms.AnchorStyles.Right)));
			picBox.Location = new System.Drawing.Point(6, 7);
			picBox.Name = "pictureBoxResultImage";
			picBox.SizeMode = PictureBoxSizeMode.Zoom;
			picBox.Size = pictureBoxResultImage.Size;
			picBox.Image = analyzedImage2;

			(tabControlImages.TabPages[0].Controls[0] as PictureBox).Image = analyzedImage2;
			
			tabControlImages.TabPages[1].Controls.Add(picBox);
			tabControlImages.SelectTab(1);


			Console.WriteLine("Average dist: {0}", dist/total);
		}

		private Dictionary<PixelFormat, PixelFormat> formatTranslations = new Dictionary<PixelFormat, PixelFormat>();

		private void buttonSaveImage_Click(object sender, EventArgs e)
		{
			analyzedImage.Save(filename.Substring(0, filename.LastIndexOf(".")) + "-analyzed-clusterized.png");
		}
	}
}
