using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP
{
    public class City : Entity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public object State { get; set; }

        public const int MAXLENGTHCOUNTRYNAME = 50;

    }
}
