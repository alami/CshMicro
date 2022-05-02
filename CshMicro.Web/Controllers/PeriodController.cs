using CshMicro.Web.Entities.Dto;
using CshMicro.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CshMicro.Web.Controllers
{
    public class PeriodController : Controller
    {
        private readonly IPeriodService _periodService;
        public PeriodController(IPeriodService periodService)
        {
            _periodService = periodService;
        }
        public async Task<IActionResult> PeriodIndex()
        {
            List<PeriodDto> list = new();
            var response = await _periodService.GetAllPeriodsAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<PeriodDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
