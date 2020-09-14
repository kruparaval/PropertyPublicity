using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Areas.Dto
{
     public class PageAreaResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }

    }
}
