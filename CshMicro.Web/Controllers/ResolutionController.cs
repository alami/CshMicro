using CshMicro.Web.Entities.Dto;
using CshMicro.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CshMicro.Web.Controllers
{
    public class ResolutionController : Controller
    {
        private readonly IResolutionService _resolutionService;
        public ResolutionController(IResolutionService resolutionService)
        {
            _resolutionService = resolutionService;
        }
        public async Task<IActionResult> ResolutionIndex()
        {
            List<ResolutionDto> list = new();
            var response = await _resolutionService.GetAllResolutionsAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ResolutionDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
