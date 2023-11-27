using ARTHS_Data.Models.Requests.Filters;
using ARTHS_Data.Models.Requests.Get;
using ARTHS_Data.Models.Views;
using ARTHS_Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ARTHS_API.Controllers
{
    [Route("api/maintanance-schedules")]
    [ApiController]
    public class MaintenanceSchedulesController : ControllerBase
    {
        private readonly IMaintenanceScheduleSerivce _maintenanceScheduleSerivce;

        public MaintenanceSchedulesController(IMaintenanceScheduleSerivce maintenanceScheduleSerivce)
        {
            _maintenanceScheduleSerivce = maintenanceScheduleSerivce;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ListViewModel<MaintenanceScheduleViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ListViewModel<MaintenanceScheduleViewModel>>> GetMaintanenceSchedules([FromQuery] MaintenanceScheduleFilterModel filter, [FromQuery] PaginationRequestModel pagination)
        {
            return await _maintenanceScheduleSerivce.GetMainTenanceSchedules(filter, pagination);
        }
    }
}
