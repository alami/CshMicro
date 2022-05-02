using CshMicro.API.Entities.Dto;

namespace CshMicro.API.Repository.IRepository
{
    public interface IPeriodRepository
    {
        Task<IEnumerable<PeriodDto>> GetPeriods();
        Task<PeriodDto> GetPeriodById(int periodId);
        Task<PeriodDto> CreateUpdatePeriod(PeriodDto periodDto);
        Task<bool> DeletePeriod(int periodId);
    }
}
