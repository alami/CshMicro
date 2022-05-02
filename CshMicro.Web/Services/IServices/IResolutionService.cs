using CshMicro.Web.Entities.Dto;

namespace CshMicro.Web.Services.IServices
{
    public interface IResolutionService : IBaseService
    {
        Task<T> GetAllResolutionsAsync<T>();
        Task<T> GetResolutionByIdAsync<T>(int id);
        Task<T> CreateResolutionAsync<T>(ResolutionDto resolutionDto);
        Task<T> UpdateResolutionAsync<T>(ResolutionDto resolutionDto);
        Task<T> DeleteResolutionAsync<T>(int id);
    }
}
