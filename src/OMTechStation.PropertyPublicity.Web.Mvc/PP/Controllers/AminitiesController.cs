using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using OMTechStation.PropertyPublicity.Controllers;
using OMTechStation.PropertyPublicity.PP.Aminities;
using OMTechStation.PropertyPublicity.PP.Aminities.Dto;
using OMTechStation.PropertyPublicity.PP.Areas;
using OMTechStation.PropertyPublicity.PP.Cities.Dto;
using OMTechStation.PropertyPublicity.PP.Countries;
using OMTechStation.PropertyPublicity.PP.Countries.Dto;
using OMTechStation.PropertyPublicity.PP.PropertyTypes;
using OMTechStation.PropertyPublicity.PP.PropertyTypes.Dto;
using OMTechStation.PropertyPublicity.PP.States;
using OMTechStation.PropertyPublicity.PP.States.Dto;
using OMTechStation.PropertyPublicity.Web.PP.Models.Aminities;
using OMTechStation.PropertyPublicity.Web.PP.Models.Areas;
using OMTechStation.PropertyPublicity.Web.PP.Models.Cities;
using OMTechStation.PropertyPublicity.Web.PP.Models.PropertyTypes;
using OMTechStation.PropertyPublicity.Web.PP.Models.States;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Controllers
{
    public class AminitiesController : PropertyPublicityControllerBase
    {
        private readonly IAminityAppService _AminityAppService;

        public AminitiesController(IAminityAppService AminityAppService)
        {

            _AminityAppService = AminityAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new AminityListViewModel
            {

            };

            var list = await _AminityAppService.GetAllAsync(new PageAminityResultRequestDto());
            model.Aminities = list.Items.Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).ToList();

            return View(model);
        }

        public async Task<ActionResult> EditModal(int AminityId)
        {
            var output = await _AminityAppService.GetAminityForEdit(new EntityDto(AminityId));
            var model = ObjectMapper.Map<EditAminityModalViewModel>(output);

            return PartialView("_EditModal", model);
        }
    }
}
