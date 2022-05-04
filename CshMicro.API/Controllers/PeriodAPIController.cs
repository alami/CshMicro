using CshMicro.API.Entities.Dto;
using CshMicro.API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CshMicro.API.Controllers
{
    [Route("api/periods")]
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
        [Authorize]
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
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                PeriodDto periodDto = await _periodRepository.GetPeriodById(id);
                _response.Result = periodDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [Authorize]
        [HttpPost]
        public async Task<object> Post([FromBody] PeriodDto periodDto)
        {
            try
            {
                PeriodDto model = await _periodRepository.CreateUpdatePeriod(periodDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [Authorize]
        [HttpPut]
        public async Task<object> Put([FromBody] PeriodDto periodDto)
        {
            try
            {
                PeriodDto model = await _periodRepository.CreateUpdatePeriod(periodDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _periodRepository.DeletePeriod(id);
                _response.Result = isSuccess;
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
