using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP
{
    [Table("Cities")]
    public class City : Entity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey(nameof(StateId))]
        public State State { get; set; }
        public int StateId { get; set; }


        public const int MAXLENGTHCOUNTRYNAME = 50;

    }
}
