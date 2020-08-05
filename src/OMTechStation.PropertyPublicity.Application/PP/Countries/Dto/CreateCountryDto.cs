using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Countries.Dto
{
    public class CreateCountryDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsActive { get; set; }

    }
}
