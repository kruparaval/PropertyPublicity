using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using OMTechStation.PropertyPublicity.Controllers;
using OMTechStation.PropertyPublicity.PP.Countries;
using OMTechStation.PropertyPublicity.PP.Countries.Dto;
using OMTechStation.PropertyPublicity.PP.States;
using OMTechStation.PropertyPublicity.Web.PP.Models.States;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Controllers
{
    public class StatesController : PropertyPublicityControllerBase
    {
        private readonly IStateAppService _StateAppService;
        private readonly ICountryAppService _countryAppService;

        public StatesController(IStateAppService StateAppService,
            ICountryAppService countryAppService)
        {
            _StateAppService = StateAppService;
            _countryAppService = countryAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new StateListViewModel
            {

            };

            var list = await _countryAppService.GetAllAsync(new PageCountryResultRequestDto());
            model.Countries = list.Items.Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).ToList();

            return View(model);
        }

        public async Task<ActionResult> EditModal(int stateId)
        {
            var output = await _StateAppService.GetStateForEdit(new EntityDto(stateId));
            var model = ObjectMapper.Map<EditStateModalViewModel>(output);

            return PartialView("_EditModal", model);
        }
    }
}




