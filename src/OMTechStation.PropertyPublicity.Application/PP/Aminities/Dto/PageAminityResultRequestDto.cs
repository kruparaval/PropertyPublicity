using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Aminities.Dto
{
     public class PageAminityResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }

    }
}
