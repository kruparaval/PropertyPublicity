using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP
{
    [Table("Areas")]
    public class Area : Entity
    {
        [StringLength(MAXLENGTHCITYNAME)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey(nameof(CityId))]
        public City City { get; set; }
        public int CityId { get; set; }


        public const int MAXLENGTHCITYNAME = 50;

    }
}
