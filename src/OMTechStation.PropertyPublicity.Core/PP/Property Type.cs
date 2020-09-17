using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP
{
    [Table("PropertyTypes")]
    public class PropertyType : Entity
    {
        [StringLength(MAXLENGTHCITYNAME)]
        public string Name { get; set; }
        

        public const int MAXLENGTHCITYNAME = 50;
    }
}
