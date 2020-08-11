using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMTechStation.PropertyPublicity.PP.States.Dto
{
    public class StateMapProfile : Profile
    {
        public StateMapProfile()
        {
            //CreateMap<CreateCountryDto, Country>();
            //CreateMap<CountryDto, Country>();
            //CreateMap<CountryEditDto, Country>();
            //CreateMap<CountryListDto, Country>();
            //CreateMap<GetCountryForEditOutput, Country>();
            //CreateMap<GetCountryInput, Country>();
            //CreateMap<PageCountryResultRequestDto, Country>();         

            CreateMap<CreateStateDto, State>();
            CreateMap<StateDto, State>();
            CreateMap<State, StateDto>();
            CreateMap<State, StateListDto>();
            CreateMap<State, StateEditDto>();
        }
    }
}

 