using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Areas.Dto
{
     public class AreaListDto: EntityDto, IHasCreationTime
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public DateTime CreationTime { get; set; }
    }

   }

