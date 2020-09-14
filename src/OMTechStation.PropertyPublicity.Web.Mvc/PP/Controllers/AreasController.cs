using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using OMTechStation.PropertyPublicity.Controllers;
using OMTechStation.PropertyPublicity.PP.Areas;
using OMTechStation.PropertyPublicity.PP.Cities.Dto;
using OMTechStation.PropertyPublicity.PP.Countries;
using OMTechStation.PropertyPublicity.PP.Countries.Dto;
using OMTechStation.PropertyPublicity.PP.States;
using OMTechStation.PropertyPublicity.PP.States.Dto;
using OMTechStation.PropertyPublicity.Web.PP.Models.Areas;
using OMTechStation.PropertyPublicity.Web.PP.Models.Cities;
using OMTechStation.PropertyPublicity.Web.PP.Models.States;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Controllers
{
    public class AreasController : PropertyPublicityControllerBase
    {
        private readonly ICityAppService _CityAppService;
        private readonly IAreaAppService _AreaAppService;

        public AreasController(IAreaAppService AreaAppService,
            ICityAppService CityAppService)
        {
            _CityAppService = CityAppService;
            _AreaAppService = AreaAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new AreaListViewModel
            {

            };

            var list = await _CityAppService.GetAllAsync(new PageCityResultRequestDto());
            model.Cities = list.Items.Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).ToList();

            return View(model);
        }

        public async Task<ActionResult> EditModal(int areaId)
        {
            var output = await _AreaAppService.GetAreaForEdit(new EntityDto(areaId));
            var model = ObjectMapper.Map<EditAreaModalViewModel>(output);

            return PartialView("_EditModal", model);
        }
    }
}
