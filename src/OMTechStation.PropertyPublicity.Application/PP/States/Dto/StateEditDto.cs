using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.States.Dto
{
     public class StateEditDto: EntityDto<int>
    {
        [Required]
        [StringLength(State.MAXLENGTHCOUNTRYNAME)]
        public string Name { get; set; }

        public bool IsActive { get; set; }
        public int CountryId { get; set; }
    }

}
