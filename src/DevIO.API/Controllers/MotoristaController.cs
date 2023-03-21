using AutoMapper;
using DevIO.API.ViewModels;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.API.Controllers
{
    [Route("motorista")]

    public class MotoristaController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IMotoristaService _motoristaService;

        public MotoristaController(INotificador notificador, 
                                    IMotoristaRepository motoristaRepository, 
                                    IMapper mapper, 
                                    IMotoristaService motoristaService) : base(notificador)
        {
            _motoristaRepository = motoristaRepository;
            _mapper = mapper;
            _motoristaService = motoristaService;
        }

        [HttpGet]
        public async Task<IEnumerable<MotoristaViewModel>> ObterTodos()
        {
            var motorista = _mapper.Map<IEnumerable<MotoristaViewModel>>(await _motoristaRepository.ObterTodos());
            return motorista;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MotoristaViewModel>> ObterPorId(Guid id)
        {
            var motoristaViewModel = await ObterMotorista(id);

            if (motoristaViewModel == null) return NotFound();

            return motoristaViewModel;
        }

        [NonAction]
        public async Task<MotoristaViewModel> ObterMotorista(Guid id)
        {
            //return _mapper.Map<MotoristaViewModel>(await _motoristaRepository.ObterMotorista(id));
            return _mapper.Map<MotoristaViewModel>(await _motoristaRepository.ObterMotoristaCorridasVeiculo(id));

        }

        [HttpPost]
        public async Task<ActionResult<MotoristaViewModel>> Adicionar(MotoristaViewModel motoristaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _motoristaService.Adicionar(_mapper.Map<Motorista>(motoristaViewModel));


            return CustomResponse(motoristaViewModel);

        }
    }
}
