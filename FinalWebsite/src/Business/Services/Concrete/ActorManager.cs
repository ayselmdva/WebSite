using AutoMapper;
using FinalWebsite.Business.DTO_s.ActorDto_s;
using FinalWebsite.Business.DTOs.ActorDtos;
using FinalWebsite.Business.Services.Abstract;
using FinalWebsite.Data.Entities;
using WebApp.Repositories.Abstract;

namespace FinalWebsite.Business.Services.Concrete
{
    public class ActorManager : IActorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActorManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(ActorPostDto actorPostDto)
        {
            if (actorPostDto == null) throw new Exception("Error");
            await _unitOfWork.ActorRepository.Create(_mapper.Map<Actor>(actorPostDto));
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task Delete(Actor actor)
        {
            var act = await _unitOfWork.ActorRepository.GetAsync(x => x.Id == actor.Id);
            _unitOfWork.ActorRepository.Delete(act);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<ActorGetDto> GetAsync(int id)
        {
            return _mapper.Map<ActorGetDto>(await _unitOfWork.ActorRepository.GetAsync(x => x.Id == id));
        }

        public async Task<List<ActorGetDto>> GetAllAsync()
        {
            return _mapper.Map<List<ActorGetDto>>(await _unitOfWork.ActorRepository.GetAllAsync());
        }

        public async Task<List<Actor>> GetAllPaginatedAsync(int page, int take)
        {
            var actors = await _unitOfWork.ActorRepository.GetAllPaginatedAsync(page, take);
            return actors.ToList();
        }

        public async Task Update(Actor actor)
        {
            var act = await GetAsync(actor.Id);
            _unitOfWork.ActorRepository.Update(_mapper.Map<Actor>(act));
            await _unitOfWork.SaveChangeAsync();
        }

        public int GetActorPageCount(int take)
        {
            var pageCount = _unitOfWork.ActorRepository.Count();
            return (int)Math.Ceiling((decimal)pageCount / take);

        }


    }
}