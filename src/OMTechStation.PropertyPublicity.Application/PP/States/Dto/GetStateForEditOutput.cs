using Microsoft.AspNetCore.Mvc.Rendering;
using OMTechStation.PropertyPublicity.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.States.Dto
{
    public class GetStateForEditOutput
    {
        public List<SelectListItem> Countries { get; set; }

        public StateEditDto State { get; internal set; }
    }
}
