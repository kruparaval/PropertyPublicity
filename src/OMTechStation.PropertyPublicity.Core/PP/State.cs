using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMTechStation.PropertyPublicity.PP
{
     public class State : Entity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }
        public int CountryId { get; set; }

        public const int MAXLENGTHCOUNTRYNAME = 50;
    }
}
