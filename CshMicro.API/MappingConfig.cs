using AutoMapper;
using CshMicro.API.Entities;
using CshMicro.API.Entities.Dto;

namespace CshMicro.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<VideoTariffDto, VideoTariff>();
                config.CreateMap<VideoTariff, VideoTariffDto>();
                config.CreateMap<PeriodDto, Period>();
                config.CreateMap<Period, PeriodDto>();
                config.CreateMap<ResolutionDto, Resolution>();
                config.CreateMap<Resolution, ResolutionDto>();
            });

            return mappingConfig;
        }
    }
}
