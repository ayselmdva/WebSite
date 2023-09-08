using AutoMapper;
using FinalWebsite.Business.DTO_s.ActorDto_s;
using FinalWebsite.Business.DTOs.ActorDtos;
using FinalWebsite.Business.DTOs.MovieDtos;
using FinalWebsite.Business.DTOs.SearchDto;
using FinalWebsite.Data.Entities;

namespace FinalWebsite.Business.Mappings
{
    public class MappingProfiler:Profile
    {
        public MappingProfiler()
        {
            CreateMap<ActorPostDto,Actor>();
            CreateMap<ActorGetDto,Actor>();
            CreateMap<SearchDto,Movie>();
            CreateMap<Movie, SearchDto>();
        }
    }
}
