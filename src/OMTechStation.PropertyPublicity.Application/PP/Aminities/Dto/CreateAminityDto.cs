using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Aminities.Dto
{
    public class CreateAminityDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        

    }
}
