using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge;

namespace ImmunohistochemistryAnalyzer
{
	public class Antibody
	{
		public const int NOISE = -1;
		public const int UNCLASSIFIED = 0;

		public int ClusterID { get; set; }

		public Point Location
		{
			get { return location; }
			set { location = value; }
		}
		private Point location;
		public float X
		{
			get { return location.X; }
			set { location.X = value; }
		}
		public float Y
		{
			get { return location.Y; }
			set { location.Y = value; }
		}

		public Antibody(Point aLocation)
		{
			Location = new Point(aLocation.X, aLocation.Y);
		}

		public Antibody(int X, int Y)
		{
			Location = new Point(X, Y);
		}

		public Antibody(float X, float Y)
		{
			Location = new Point(X, Y);
		}

		internal static int DistanceSquared(Antibody firstAntibody, Antibody secondAntibody)
		{
			int differenceX = (int)(secondAntibody.X - firstAntibody.X);
			int differenceY = (int)(secondAntibody.Y - firstAntibody.Y);
			return differenceX * differenceX + differenceY * differenceY;
		}

		public override string ToString()
		{
			return String.Format("({0}, {1})", X, Y);
		}
	}
}
