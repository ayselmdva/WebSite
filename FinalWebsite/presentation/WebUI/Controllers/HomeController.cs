using FinalWebsite.WebUI.View_Models;
using JwtExample.Data.DataAccess;
using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories.Abstract;

namespace FinalWebsite.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;

        public HomeController(IUnitOfWork unitOfWorkt)
        {
            _unitOfWork = unitOfWorkt;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM()
            {
                Movies = await _unitOfWork.MovieRepository.GetAllAsync(includes: new[] { "Director", "Genre", "Actors" }),
                Actors = await _unitOfWork.ActorRepository.GetAllAsync(includes: new[] { "Movies" }),
                Genres=await _unitOfWork.GenreRepository.GetAllAsync(includes: new[] { "Movies" })
            };
            return View(vm);
        }

        public async Task<IActionResult> FindByGenre(string genreName)
        {
            var genre = await _unitOfWork.GenreRepository.GetAsync(x => x.Name == genreName, includes: new[] { "Movies"});
            if (genre == null) { return NotFound(); }
            HomeVM vm = new HomeVM()
            {
                Genre=genre,
                Movies = genre.Movies
            };
            return View(vm);

        }



        public async Task<IActionResult> Search(SearchVM search)
        {
            if (string.IsNullOrEmpty(search.MovieName)) return RedirectToAction(nameof(Index));

            var allMovie = await _unitOfWork.MovieRepository.GetAllAsync(x=>x.Name.Trim().ToLower().StartsWith(search.MovieName.ToLower().Trim()), includes: new[] { "Director", "Genre", "Actors" });

            var specificMovie = await _unitOfWork.MovieRepository
                .GetAllAsync(x => x.Id == search.GenreId &&
                x.Name.Trim().ToLower().StartsWith(search.MovieName.ToLower().Trim()), includes: new[] { "Director", "Genre", "Actors" });

			var searchVM = new SearchVM
			{
				Movies =( search.GenreId == null ? allMovie : specificMovie)
			};

			return View(searchVM);
        }
    }
}