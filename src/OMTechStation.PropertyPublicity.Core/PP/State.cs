using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP
{
     public class State : Entity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public const int MAXLENGTHCOUNTRYNAME = 50;

    }
}
