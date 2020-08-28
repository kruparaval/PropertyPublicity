using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Cities.Dto
{
     public class PageCityResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }

    }
}
