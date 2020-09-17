using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using OMTechStation.PropertyPublicity.Controllers;
using OMTechStation.PropertyPublicity.PP.Areas;
using OMTechStation.PropertyPublicity.PP.Cities.Dto;
using OMTechStation.PropertyPublicity.PP.Countries;
using OMTechStation.PropertyPublicity.PP.Countries.Dto;
using OMTechStation.PropertyPublicity.PP.PropertyTypes;
using OMTechStation.PropertyPublicity.PP.PropertyTypes.Dto;
using OMTechStation.PropertyPublicity.PP.States;
using OMTechStation.PropertyPublicity.PP.States.Dto;
using OMTechStation.PropertyPublicity.Web.PP.Models.Areas;
using OMTechStation.PropertyPublicity.Web.PP.Models.Cities;
using OMTechStation.PropertyPublicity.Web.PP.Models.PropertyTypes;
using OMTechStation.PropertyPublicity.Web.PP.Models.States;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Controllers
{
    public class PropertyTypesController : PropertyPublicityControllerBase
    {
        private readonly IPropertyTypeAppService _PropertyTypeAppService;

        public PropertyTypesController(IPropertyTypeAppService PropertyTypeAppService)
        {

            _PropertyTypeAppService = PropertyTypeAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new PropertyTypeListViewModel
            {

            };

            var list = await _PropertyTypeAppService.GetAllAsync(new PagePropertyTypeResultRequestDto());
            model.PropertyTypes = list.Items.Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).ToList();

            return View(model);
        }

        public async Task<ActionResult> EditModal(int propertyTypeId)
        {
            var output = await _PropertyTypeAppService.GetPropertyTypeForEdit(new EntityDto(propertyTypeId));
            var model = ObjectMapper.Map<EditPropertyTypeModalViewModel>(output);

            return PartialView("_EditModal", model);
        }
    }
}
