using WebAppGeoElasticsearch.ElasticsearchApi;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebAppGeoElasticsearch.Models;

namespace WebAppGeoElasticsearch.Controllers
{
    public class HomeController : Controller
	{
		private readonly SearchProvider _searchProvider = new SearchProvider();

		public ActionResult Index()
		{
			var searchResult = _searchProvider.SearchForClosest(0, 7.44461, 46.94792);
			var mapModel = new MapModel
			{
				MapData = new JavaScriptSerializer().Serialize(searchResult),
				// Bern	Lat 46.94792, Long 7.44461
				CenterLatitude = 46.94792,
				CenterLongitude = 7.44461,
				MaxDistanceInMeter=0
			};

			return View(mapModel);
		}

		public ActionResult Search(uint maxDistanceInMeter, double centerLongitude, double centerLatitude)
		{
			var searchResult = _searchProvider.SearchForClosest(maxDistanceInMeter, centerLongitude, centerLatitude);
			var mapModel = new MapModel
			{
				MapData = new JavaScriptSerializer().Serialize(searchResult),
				CenterLongitude = centerLongitude,
				CenterLatitude = centerLatitude,
				MaxDistanceInMeter = maxDistanceInMeter
			};

			return View("Index", mapModel);
		}		
	}
}