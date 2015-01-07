﻿namespace WebAppGeoElasticsearch.Models
{
	public class MapModel
	{
		public string MapData { get; set; }
		public double CenterLongitude { get; set; }
		public double CenterLatitude { get; set; }
		public int MaxDistanceInMeter { get; set; }
	}
}