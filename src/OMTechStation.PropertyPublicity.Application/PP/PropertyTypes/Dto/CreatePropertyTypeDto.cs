using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.PropertyTypes.Dto
{
    public class CreatePropertyTypeDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        

    }
}
