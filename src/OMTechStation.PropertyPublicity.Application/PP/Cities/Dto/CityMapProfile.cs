using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.Cities.Dto
{
    public class CityMapProfile : Profile
    {
        public CityMapProfile()
        {
            //CreateMap<CreateCountryDto, Country>();
            //CreateMap<CountryDto, Country>();
            //CreateMap<CountryEditDto, Country>();
            //CreateMap<CountryListDto, Country>();
            //CreateMap<GetCountryForEditOutput, Country>();
            //CreateMap<GetCountryInput, Country>();
            //CreateMap<PageCountryResultRequestDto, Country>();         

            CreateMap<CreateCityDto, City>();
            CreateMap<CityDto, City>();
            CreateMap<City, CityDto>();
            CreateMap<City, CityListDto>();
            CreateMap<City, CityEditDto>();
        }
    }
}

 