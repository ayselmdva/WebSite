using FinalWebsite.Business.DTOs.SearchDto;
using FinalWebsite.Business.Services.Abstract;
using FinalWebsite.Data.Entities;
using FinalWebsite.DataAccess.Repositories.Abstract;
using FinalWebsite.WebUI.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Security.Claims;
using System.Xml.Linq;
using WebApp.Repositories.Abstract;

namespace FinalWebsite.WebUI.Controllers
{
	public class MoviesController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMovieService _movieService;

        public MoviesController(IUnitOfWork unitOfWork, IMovieService movieService)
        {
            _unitOfWork = unitOfWork;
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
		{
			var movies = await _unitOfWork.MovieRepository.GetAllAsync(includes: new[] { "Director", "Genre", "Actors" });
			return View(movies);
			
		}


		public async Task<IActionResult> Detail(string name)
		{
			var movie = await _unitOfWork.MovieRepository.GetAsync(x => x.Name == name, includes: new[] { "Director", "Genre", "Actors" });
			if (movie == null) { NotFound(); }
			return View(movie);
		}


		public async Task<IActionResult> Whatch(string name)
		{
            if(name == null) { NotFound(); }
            var movie = await _unitOfWork.MovieRepository.GetAsync(x => x.Name == name, includes: new[] { "Director", "Genre", "Actors" });
            if (movie == null) { NotFound(); }
            return View(movie);
		}




        public async Task<IActionResult> Search(SearchDto search)
        {
            if (string.IsNullOrEmpty(search.Name)) return RedirectToAction(nameof(Index));
            if (search.GenreId == null)
            {

                var allMovies = await _movieService.Search(search.Name);
                /*List<SearchDto> movies = allMovies.Select(movieDto => new SearchDto
				{
					MovieName = movieDto.MovieName
				}).ToList();*/
                return ViewComponent("Search");
            }

            var specificMovie = await _movieService.SearchByGenre(search.Name, search.GenreId);

            /*List<SearchVM> specificMovies = specificMovie.Select(movieDto => new SearchVM
			{
				MovieName = movieDto.Name
			}).ToList();*/

            return View(specificMovie);

        }
    }
}