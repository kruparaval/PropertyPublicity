using Abp.Domain.Entities;
using System;

namespace OMTechStation.PropertyPublicity.PP
{
    public class Country : Entity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public const int MAXLENGTHCOUNTRYNAME = 50;       
    }
}
