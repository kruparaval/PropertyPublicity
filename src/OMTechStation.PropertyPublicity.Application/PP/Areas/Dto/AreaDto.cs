using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Areas.Dto
{
    public class AreaDto : EntityDto
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string CityName { get; set; }
    }
}
