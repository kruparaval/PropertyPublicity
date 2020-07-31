using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using OMTechStation.PropertyPublicity.Controllers;
using OMTechStation.PropertyPublicity.PP.Countries;
using OMTechStation.PropertyPublicity.Web.Models.Roles;
using OMTechStation.PropertyPublicity.Web.PP.Models.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Controllers
{
    public class CountriesController : PropertyPublicityControllerBase
    {
        private readonly ICountryAppService _CountryAppService;

        public CountriesController(ICountryAppService CountryAppService)
        {
            _CountryAppService = CountryAppService;
        }

        public IActionResult Index()
        {
            var model = new CountryListViewModel
            {
            };

            return View(model);
        }

        public async Task<ActionResult> EditModal(int roleId)
        {
            var output = await _CountryAppService.GetCountryForEdit(new EntityDto(roleId));
            var model = ObjectMapper.Map<EditRoleModalViewModel>(output);

            return PartialView("_EditModal", model);
        }
    }
}


    

