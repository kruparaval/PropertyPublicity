using Microsoft.AspNetCore.Mvc.Rendering;
using OMTechStation.PropertyPublicity.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Cities.Dto
{
    public class GetCityForEditOutput
    {
        public List<SelectListItem> States{ get; set; }

        public CityEditDto City { get; internal set; }
    }
}
