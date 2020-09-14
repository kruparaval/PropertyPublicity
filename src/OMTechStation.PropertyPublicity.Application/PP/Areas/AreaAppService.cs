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
using OMTechStation.PropertyPublicity.PP.Cities;
using Microsoft.AspNetCore.Mvc.Rendering;
using OMTechStation.PropertyPublicity.PP.States;

namespace OMTechStation.PropertyPublicity.PP.Areas.Dto
{
    public class AreaAppService : AsyncCrudAppService<Area, AreaDto, int, PageAreaResultRequestDto, CreateAreaDto, AreaDto>, IAreaAppService
    {
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Area> _areaRepository;

        public AreaAppService(IRepository<Area> areaRepository,
            IRepository<City> cityRepository) : base(areaRepository)
        {
            _cityRepository = cityRepository;
            _areaRepository = areaRepository;
        }

        protected override IQueryable<Area> CreateFilteredQuery(PageAreaResultRequestDto input)
        {
            return Repository.GetAll().Include(s => s.City).WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
        }

        protected override IQueryable<Area> ApplySorting(IQueryable<Area> query, PageAreaResultRequestDto input)
        {
            return (IQueryable<Area>)query.OrderBy(s => s.Name);
        }

        public async Task<GetAreaForEditOutput> GetAreaForEdit(EntityDto input)
        {
            var area = await _areaRepository.GetAsync(input.Id);
            var cities = _cityRepository.GetAll().Select(s => new SelectListItem() { Text = s.Name, Value = s.Id.ToString() }).ToList();
            var AreaEditDto = ObjectMapper.Map<AreaEditDto>(area);
            return new GetAreaForEditOutput
            {
                Area = AreaEditDto,
                Cities = cities,
               
            };
        }

        public async Task<ListResultDto<AreaListDto>> GetAreasAsync(GetAreaInput input)
        {
            var area = await Repository.GetAll().Include(s => s.City).WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    r => r.Name.Contains(input.Filter)
                ).ToListAsync();

            return new ListResultDto<AreaListDto>(ObjectMapper.Map<List<AreaListDto>>(area));
        }
    }
}