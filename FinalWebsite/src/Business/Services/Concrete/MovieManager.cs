using AutoMapper;
using FinalWebsite.Business.DTO_s.ActorDto_s;
using FinalWebsite.Business.DTOs.MovieDtos;
using FinalWebsite.Business.DTOs.SearchDto;
using FinalWebsite.Business.Services.Abstract;
using FinalWebsite.Data.Entities;
using JwtExample.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApp.Repositories.Abstract;

namespace FinalWebsite.Business.Services.Concrete
{
	public class MovieManager:IMovieService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly AppDbContext _context;

        public MovieManager(IUnitOfWork unitOfWork, IMapper mapper, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }



        public async Task<List<SearchDto>> Search(string search)
		{
			/*var movies=_unitOfWork.MovieRepository.GetAllAsync(
				includes: new[] { "Director", "Genre", "Actors" });
			return _mapper.Map<List<SearchDto>>(movies);*/

            var movies=await _context.Movies.Where(x=>x.Name.ToLower().Trim() == search.ToLower().Trim()).ToListAsync();
            return _mapper.Map<List<SearchDto>>(movies);
        }


        public async Task<List<SearchDto>> SearchByGenre(string search, int? id)
        {
            return _mapper.Map<List<SearchDto>>(_unitOfWork.MovieRepository
                        .GetAllAsync(x => x.Id == id &&
                        x.Name.Trim().ToLower().StartsWith(search.ToLower().Trim()), includes: new[] { "Director", "Genre", "Actors" }));
        }
    }




}
