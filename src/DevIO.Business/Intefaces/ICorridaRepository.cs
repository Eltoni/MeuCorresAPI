using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface ICorridaRepository : IRepository<Corrida>
    {
        Task <Corrida> ObterCorridaVeiculo(Guid veiculoId);
        Task<IEnumerable<Corrida>> ObterCorridasVeiculos();
        Task<IEnumerable<Corrida>> ObterCorridasPorVeiculo(Guid id);
    }
}