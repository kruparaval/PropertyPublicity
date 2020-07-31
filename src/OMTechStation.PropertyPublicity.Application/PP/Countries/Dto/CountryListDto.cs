using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Countries.Dto
{
     public class CountryListDto: EntityDto, IHasCreationTime
    {
         public string Name { get; set; }
         public bool IsActive { get; set; }
        public DateTime CreationTime { get; set; }
    }
   }

