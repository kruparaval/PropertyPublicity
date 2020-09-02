using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using OMTechStation.PropertyPublicity.Controllers;
using OMTechStation.PropertyPublicity.PP.cities;
using OMTechStation.PropertyPublicity.PP.States;
using OMTechStation.PropertyPublicity.Web.Models.Roles;
using OMTechStation.PropertyPublicity.Web.PP.Models.Cities;
using OMTechStation.PropertyPublicity.Web.PP.Models.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Controllers
{
    public class CitiesController : PropertyPublicityControllerBase
    {
        private readonly ICityAppService _CityAppService;
        private int cityId;

        public CitiesController(ICityAppService CityAppService)
        {
            _CityAppService = CityAppService;
        }

        public IActionResult Index()
        {
            var model = new CityListViewModel
            {
            };

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


    

