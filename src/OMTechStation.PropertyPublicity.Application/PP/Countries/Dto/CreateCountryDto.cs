using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Countries.Dto
{
    public class CreateCountryDto
    {
        [Required]
        [StringLength(Country.MAXLENGTHCOUNTRYNAME)]
        public string Name { get; set; }
        public string IsActive { get; set; }

    }
}
