using CshMicro.API.Entities.Dto;
using CshMicro.API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CshMicro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PeriodAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IPeriodRepository _periodRepository;

        public PeriodAPIController(IPeriodRepository periodRepository)
        {
            _periodRepository = periodRepository;
            this._response = new ResponseDto();
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<PeriodDto> periodDtos = await _periodRepository.GetPeriods();
                _response.Result = periodDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
