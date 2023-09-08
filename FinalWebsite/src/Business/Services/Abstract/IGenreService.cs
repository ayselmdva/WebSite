using FinalWebsite.Business.DTO_s.ActorDto_s;
using FinalWebsite.Data.Entities;

namespace FinalWebsite.Business.Services.Abstract
{
    public interface IGenreService
    {
		Task Create(ActorPostDto actorPostDto);
		Task Update(Genre genre);
		Task Delete(Genre genre);
		/*Task<ActorGetDto> GetAsync(int id);
		Task<List<ActorGetDto>> GetAllAsync();*/
		Task<List<Actor>> GetAllPaginatedAsync(int page, int take);
		int GetActorPageCount(int take);
	}
}
