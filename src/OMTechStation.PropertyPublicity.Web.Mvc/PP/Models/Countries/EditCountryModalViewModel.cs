using Abp.AutoMapper;
using OMTechStation.PropertyPublicity.PP.Countries.Dto;
using OMTechStation.PropertyPublicity.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Models.Countries
{
    [AutoMapFrom(typeof(GetCountryForEditOutput))]
    public class EditCountryModalViewModel : GetCountryForEditOutput
    {

    }
}


