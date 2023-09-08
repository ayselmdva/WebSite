using FinalWebsite.Data.Entities;
using FinalWebsite.Business.Utilites;
using FinalWebsite.WebUI.View_Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace FinalWebsite.WebUI.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles ="admin")]
    public class ActorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;

        public ActorController(IWebHostEnvironment environment, IUnitOfWork unitOfWork)
        {
            _environment = environment;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(int page = 1, int take = 4)
        {
            var actors = await _unitOfWork.ActorRepository.GetAllPaginatedAsync(page, take);
            PaginateVM<Actor> paginateVM = new PaginateVM<Actor>()
            {
                Items = actors,
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
        public async Task<IActionResult> Create(Actor actor)
        {
            if (!ModelState.IsValid) { return View(); }
            if (actor == null) { ModelState.AddModelError("", "NotFound"); return View(); }
            if (!actor.ImageFile.CheckFileType("image")) { ModelState.AddModelError("", "Must be image file"); return View(); }
            if (actor.ImageFile.CheckFileSize(2000)) { ModelState.AddModelError("", "Must be less 2000 file size"); return View(); }
            string fileName = await actor.ImageFile.SaveFileAsync(_environment.WebRootPath);
            actor.Image = fileName;
            await _unitOfWork.ActorRepository.Create(actor);
            await _unitOfWork.SaveChangeAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Actor? actor = await _unitOfWork.ActorRepository.GetAsync(x => x.Id == id);
            if (actor == null) { NotFound(); return View(); }
            return View(actor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Actor actor)
        {
            if (actor == null) { NotFound(); return View(); }
            Actor? exists = await _unitOfWork.ActorRepository.GetAsync(x => x.Id == actor.Id);
            if (exists == null) { NotFound(); return View(); }
            exists.FullName = actor.FullName;
            exists.About = actor.About;
            if (actor.ImageFile != null)
            {
                if (!actor.ImageFile.CheckFileType("image")) { ModelState.AddModelError("", "Must be image file"); return View(); }
                if (actor.ImageFile.CheckFileSize(2000)) { ModelState.AddModelError("", "Must be less 2000 file size"); return View(); }
                exists.ImageFile.DeleteFile(_environment.WebRootPath, exists.Image);
                string fileName = await actor.ImageFile.SaveFileAsync(_environment.WebRootPath);
                exists.Image = fileName;
            }

            await _unitOfWork.SaveChangeAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            Actor? actor = await _unitOfWork.ActorRepository.GetAsync(x => x.Id == id);
            if (actor == null) { NotFound(); return View(); }
            _unitOfWork.ActorRepository.Delete(actor);
            await _unitOfWork.SaveChangeAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            var actor = await _unitOfWork.ActorRepository.GetAsync(x => x.Id == id);
            if (actor == null) { NotFound(); }
            return View(actor);
        }

        public int GetPageCount(int take)
        {
            var pageCount = _unitOfWork.ActorRepository.Count();
            return (int)Math.Ceiling((decimal)pageCount / take);
        }
    }
}