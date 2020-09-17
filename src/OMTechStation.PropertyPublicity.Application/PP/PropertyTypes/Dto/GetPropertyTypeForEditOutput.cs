using Microsoft.AspNetCore.Mvc.Rendering;
using OMTechStation.PropertyPublicity.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.PropertyTypes.Dto
{
    public class GetPropertyTypeForEditOutput
    {
      public PropertyTypeEditDto PropertyType { get; internal set; }
    }
}
