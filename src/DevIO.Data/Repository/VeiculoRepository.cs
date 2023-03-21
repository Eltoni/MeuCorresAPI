using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevIO.Data.Repository
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(MeuDbContext context) : base(context) { }

        public async Task<Veiculo> ObterVeiculo(Guid id)
        {
            return await Db.Veiculos.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Veiculo> ObterVeiculoCorridas(Guid id)
        {
            return await Db.Veiculos.AsNoTracking()
                .Include(c => c.Corridas)
               .FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<IEnumerable<Veiculo>> GetTodos()
        {
            var veiculos = await Db.Veiculos
                 .Include(c => c.Corridas).ToListAsync();

            return veiculos;
        }
    }
}
    

