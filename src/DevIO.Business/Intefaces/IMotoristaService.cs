using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IMotoristaService : IDisposable
    {
        Task <bool> Adicionar(Motorista motorista);
        Task<bool> Atualizar(Motorista motorista);
        Task<bool> Remover(Guid id);

    }
}