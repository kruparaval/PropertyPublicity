using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMTechStation.PropertyPublicity.PP
{
    [Table("Countries")]
    public class Country : Entity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public const int MAXLENGTHCOUNTRYNAME = 50;
    }
}
