using AutoMapper;
using OMTechStation.PropertyPublicity.PP.Areas.Dto;
using OMTechStation.PropertyPublicity.PP.PropertyTypes.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Aminities.Dto
{
    public class AminityMapProfile : Profile
    {
        public AminityMapProfile()
        {
            //CreateMap<CreateCountryDto, Country>();
            //CreateMap<CountryDto, Country>();
            //CreateMap<CountryEditDto, Country>();
            //CreateMap<CountryListDto, Country>();
            //CreateMap<GetCountryForEditOutput, Country>();
            //CreateMap<GetCountryInput, Country>();
            //CreateMap<PageCountryResultRequestDto, Country>();         

            CreateMap<CreateAminityDto, Aminity>();
            CreateMap<AminityDto, Aminity>();
            CreateMap<Aminity, AminityDto>();
            CreateMap<Aminity, AminityListDto>();
            CreateMap<Aminity, AminityEditDto>();
        }
    }
}

 