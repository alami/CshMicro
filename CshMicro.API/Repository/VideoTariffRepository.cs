using AutoMapper;
using CshMicro.API.DdContexts;
using CshMicro.API.Entities;
using CshMicro.API.Entities.Dto;
using CshMicro.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CshMicro.API.Repository
{
    public class VideoTariffRepository : IVideoTariffRepository
    {
        private readonly ApplicationDdContexts _db;
        private IMapper _mapper;

        public VideoTariffRepository(ApplicationDdContexts db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<VideoTariffDto> GetVideoTariffById(int videoTariffId)
        {
            VideoTariff videoTariff = await _db.VideoTariffs.Where(x => x.Id == videoTariffId).FirstOrDefaultAsync();
            return _mapper.Map<VideoTariffDto>(videoTariff);
        }

        public async Task<IEnumerable<VideoTariffDto>> GetVideoTariffs()
        {
            List<VideoTariff> videoTariffList = await _db.VideoTariffs.ToListAsync();
            return _mapper.Map<List<VideoTariffDto>>(videoTariffList);
        }
        public async Task<VideoTariffDto> CreateUpdateVideoTariff(VideoTariffDto videoTariffDto)
        {
            VideoTariff videoTariff = _mapper.Map<VideoTariffDto, VideoTariff>(videoTariffDto);
            if (videoTariff.Id > 0)
            {
                _db.VideoTariffs.Update(videoTariff);
            }
            else
            {
                _db.VideoTariffs.Add(videoTariff);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<VideoTariff, VideoTariffDto>(videoTariff);
        }

        public async Task<bool> DeleteVideoTariff(int videoTariffId)
        {
            try
            {
                VideoTariff videoTariff = await _db.VideoTariffs.FirstOrDefaultAsync(u => u.Id == videoTariffId);
                if (videoTariff == null)
                {
                    return false;
                }
                _db.VideoTariffs.Remove(videoTariff);
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
