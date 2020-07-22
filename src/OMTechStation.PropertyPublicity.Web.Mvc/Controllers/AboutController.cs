using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using OMTechStation.PropertyPublicity.Controllers;

namespace OMTechStation.PropertyPublicity.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : PropertyPublicityControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
