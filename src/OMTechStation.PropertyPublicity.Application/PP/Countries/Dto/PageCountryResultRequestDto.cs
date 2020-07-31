using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Countries.Dto
{
     public class PageCountryResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }

    }
}
