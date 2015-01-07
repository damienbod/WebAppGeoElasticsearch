using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAppGeoElasticsearch.ElasticsearchApi;

namespace WebAppGeoElasticsearch
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			InitSearchEngine();
		}

		private void InitSearchEngine()
		{
			var searchProvider = new SearchProvider();

			if (!searchProvider.MapDetailsIndexExists())
			{
				searchProvider.InitMapDetailMapping();
				searchProvider.AddMapDetailData();
			}
		}
	}
}
