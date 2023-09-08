using FinalWebsite.Business.DTOs.SearchDto;
using Microsoft.AspNetCore.Mvc;
using WebApp.Repositories.Abstract;

namespace FinalWebsite.WebUI.View_Components
{
    public class SearchViewComponent : ViewComponent 
    { 

     private readonly IUnitOfWork _unitOfWork;

    public SearchViewComponent(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        SearchDto dto = new SearchDto();
        dto.Genres = await _unitOfWork.GenreRepository.GetAllAsync();
        return View(dto);
    }
}
}