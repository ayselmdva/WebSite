using FinalWebsite.WebUI.View_Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories.Abstract;

namespace FinalWebsite.WebUI.Controllers
{
    public class CrewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM vM = new HomeVM()
            {
                Directors = await _unitOfWork.DirectorRepository.GetAllAsync(),
                Actors = await _unitOfWork.ActorRepository.GetAllAsync()
            };
            return View(vM);
        }

        public async Task<IActionResult>Detail(string name)
        {
            var actor = await _unitOfWork.ActorRepository.GetAsync(x => x.FullName == name, includes: new[] { "Movies"});
            if (actor != null)
            {
                HomeVM homeVM = new HomeVM()
                {
                    FullName = actor.FullName,
                    About = actor.About,
                    Image = actor.Image,
                    ImageFile = actor.ImageFile,
                    Movies=actor.Movies
                };
                return View(homeVM); 
            }
            else
            {
		    	var director = await _unitOfWork.DirectorRepository.GetAsync(x => x.FullName == name, includes: new[] { "Movies"});
				HomeVM homeVM = new HomeVM()
				{
					FullName = director.FullName,
					About = director.About,
					Image = director.Image,
					ImageFile = director.ImageFile,
                    Movies=director.Movies
				};
				return View(homeVM);
			}
        }
	}
}
