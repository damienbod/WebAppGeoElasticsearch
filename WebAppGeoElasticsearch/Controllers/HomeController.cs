﻿using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebAppGeoElasticsearch.ElasticsearchApi;
using WebAppGeoElasticsearch.Models;

namespace WebAppGeoElasticsearch.Controllers
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
}