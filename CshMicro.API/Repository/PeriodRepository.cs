using AutoMapper;
using CshMicro.API.DdContexts;
using CshMicro.API.Entities;
using CshMicro.API.Entities.Dto;
using CshMicro.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CshMicro.API.Repository
{
    public class PeriodRepository : IPeriodRepository
    {
        private readonly ApplicationDdContexts _db;
        private IMapper _mapper;

        public PeriodRepository(ApplicationDdContexts db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<PeriodDto> GetPeriodById(int periodId)
        {
            Period period = await _db.Periods.Where(x => x.Id == periodId).FirstOrDefaultAsync();
            return _mapper.Map<PeriodDto>(period);
        }

        public async Task<IEnumerable<PeriodDto>> GetPeriods()
        {
            List<Period> periodList = await _db.Periods.ToListAsync();
            return _mapper.Map<List<PeriodDto>>(periodList);
        }
        public async Task<PeriodDto> CreateUpdatePeriod(PeriodDto periodDto)
        {
            Period period = _mapper.Map<PeriodDto, Period>(periodDto);
            if (period.Id > 0)
            {
                _db.Periods.Update(period);
            }
            else
            {
                _db.Periods.Add(period);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Period, PeriodDto>(period);
        }

        public async Task<bool> DeletePeriod(int periodId)
        {
            try
            {
                Period period = await _db.Periods.FirstOrDefaultAsync(u => u.Id == periodId);
                if (period == null)
                {
                    return false;
                }
                _db.Periods.Remove(period);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
