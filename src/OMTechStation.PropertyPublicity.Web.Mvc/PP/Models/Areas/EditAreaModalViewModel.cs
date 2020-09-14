using Abp.AutoMapper;
using OMTechStation.PropertyPublicity.PP.Areas.Dto;
using OMTechStation.PropertyPublicity.PP.Cities.Dto;
using OMTechStation.PropertyPublicity.PP.States.Dto;
using OMTechStation.PropertyPublicity.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Models.Areas
{
    [AutoMapFrom(typeof(GetAreaForEditOutput))]

    public class EditAreaModalViewModel: GetAreaForEditOutput
    {

    }
}


