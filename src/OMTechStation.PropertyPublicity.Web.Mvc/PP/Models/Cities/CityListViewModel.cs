using Microsoft.AspNetCore.Mvc.Rendering;
using OMTechStation.PropertyPublicity.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Models.Cities
{
    public class CityListViewModel
    {
        public List<SelectListItem> States { get; set; }

        public int StateId { get; set; }


    }
}
