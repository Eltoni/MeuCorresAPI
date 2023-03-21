using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class CorridaService : BaseService, ICorridaService
    {
        private readonly ICorridaRepository _corridaRepository;

        public CorridaService(ICorridaRepository corridaRepository,
                              INotificador notificador) : base(notificador)
        {
            _corridaRepository = corridaRepository;
        }

        public async Task<bool> Adicionar(Corrida corrida)
        {
            if (!ExecutarValidacao(new CorridaValidation(), corrida)) return false;

            
            if (_corridaRepository.Buscar(f => f.DataHoraSaida >= corrida.DataHoraSaida).Result.Any()
                || _corridaRepository.Buscar(f => f.DataHoraChegada >= corrida.DataHoraChegada).Result.Any())
            {
                Notificar("Já existe uma Corrida neste periodo.");
                return false;
            }

            await _corridaRepository.Adicionar(corrida);

            return true;
        }

        public async Task<bool> Atualizar(Corrida corrida)
        {
            if (!ExecutarValidacao(new CorridaValidation(), corrida)) return false;

            await _corridaRepository.Atualizar(corrida);

            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _corridaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _corridaRepository?.Dispose();
        }
    }
}