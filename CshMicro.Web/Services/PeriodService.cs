using CshMicro.Web.Entities;
using CshMicro.Web.Entities.Dto;
using CshMicro.Web.Services.IServices;

namespace CshMicro.Web.Services
{
    public class PeriodService : BaseService, IPeriodService
    {
        private readonly IHttpClientFactory _clientFactory;
        public PeriodService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreatePeriodAsync<T>(PeriodDto periodDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = periodDto,
                Url = SD.VideoTariffAPIBase + "/api/periods",
                AccessToken = ""
            });
        }

        public async Task<T> DeletePeriodAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.VideoTariffAPIBase + "/api/periods/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllPeriodsAsync<T>()
        {
            var a1 = SD.ApiType.GET;
            var a2 = SD.VideoTariffAPIBase + "/api/periods";
            var a3 = new ApiRequest()
            {
                ApiType = a1,
                Url = a2,
                AccessToken = ""
            };

            return await this.SendAsync<T>(a3);
        }

        public async Task<T> GetPeriodByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.VideoTariffAPIBase + "/api/periods/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdatePeriodAsync<T>(PeriodDto periodDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = periodDto,
                Url = SD.VideoTariffAPIBase + "/api/periods",
                AccessToken = ""
            });
        }
    }
}
