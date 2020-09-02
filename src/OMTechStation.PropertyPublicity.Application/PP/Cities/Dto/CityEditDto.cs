﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Cities.Dto
{
     public class CityEditDto: EntityDto<int>
    {
        [Required]
        [StringLength(City.MAXLENGTHCOUNTRYNAME)]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }

}