using CshMicro.Web.Entities;
using CshMicro.Web.Entities.Dto;
using CshMicro.Web.Services.IServices;

namespace CshMicro.Web.Services
{
    public class VideoTariffService : BaseService, IVideoTariffService
    {
        private readonly IHttpClientFactory _clientFactory;
        public VideoTariffService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateVideoTariffAsync<T>(VideoTariffDto videoTariffDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = videoTariffDto,
                Url = SD.VideoTariffAPIBase + "/api/videoTariffs",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteVideoTariffAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.VideoTariffAPIBase + "/api/videoTariffs/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllVideoTariffsAsync<T>()
        {
            var a1 = SD.ApiType.GET;
            var a2 = SD.VideoTariffAPIBase + "/api/videoTariffs";
            var a3 = new ApiRequest()
            {
                ApiType = a1,
                Url = a2,
                AccessToken = ""
            };

            return await this.SendAsync<T>(a3);
        }

        public async Task<T> GetVideoTariffByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.VideoTariffAPIBase + "/api/videoTariffs/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateVideoTariffAsync<T>(VideoTariffDto videoTariffDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = videoTariffDto,
                Url = SD.VideoTariffAPIBase + "/api/videoTariffs",
                AccessToken = ""
            });
        }
    }
}
