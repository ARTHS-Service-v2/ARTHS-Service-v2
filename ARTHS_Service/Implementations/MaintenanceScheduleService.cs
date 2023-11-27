using ARTHS_Data;
using ARTHS_Data.Models.Requests.Filters;
using ARTHS_Data.Models.Requests.Get;
using ARTHS_Data.Models.Views;
using ARTHS_Data.Repositories.Interfaces;
using ARTHS_Service.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace ARTHS_Service.Implementations
{
    public class MaintenanceScheduleService : BaseService, IMaintenanceScheduleSerivce
    {
        private readonly IMaintenanceScheduleRepository _maintenanceScheduleRepository;
        public MaintenanceScheduleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _maintenanceScheduleRepository = unitOfWork.MaintenanceSchedule;
        }

        public async Task<ListViewModel<MaintenanceScheduleViewModel>> GetMainTenanceSchedules(MaintenanceScheduleFilterModel filter, PaginationRequestModel pagination)
        {
            var query = _maintenanceScheduleRepository.GetAll().AsQueryable();
            if (filter.CustomerId.HasValue)
            {
                query = query.Where(m => m.CustomerId.Equals(filter.CustomerId.Value));
            }
            if (filter.OrderDetailId.HasValue)
            {
                query = query.Where(m => m.OrderDetailId.Equals(filter.OrderDetailId.Value));
            }
            var totalRow = await query.AsNoTracking().CountAsync();
            var paginatedQuery = query
               .Skip(pagination.PageNumber * pagination.PageSize)
               .Take(pagination.PageSize);
            var schedules = await paginatedQuery
                .ProjectTo<MaintenanceScheduleViewModel>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
            return new ListViewModel<MaintenanceScheduleViewModel>
            {
                Pagination = new PaginationViewModel
                {
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    TotalRow = totalRow
                },
                Data = schedules
            };
        }
    }
}
