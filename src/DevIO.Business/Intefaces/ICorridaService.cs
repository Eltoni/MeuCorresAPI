using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface ICorridaService : IDisposable
    {
        Task<bool> Adicionar(Corrida produto);
        Task<bool> Atualizar(Corrida produto);
        Task<bool> Remover(Guid id);
    }
}