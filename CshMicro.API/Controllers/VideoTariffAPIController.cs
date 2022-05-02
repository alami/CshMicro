using CshMicro.API.Entities.Dto;
using CshMicro.API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CshMicro.API.Controllers
{
    [Route("api/videoTariffs")]
    [ApiController]

    public class VideoTariffAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IVideoTariffRepository _videoTariffRepository;

        public VideoTariffAPIController(IVideoTariffRepository videoTariffRepository)
        {
            _videoTariffRepository = videoTariffRepository;
            this._response = new ResponseDto();
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<VideoTariffDto> videoTariffDtos = await _videoTariffRepository.GetVideoTariffs();
                _response.Result = videoTariffDtos;
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
                VideoTariffDto videoTariffDto = await _videoTariffRepository.GetVideoTariffById(id);
                _response.Result = videoTariffDto;
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
        public async Task<object> Post([FromBody] VideoTariffDto videoTariffDto)
        {
            try
            {
                VideoTariffDto model = await _videoTariffRepository.CreateUpdateVideoTariff(videoTariffDto);
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
        public async Task<object> Put([FromBody] VideoTariffDto videoTariffDto)
        {
            try
            {
                VideoTariffDto model = await _videoTariffRepository.CreateUpdateVideoTariff(videoTariffDto);
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
                bool isSuccess = await _videoTariffRepository.DeleteVideoTariff(id);
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
