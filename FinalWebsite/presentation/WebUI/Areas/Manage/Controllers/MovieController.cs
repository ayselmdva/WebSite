using FinalWebsite.Business.Utilites;
using FinalWebsite.Data.Entities;
using FinalWebsite.WebUI.View_Models;
using JwtExample.Data.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories.Abstract;

namespace FinalWebsite.WebUI.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "admin")]
    public class MovieController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;

		public MovieController(IUnitOfWork unitOfWork, IWebHostEnvironment environment, AppDbContext context)
		{
			_unitOfWork = unitOfWork;
			_environment = environment;
			_context = context;
		}

		public async Task<IActionResult> Index(int page = 1, int take = 3)
        {
            var movies = await _unitOfWork.MovieRepository.GetAllPaginatedAsync(page, take, includes: new[] { "Director", "Genre", "Actors" });
            PaginateVM<Movie> paginateVM = new PaginateVM<Movie>()
            {
                Items = movies,
                CurrentPage = page,
                Take = take,
                PageCount = GetPageCount(take)
            };
            return View(paginateVM);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Directors = await _unitOfWork.DirectorRepository.GetAllAsync();
            ViewBag.Actors = await _unitOfWork.ActorRepository.GetAllAsync();
            ViewBag.Genres = await _unitOfWork.GenreRepository.GetAllAsync();

            return View();
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Create(MovieVM movie)
        {
            ViewBag.Directors = await _unitOfWork.DirectorRepository.GetAllAsync();
            ViewBag.Actors = await _unitOfWork.ActorRepository.GetAllAsync();
            ViewBag.Genres = await _unitOfWork.GenreRepository.GetAllAsync();
            if (!ModelState.IsValid) { return View(); }
            if (movie == null) { ModelState.AddModelError("", "NotFound"); return View(); }
            if (!movie.ImageFile.CheckFileType("image")) { ModelState.AddModelError("", "Must be image file"); return View(); }
            if (movie.ImageFile.CheckFileSize(2000)) { ModelState.AddModelError("", "Must be less 2000 file size"); return View(); }
            string fileName = await movie.ImageFile.SaveFileAsync(_environment.WebRootPath);
            movie.Image = fileName;
            if (!movie.VideoFile.CheckFileType("video")) { ModelState.AddModelError("", "Must be video file"); return View(); }
            if (movie.VideoFile.CheckFileSize(200000)) { ModelState.AddModelError("", "Must be less 2000 file size"); return View(); }
            string VideoFileName=await movie.VideoFile.SaveFileAsync(_environment.WebRootPath);
            movie.Video = VideoFileName;

            var actors = await _unitOfWork.ActorRepository.GetAllAsync(x => movie.ActorIds.Contains(x.Id));
            movie.Actors = new List<Actor>();
            foreach(var actor in actors)
            {
                movie.Actors.Add(actor);
            }
            if(movie.Rate<0 || movie.Year<0) { return BadRequest(); }
            Movie movieC = new Movie() 
            { 
                Name= movie.Name,
                Actors=movie.Actors,
                Description=movie.Description,
                Director=movie.Director,
                DirectorId=movie.DirectorId,
                Genre=movie.Genre,
                GenreId =movie.GenreId,
                RunTime = movie.RunTime,
                Rate = movie.Rate,
                Image=movie.Image,
                ImageFile=movie.ImageFile,
                Video=movie.Video,
                VideoFile=movie.VideoFile,
                Year = movie.Year,

            };



            await _unitOfWork.MovieRepository.Create(movieC);
            await _unitOfWork.SaveChangeAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Directors = await _unitOfWork.DirectorRepository.GetAllAsync();
            ViewBag.Actors = await _unitOfWork.ActorRepository.GetAllAsync();
            ViewBag.Genres = await _unitOfWork.GenreRepository.GetAllAsync();

            Movie? exists = await _unitOfWork.MovieRepository.GetAsync(x => x.Id == id, includes: new[] { "Director", "Genre", "Actors" });
            if (exists == null) { NotFound(); return View(); }

            List<int>actorIds = new List<int>();
            if (exists.Actors != null)
            {
                foreach (var actor in exists.Actors)
                {
                    actorIds.Add(actor.Id);
                }
            }

            if (exists.Rate < 0 ||  exists.Year < 0) { return BadRequest(); }

            MovieVM movieVM = new MovieVM()
            {
                Id=exists.Id,
                Name = exists.Name,
                Description = exists.Description,
                RunTime = exists.RunTime,
                Rate = exists.Rate,
                Director = exists.Director,
                DirectorId = exists.DirectorId,
                Genre = exists.Genre,
                GenreId = exists.GenreId,
                Year = exists.Year,
                ActorIds = actorIds
                
            };
            
            return View(movieVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MovieVM movie)
        {
            if (movie == null) { NotFound(); return View(); }
            Movie? exists = await _unitOfWork.MovieRepository.GetAsync(x => x.Id == movie.Id);
            if (exists == null) { NotFound(); return View(); }
            exists.Name = movie.Name;
            exists.Description = movie.Description;
            exists.RunTime = movie.RunTime;
            exists.Rate = movie.Rate;
            exists.Director = movie.Director;
            exists.DirectorId = movie.DirectorId;
            exists.Genre = movie.Genre;
            exists.GenreId = movie.GenreId;
            exists.Year= movie.Year;

            var actors = await _unitOfWork.ActorRepository.GetAllAsync(x => movie.ActorIds.Contains(x.Id));
            movie.Actors = new List<Actor>();
            foreach (var actor in actors)
            {
                movie.Actors.Add(actor);
            }

            if (movie.ImageFile != null)
            {
                if (!movie.ImageFile.CheckFileType("image")) { ModelState.AddModelError("", "Must be image file"); return View(); }
                if (movie.ImageFile.CheckFileSize(2000)) { ModelState.AddModelError("", "Must be less 2000 file size"); return View(); }
                exists.ImageFile.DeleteFile(_environment.WebRootPath, exists.Image);
                string fileName = await movie.ImageFile.SaveFileAsync(_environment.WebRootPath);
                exists.Image = fileName;
            }
            if(movie.VideoFile!= null)
            {
                if (!movie.VideoFile.CheckFileType("video")) { ModelState.AddModelError("", "Must be video file"); return View(); }
                if (movie.VideoFile.CheckFileSize(200000)) { ModelState.AddModelError("", "Must be less 2000 file size"); return View(); }
                exists.VideoFile.DeleteFile(_environment.WebRootPath,exists.Video);
                string VideoFileName = await movie.VideoFile.SaveFileAsync(_environment.WebRootPath);
                movie.Video = VideoFileName;
            }

           /* Movie movieC = new Movie()
            {
                Name = movie.Name,
                Actors = movie.Actors,
                Description = movie.Description,
                Director = movie.Director,
                DirectorId = movie.DirectorId,
                Genre = movie.Genre,
                GenreId = movie.GenreId,
                RunTime = movie.RunTime,
                Rate = movie.Rate,
                Image = movie.Image,
                ImageFile = movie.ImageFile,
                Video = movie.Video,
                VideoFile = movie.VideoFile,
                Year = movie.Year

            };*/
            /*await _unitOfWork.MovieRepository.Update(movieC);*/
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            Movie? movie = await _unitOfWork.MovieRepository.GetAsync(x => x.Id == id);
            if (movie == null) { NotFound(); return View(); }
            _unitOfWork.MovieRepository.Delete(movie);
           /* movie.ImageFile.DeleteFile(_environment.WebRootPath, movie.Image);
            movie.VideoFile.DeleteFile(_environment.WebRootPath, movie.Video);*/
            await _unitOfWork.SaveChangeAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            
            var movie = await _unitOfWork.MovieRepository.GetAsync(x => x.Id == id, includes: new[] { "Director", "Genre", "Actors" });
            if(movie == null) { NotFound();}
            return View(movie);
        }

        public int GetPageCount(int take)
        {
            var pageCount = _unitOfWork.MovieRepository.Count();
            return (int)Math.Ceiling((decimal)pageCount / take);
        }
    }
}