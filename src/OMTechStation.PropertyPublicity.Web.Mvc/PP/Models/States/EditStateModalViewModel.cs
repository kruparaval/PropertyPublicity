using Abp.AutoMapper;
using OMTechStation.PropertyPublicity.PP.States.Dto;
using OMTechStation.PropertyPublicity.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMTechStation.PropertyPublicity.Web.PP.Models.States
{
    [AutoMapFrom(typeof(GetStateForEditOutput))]

    public class EditStateModalViewModel: GetStateForEditOutput
    {

    }
}


