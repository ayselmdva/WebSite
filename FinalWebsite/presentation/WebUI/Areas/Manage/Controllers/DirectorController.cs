using FinalWebsite.Data.Entities;
using FinalWebsite.Business.Utilites;
using FinalWebsite.WebUI.View_Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace FinalWebsite.WebUI.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "admin")]
    public class DirectorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;

        public DirectorController(IWebHostEnvironment environment, IUnitOfWork unitOfWork)
        {
            _environment = environment;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(int page =1, int take = 4)
        {
            var directors = await _unitOfWork.DirectorRepository.GetAllPaginatedAsync(page,take);
            PaginateVM<Director> paginateVM = new PaginateVM<Director>()
            {
                Items = directors,
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
        public async Task<IActionResult> Create(Director director)
        {
            if (!ModelState.IsValid) { return View(); }
            if (director == null) { ModelState.AddModelError("", "NotFound"); return View(); }
            if (!director.ImageFile.CheckFileType("image")) { ModelState.AddModelError("", "Must be image file"); return View(); }
            if (director.ImageFile.CheckFileSize(2000)) { ModelState.AddModelError("", "Must be less 2000 file size"); return View(); }
            string fileName = await director.ImageFile.SaveFileAsync(_environment.WebRootPath);
            director.Image = fileName;
            await _unitOfWork.DirectorRepository.Create(director);
           await _unitOfWork.SaveChangeAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Director? director = await _unitOfWork.DirectorRepository.GetAsync(x => x.Id == id);
            if (director == null) { NotFound(); return View(); }
            return View(director);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Director director)
        {
            if (director == null) { NotFound(); return View(); }
            Director? exists = await _unitOfWork.DirectorRepository.GetAsync(x => x.Id == director.Id);
            if (exists == null) { NotFound(); return View(); }
            exists.FullName = director.FullName;
            exists.About = director.About;

            if (director.ImageFile != null)
            {
                if (!director.ImageFile.CheckFileType("image")) { ModelState.AddModelError("", "Must be image file"); return View(); }
                if (director.ImageFile.CheckFileSize(2000)) { ModelState.AddModelError("", "Must be less 2000 file size"); return View(); }
                exists.ImageFile.DeleteFile(_environment.WebRootPath, exists.Image);
                string fileName = await director.ImageFile.SaveFileAsync(_environment.WebRootPath);
                exists.Image = fileName;
            }

            await _unitOfWork.SaveChangeAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            Director? director = await _unitOfWork.DirectorRepository.GetAsync(x => x.Id == id);
            if (director == null) { NotFound(); return View(); }
            _unitOfWork.DirectorRepository.Delete(director);
       /*     director.ImageFile.DeleteFile(_environment.WebRootPath, director.Image);*/
            await _unitOfWork.SaveChangeAsync();
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Detail(int id)
        {
            var director = await _unitOfWork.DirectorRepository.GetAsync(x => x.Id == id);
            if (director == null) { NotFound(); }
            return View(director);
        }

        public int GetPageCount(int take)
        {
            var pageCount = _unitOfWork.DirectorRepository.Count();
            return (int)Math.Ceiling((decimal)pageCount / take);
        }
    }
}