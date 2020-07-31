using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Countries.Dto
{
    public class CountryDto : EntityDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
