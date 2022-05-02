using CshMicro.Web.Entities.Dto;

namespace CshMicro.Web.Services.IServices
{
    public interface IVideoTariffService : IBaseService
    {
        Task<T> GetAllVideoTariffsAsync<T>();
        Task<T> GetVideoTariffByIdAsync<T>(int id);
        Task<T> CreateVideoTariffAsync<T>(VideoTariffDto videoTariffDto);
        Task<T> UpdateVideoTariffAsync<T>(VideoTariffDto videoTariffDto);
        Task<T> DeleteVideoTariffAsync<T>(int id);
    }
}
