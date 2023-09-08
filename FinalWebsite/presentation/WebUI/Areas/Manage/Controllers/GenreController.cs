using FinalWebsite.Data.Entities;
using FinalWebsite.WebUI.View_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories.Abstract;

namespace FinalWebsite.WebUI.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "admin")]
    public class GenreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(int page = 1, int take = 6)
        {
            var genre = await _unitOfWork.GenreRepository.GetAllPaginatedAsync(page, take);
            PaginateVM<Genre> paginateVM = new PaginateVM<Genre>()
            {
                Items = genre,
                CurrentPage = page,
                Take = take,
                PageCount = GetPageCount(take)
            };
            return View(paginateVM);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Genre genre)
        {
            if (!ModelState.IsValid) { return View(); }
            if (genre == null) { ModelState.AddModelError("", "NotFound"); return View(); }
            await _unitOfWork.GenreRepository.Create(genre);
            await _unitOfWork.SaveChangeAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Genre? genre = await _unitOfWork.GenreRepository.GetAsync(x => x.Id == id);
            if (genre == null) { NotFound(); return View(); }
            GenreVM vM = new GenreVM()
            {
                Name = genre.Name
            };
            return View(vM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GenreVM genre)
        {
            if (genre == null) { NotFound(); return View(); }
            Genre? exists = await _unitOfWork.GenreRepository.GetAsync(x => x.Id == genre.Id);
            if (exists == null) { NotFound(); return View(); }
            exists.Name = genre.Name;
            await _unitOfWork.SaveChangeAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            Genre? genre = await _unitOfWork.GenreRepository.GetAsync(x => x.Id == id);
            if (genre == null) { NotFound(); return View(); }
            _unitOfWork.GenreRepository.Delete(genre);
            await _unitOfWork.SaveChangeAsync();
            return RedirectToAction(nameof(Index));
        }


        public int GetPageCount(int take)
        {
            var pageCount = _unitOfWork.GenreRepository.Count();
            return (int)Math.Ceiling((decimal)pageCount / take);
        }
    }
}