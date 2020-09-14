using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Areas.Dto
{
    public class AreaMapProfile : Profile
    {
        public AreaMapProfile()
        {
            //CreateMap<CreateCountryDto, Country>();
            //CreateMap<CountryDto, Country>();
            //CreateMap<CountryEditDto, Country>();
            //CreateMap<CountryListDto, Country>();
            //CreateMap<GetCountryForEditOutput, Country>();
            //CreateMap<GetCountryInput, Country>();
            //CreateMap<PageCountryResultRequestDto, Country>();         

            CreateMap<CreateAreaDto, Area>();
            CreateMap<AreaDto, Area>();
            CreateMap<Area, AreaDto>();
            CreateMap<Area, AreaListDto>();
            CreateMap<Area, AreaEditDto>();
        }
    }
}

 