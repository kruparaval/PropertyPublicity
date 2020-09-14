using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Areas.Dto
{
     public class AreaEditDto: EntityDto<int>
    {
        [Required]
        [StringLength(Area.MAXLENGTHCITYNAME)]
        public string Name { get; set; }

        public bool IsActive { get; set; }
        public int AreaId { get; set; }

    }

}
