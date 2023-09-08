using FinalWebsite.Business.DTO_s.ActorDto_s;
using FinalWebsite.Business.DTOs.ActorDtos;
using FinalWebsite.Data.Entities;
namespace FinalWebsite.Business.Services.Abstract
{
    public interface IActorService
    {
        Task Create(ActorPostDto actorPostDto);
        Task Update(Actor actor);
        Task Delete(Actor actor);
        Task<ActorGetDto> GetAsync(int id);
        Task<List<ActorGetDto>> GetAllAsync();
        Task<List<Actor>> GetAllPaginatedAsync(int page, int take);
        int GetActorPageCount(int take);
    }
}
