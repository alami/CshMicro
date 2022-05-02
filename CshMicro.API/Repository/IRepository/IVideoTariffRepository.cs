using CshMicro.API.Entities.Dto;

namespace CshMicro.API.Repository.IRepository
{
    public interface IVideoTariffRepository
    {
        Task<IEnumerable<VideoTariffDto>> GetVideoTariffs();
        Task<VideoTariffDto> GetVideoTariffById(int videoTariffId);
        Task<VideoTariffDto> CreateUpdateVideoTariff(VideoTariffDto videoTariffDto);
        Task<bool> DeleteVideoTariff(int videoTariffId);
    }
}
