using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Countries.Dto
{
     public class CountryEditDto: EntityDto<int>
    {
        [Required]
        [StringLength(Country.MAXLENGTHCOUNTRYNAME)]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }

}
