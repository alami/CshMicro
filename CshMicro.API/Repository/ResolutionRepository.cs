using AutoMapper;
using CshMicro.API.DdContexts;
using CshMicro.API.Entities;
using CshMicro.API.Entities.Dto;
using CshMicro.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CshMicro.API.Repository
{
    public class ResolutionRepository : IResolutionRepository
    {
        private readonly ApplicationDdContexts _db;
        private IMapper _mapper;

        public ResolutionRepository(ApplicationDdContexts db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ResolutionDto> GetResolutionById(int resolutionId)
        {
            Resolution resolution = await _db.Resolutions.Where(x => x.Id == resolutionId).FirstOrDefaultAsync();
            return _mapper.Map<ResolutionDto>(resolution);
        }

        public async Task<IEnumerable<ResolutionDto>> GetResolutions()
        {
            List<Resolution> resolutionList = await _db.Resolutions.ToListAsync();
            return _mapper.Map<List<ResolutionDto>>(resolutionList);
        }
        public async Task<ResolutionDto> CreateUpdateResolution(ResolutionDto resolutionDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteResolution(int resolutionId)
        {
            throw new NotImplementedException();
        }
    }
}
