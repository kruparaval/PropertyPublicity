using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.PropertyTypes.Dto
{
     public class PagePropertyTypeResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }

    }
}
