using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {



       // Task<Veiculo> ObterVeiculo(Guid id);

       // Task<Veiculo> ObterVeiculo(Guid id);
       

        Task<Veiculo> ObterVeiculoCorridas(Guid id);

        Task<Veiculo> ObterVeiculosComId(Guid id);

        Task<IEnumerable<Veiculo>> GetTodos();




    }
}
