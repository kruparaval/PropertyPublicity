using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using OMTechStation.PropertyPublicity.Controllers;
using OMTechStation.PropertyPublicity.PP.Cities.Dto;
using OMTechStation.PropertyPublicity.PP.Countries;
using OMTechStation.PropertyPublicity.PP.Countries.Dto;
using OMTechStation.PropertyPublicity.PP.States;
using OMTechStation.PropertyPublicity.PP.States.Dto;
using OMTechStation.PropertyPublicity.Web.PP.Models.Cities;
using OMTechStation.PropertyPublicity.Web.PP.Models.States;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Controllers
{
    public class CitiesController : PropertyPublicityControllerBase
    {
        private readonly IStateAppService _StateAppService;
        private readonly ICityAppService _CityAppService;

        public CitiesController(ICityAppService CityAppService,
            IStateAppService StateAppService)
        {
            _StateAppService = StateAppService;
            _CityAppService = CityAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new CityListViewModel
            {

            };

            var list = await _StateAppService.GetAllAsync(new PageStateResultRequestDto());
            model.States = list.Items.Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).ToList();

            return View(model);
        }

        public async Task<ActionResult> EditModal(int cityId)
        {
            var output = await _CityAppService.GetCityForEdit(new EntityDto(cityId));
            var model = ObjectMapper.Map<EditCityModalViewModel>(output);

            return PartialView("_EditModal", model);
        }
    }
}
