using AutoMapper;
using DevIO.API.ViewModels;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.API.Controllers
{

    //[Authorize]
    [Route("corridas")]
    public class CorridaController : MainController
    {
        private readonly ICorridaRepository _corridaRepository;

        private readonly ICorridaService _corridaService;

        private readonly IMapper _mapper;

        public CorridaController(INotificador notificador,
                                ICorridaRepository corridaRepository,
                                ICorridaService corridaService,
                                IMapper mapper) : base(notificador)
        {
            _corridaRepository = corridaRepository;
            _corridaService = corridaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CorridaViewModel>> ObterTodos()
        {
            var corrida = _mapper.Map<IEnumerable<CorridaViewModel>>(await _corridaRepository.ObterCorridasVeiculos());
            return corrida;
        }

        [HttpGet("getAll")]
        public async Task<IEnumerable<Corrida>> GetAll()
        {
            var corrida = await _corridaRepository.ObterTodasCorridasVeiculos();
            return corrida;
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CorridaViewModel>> ObterPorId(Guid id)
        {
            var corridaViewModel = await ObterCorrida(id);

            if (corridaViewModel == null) return NotFound();

            return corridaViewModel;
        }

        [NonAction]
        public async Task<CorridaViewModel> ObterCorrida(Guid id)
        {
            return _mapper.Map<CorridaViewModel>(await _corridaRepository.ObterCorridasPorVeiculo(id));

        }

        [HttpPost]
        public async Task<ActionResult<CorridaViewModel>> Adicionar(CorridaViewModel corridaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _corridaService.Adicionar(_mapper.Map<Corrida>(corridaViewModel));


            return CustomResponse(corridaViewModel);

        }
    }
}
