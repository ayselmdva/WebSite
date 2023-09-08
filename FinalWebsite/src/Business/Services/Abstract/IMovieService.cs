
using FinalWebsite.Business.DTOs.SearchDto;

namespace FinalWebsite.Business.Services.Abstract
{
    public interface IMovieService
    {
	  Task<List<SearchDto>> Search(string search);
	  Task<List<SearchDto>> SearchByGenre(string search, int? id);

	}
}
