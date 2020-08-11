using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using OMTechStation.PropertyPublicity.Controllers;
using OMTechStation.PropertyPublicity.PP.States;
using OMTechStation.PropertyPublicity.Web.Models.Roles;
using OMTechStation.PropertyPublicity.Web.PP.Models.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Controllers
{
    public class StatesController : PropertyPublicityControllerBase
    {
        private readonly IStateAppService _StateAppService;

        public StatesController(IStateAppService StateAppService)
        {
            _StateAppService = StateAppService;
        }

        public IActionResult Index()
        {
            var model = new StateListViewModel
            {
            };

            return View(model);
        }

        public async Task<ActionResult> EditModal(int roleId)
        {
            var output = await _StateAppService.GetStateForEdit(new EntityDto(roleId));
            var model = ObjectMapper.Map<EditRoleModalViewModel>(output);

            return PartialView("_EditModal", model);
        }
    }
}


    

