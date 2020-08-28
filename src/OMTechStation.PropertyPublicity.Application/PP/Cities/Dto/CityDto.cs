using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Cities.Dto
{
    public class CityDto : EntityDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
