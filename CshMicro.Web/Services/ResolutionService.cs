using CshMicro.Web.Entities;
using CshMicro.Web.Entities.Dto;
using CshMicro.Web.Services.IServices;

namespace CshMicro.Web.Services
{
    public class ResolutionService : BaseService, IResolutionService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ResolutionService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateResolutionAsync<T>(ResolutionDto resolutionDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = resolutionDto,
                Url = SD.VideoTariffAPIBase + "/api/resolutions",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteResolutionAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.VideoTariffAPIBase + "/api/resolutions/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllResolutionsAsync<T>()
        {
            var a1 = SD.ApiType.GET;
            var a2 = SD.VideoTariffAPIBase + "/api/resolutions";
            var a3 = new ApiRequest()
            {
                ApiType = a1,
                Url = a2,
                AccessToken = ""
            };

            return await this.SendAsync<T>(a3);
        }

        public async Task<T> GetResolutionByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.VideoTariffAPIBase + "/api/resolutions/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateResolutionAsync<T>(ResolutionDto resolutionDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = resolutionDto,
                Url = SD.VideoTariffAPIBase + "/api/resolutions",
                AccessToken = ""
            });
        }
    }
}
