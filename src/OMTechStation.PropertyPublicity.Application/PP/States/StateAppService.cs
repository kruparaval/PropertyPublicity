using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OMTechStation.PropertyPublicity.Authorization.Roles;
using OMTechStation.PropertyPublicity.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OMTechStation.PropertyPublicity.PP.States.Dto
{
    public class StateAppService : AsyncCrudAppService<State, StateDto, int, PageStateResultRequestDto, CreateStateDto, StateDto>, IStateAppService
    {
        private readonly IRepository<State> _stateRepository;
        private readonly IRepository<Country> _countryRepository;

        public StateAppService(IRepository<State> stateRepository,
            IRepository<Country> countryRepository) : base(stateRepository)
        {
            _stateRepository = stateRepository;
            _countryRepository = countryRepository;
        }
        public override async Task<StateDto> CreateAsync(CreateStateDto input)
        {
            var state = ObjectMapper.Map<State>(input);
            await Repository.InsertAsync(state);
            return MapToEntityDto(state);
        }

        protected override IQueryable<State> CreateFilteredQuery(PageStateResultRequestDto input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
        }

        protected override async Task<State> GetEntityByIdAsync(int id)
        {
            return await Repository.FirstOrDefaultAsync(x => x.Id == id);
        }

        protected override IQueryable<State> ApplySorting(IQueryable<State> query, PageStateResultRequestDto input) => query.OrderBy(s => s.Name);

        public async Task<GetStateForEditOutput> GetStateForEdit(EntityDto input)
        {
            var state = await _stateRepository.GetAsync(input.Id);
            var countries = _countryRepository.GetAll().Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() }).ToList();
            var StateEditDto = ObjectMapper.Map<StateEditDto>(state);
            return new GetStateForEditOutput
            {
                State = StateEditDto,
                Countries = countries
            };
        }

        public async Task<ListResultDto<StateListDto>> GetStatesAsync(GetStateInput input)
        {
            var state = await Repository.GetAll().Include(s => s.Country).WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    r => r.Name.Contains(input.Filter)
                ).ToListAsync();

            return new ListResultDto<StateListDto>(ObjectMapper.Map<List<StateListDto>>(state));
        }
    }
}                                                                                                                                                               