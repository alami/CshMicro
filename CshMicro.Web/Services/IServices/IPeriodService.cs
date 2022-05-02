using CshMicro.Web.Entities.Dto;

namespace CshMicro.Web.Services.IServices
{
    public interface IPeriodService : IBaseService
    {
        Task<T> GetAllPeriodsAsync<T>();
        Task<T> GetPeriodByIdAsync<T>(int id);
        Task<T> CreatePeriodAsync<T>(PeriodDto periodDto);
        Task<T> UpdatePeriodAsync<T>(PeriodDto periodDto);
        Task<T> DeletePeriodAsync<T>(int id);
    }
}
