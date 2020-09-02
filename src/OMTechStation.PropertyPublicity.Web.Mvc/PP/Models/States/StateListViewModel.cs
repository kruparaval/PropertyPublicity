using Microsoft.AspNetCore.Mvc.Rendering;
using OMTechStation.PropertyPublicity.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Models.States
{
    public class StateListViewModel
    {
        public List<SelectListItem> Countries { get; set; }
        public int CountryId { get; set; }

    }
}
