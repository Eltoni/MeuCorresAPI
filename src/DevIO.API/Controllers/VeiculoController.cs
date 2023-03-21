using AutoMapper;
using DevIO.API.ViewModels;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.API.Controllers
{
    [Route("veiculo")]
    public class VeiculoController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(INotificador notificador,
                                    IVeiculoRepository veiculoRepository,
                                    IMapper mapper,
                                    IVeiculoService veiculoService) : base(notificador)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<IEnumerable<VeiculoViewModel>> ObterTodos()
        {
            var veiculo = _mapper.Map<IEnumerable<VeiculoViewModel>>(await _veiculoRepository.ObterTodos());
            return veiculo;
        }

        [HttpGet("getAll")]
        public async Task<IEnumerable<Veiculo>> GetAll()
        {
            var veiculo =await _veiculoRepository.GetTodos();
            return veiculo;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<VeiculoViewModel>> ObterPorId(Guid id)
        {
            var veiculoViewModel = await ObterVeiculo(id);

            if (veiculoViewModel == null) return NotFound();

            return veiculoViewModel;
        }

        [NonAction]
        public async Task<VeiculoViewModel> ObterVeiculo(Guid id)
        {
          //  return _mapper.Map<VeiculoViewModel>(await _veiculoRepository.ObterVeiculo(id));
            return _mapper.Map<VeiculoViewModel>(await _veiculoRepository.ObterVeiculoCorridas(id));

        }

        [HttpPost]
        public async Task<ActionResult<VeiculoViewModel>> Adicionar(VeiculoViewModel veiculoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _veiculoService.Adicionar(_mapper.Map<Veiculo>(veiculoViewModel));


            return CustomResponse(veiculoViewModel);

        }
    }
}
