using Microsoft.AspNetCore.Mvc.Rendering;
using OMTechStation.PropertyPublicity.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Models.Areas
{
    public class AreaListViewModel
    {
        public List<SelectListItem> Cities { get; set; }

        public int CityId { get; set; }


    }
}
