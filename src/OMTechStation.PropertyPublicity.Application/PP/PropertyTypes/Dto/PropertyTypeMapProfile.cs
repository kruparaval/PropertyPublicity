using AutoMapper;
using OMTechStation.PropertyPublicity.PP.Areas.Dto;
using OMTechStation.PropertyPublicity.PP.PropertyTypes.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.PropertyTypes.Dto
{
    public class PropertyTypeMapProfile : Profile
    {
        public PropertyTypeMapProfile()
        {
            //CreateMap<CreateCountryDto, Country>();
            //CreateMap<CountryDto, Country>();
            //CreateMap<CountryEditDto, Country>();
            //CreateMap<CountryListDto, Country>();
            //CreateMap<GetCountryForEditOutput, Country>();
            //CreateMap<GetCountryInput, Country>();
            //CreateMap<PageCountryResultRequestDto, Country>();         

            CreateMap<CreatePropertyTypeDto, PropertyType>();
            CreateMap<PropertyTypeDto, PropertyType>();
            CreateMap<PropertyType, PropertyTypeDto>();
            CreateMap<PropertyType, PropertyTypeListDto>();
            CreateMap<PropertyType, PropertyTypeEditDto>();
        }
    }
}

 