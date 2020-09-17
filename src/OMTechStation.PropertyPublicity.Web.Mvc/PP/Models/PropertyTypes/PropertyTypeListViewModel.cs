using Microsoft.AspNetCore.Mvc.Rendering;
using OMTechStation.PropertyPublicity.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Models.PropertyTypes
{
    public class PropertyTypeListViewModel
    {
        public List<SelectListItem> PropertyTypes { get; set; }

    }
}
