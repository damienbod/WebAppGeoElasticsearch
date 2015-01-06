using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebAppGeoMapElasticsearch.ElasticsearchApi;

namespace WebAppGeoMapElasticsearch.Controllers
{
	public class HomeController : Controller
	{
		private readonly SearchProvider _searchProvider = new SearchProvider();

		public ActionResult Index()
		{
			//_searchProvider.InitMapDetailMapping();
			//_searchProvider.AddMapDetailData();
			return View(
				new MapModel
				{
					MapData = new JavaScriptSerializer().Serialize(_searchProvider.SearchAll())
				}
			);
		}
	}

	public class MapModel
	{
		public string MapData { get; set; }
	}
}