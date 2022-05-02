using CshMicro.API.Entities.Dto;

namespace CshMicro.API.Repository.IRepository
{
    public interface IResolutionRepository
    {
        Task<IEnumerable<ResolutionDto>> GetResolutions();
        Task<ResolutionDto> GetResolutionById(int resolutionId);
        Task<ResolutionDto> CreateUpdateResolution(ResolutionDto resolutionDto);
        Task<bool> DeleteResolution(int resolutionId);
    }
}
