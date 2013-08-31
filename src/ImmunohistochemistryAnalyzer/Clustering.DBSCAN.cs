using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImmunohistochemistryAnalyzer.Clustering
{
	public static class DBSCAN
	{
		public static List<List<Antibody>> GetClusters(List<Antibody> antibodies, double eps, int minPts)
		{
			if (antibodies == null) return null;
			List<List<Antibody>> clusters = new List<List<Antibody>>();
			eps *= eps; // square eps

			int clusterID = 1;
			for (int i = 0; i < antibodies.Count; i++)
			{
				Antibody p = antibodies[i];
				if (p.ClusterID == Antibody.UNCLASSIFIED)
				{
					if (ExpandCluster(antibodies, p, clusterID, eps, minPts)) clusterID++;
				}
			}
			// sort out points into their clusters, if any
			int maxClusterID = antibodies.OrderBy(p => p.ClusterID).Last().ClusterID;
			if (maxClusterID < 1) return clusters; // no clusters, so list is empty
			for (int i = 0; i < maxClusterID; i++) clusters.Add(new List<Antibody>());
			foreach (Antibody p in antibodies)
			{
				if (p.ClusterID > 0) clusters[p.ClusterID - 1].Add(p);
			}
			return clusters;
		}

		static List<Antibody> GetRegion(List<Antibody> antibodies, Antibody currentAntibody, double eps)
		{
			List<Antibody> region = new List<Antibody>();
			for (int i = 0; i < antibodies.Count; i++)
			{
				int distSquared = Antibody.DistanceSquared(currentAntibody, antibodies[i]);
				if (distSquared <= eps) region.Add(antibodies[i]);
			}
			return region;
		}

		static bool ExpandCluster(List<Antibody> antibodies, Antibody currentAntibody, int clusterID, double eps, int minPts)
		{
			List<Antibody> seeds = GetRegion(antibodies, currentAntibody, eps);
			if (seeds.Count < minPts) // no core point
			{
				currentAntibody.ClusterID = Antibody.NOISE;
				return false;
			}
			else // all points in seeds are density reachable from antibody 'currentAntibody'
			{
				for (int i = 0; i < seeds.Count; i++) seeds[i].ClusterID = clusterID;
				seeds.Remove(currentAntibody);
				while (seeds.Count > 0)
				{
					Antibody currentP = seeds[0];
					List<Antibody> result = GetRegion(antibodies, currentP, eps);
					if (result.Count >= minPts)
					{
						for (int i = 0; i < result.Count; i++)
						{
							Antibody resultAntibody = result[i];
							if (resultAntibody.ClusterID == Antibody.UNCLASSIFIED || resultAntibody.ClusterID == Antibody.NOISE)
							{
								if (resultAntibody.ClusterID == Antibody.UNCLASSIFIED) seeds.Add(resultAntibody);
								resultAntibody.ClusterID = clusterID;
							}
						}
					}
					seeds.Remove(currentP);
				}
				return true;
			}
		}
	}
}

