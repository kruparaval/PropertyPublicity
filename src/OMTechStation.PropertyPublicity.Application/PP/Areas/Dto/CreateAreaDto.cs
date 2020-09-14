using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Areas.Dto
{
    public class CreateAreaDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public int CityId { get; set; }

    }
}
