using CshMicro.API.Entities.Dto;
using CshMicro.API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CshMicro.API.Controllers
{
    [Route("api/resolutions")]
    [ApiController]

    public class ResolutionAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IResolutionRepository _resolutionRepository;

        public ResolutionAPIController(IResolutionRepository resolutionRepository)
        {
            _resolutionRepository = resolutionRepository;
            this._response = new ResponseDto();
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ResolutionDto> resolutionDtos = await _resolutionRepository.GetResolutions();
                _response.Result = resolutionDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ResolutionDto resolutionDto = await _resolutionRepository.GetResolutionById(id);
                _response.Result = resolutionDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        public async Task<object> Post([FromBody] ResolutionDto resolutionDto)
        {
            try
            {
                ResolutionDto model = await _resolutionRepository.CreateUpdateResolution(resolutionDto);
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


        [HttpPut]
        public async Task<object> Put([FromBody] ResolutionDto resolutionDto)
        {
            try
            {
                ResolutionDto model = await _resolutionRepository.CreateUpdateResolution(resolutionDto);
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

        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _resolutionRepository.DeleteResolution(id);
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
