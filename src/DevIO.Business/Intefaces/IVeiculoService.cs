using DevIO.Business.Models;


namespace DevIO.Business.Intefaces
{
    public interface IVeiculoService
    {
        Task<bool> Adicionar(Veiculo veiculo);
        Task<bool> Atualizar(Veiculo veiculo);
        Task<bool> Remover(Guid id);
    }
}
