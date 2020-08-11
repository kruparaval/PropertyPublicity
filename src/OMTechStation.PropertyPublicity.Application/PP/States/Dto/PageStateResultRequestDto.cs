using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.States.Dto
{
     public class PageStateResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }

    }
}
