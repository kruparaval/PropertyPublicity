using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.PropertyTypes.Dto
{
     public class PropertyTypeEditDto : EntityDto<int>
    {
        [Required]
        public string Name { get; set; }

    }

}
