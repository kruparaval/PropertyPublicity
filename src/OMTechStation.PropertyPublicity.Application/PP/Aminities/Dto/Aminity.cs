using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Aminities.Dto
{
     public class AminityEditDto : EntityDto<int>
    {
        [Required]
        public string Name { get; set; }

    }

}
