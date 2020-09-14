using Microsoft.AspNetCore.Mvc.Rendering;
using OMTechStation.PropertyPublicity.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Areas.Dto
{
    public class GetAreaForEditOutput
    {
        public List<SelectListItem> Cities{ get; set; }

        public AreaEditDto Area { get; internal set; }
    }
}
