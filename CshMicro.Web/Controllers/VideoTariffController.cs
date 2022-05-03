using CshMicro.Web.Entities.Dto;
using CshMicro.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CshMicro.Web.Controllers
{
    public class VideoTariffController : Controller
    {
        private readonly IVideoTariffService _videoTariffService;
        public VideoTariffController(IVideoTariffService videoTariffService)
        {
            _videoTariffService = videoTariffService;
        }
        public async Task<IActionResult> VideoTariffIndex()
        {
            List<VideoTariffDto> list = new();
            var response = await _videoTariffService.GetAllVideoTariffsAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VideoTariffDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
