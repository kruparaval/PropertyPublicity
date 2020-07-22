using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using OMTechStation.PropertyPublicity.Controllers;

namespace OMTechStation.PropertyPublicity.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PropertyPublicityControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
