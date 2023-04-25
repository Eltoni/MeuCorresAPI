using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class CorridaRepository : Repository<Corrida>, ICorridaRepository
    {
        public CorridaRepository(MeuDbContext context) : base(context) { }

      

        public async Task<Corrida> ObterCorridaVeiculo(Guid id)
        {
            return await Db.Corridas.AsNoTracking().Include(f => f.Veiculo)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Corrida>> ObterCorridasVeiculos()
        {
            return await Db.Corridas.AsNoTracking()
                .Include(f => f.Veiculo)
                 .Include(m => m.PrimeiroMotorista)
                 .Include(m => m.SegundoMotorista)
                .OrderBy(p => p.DataHoraSaida).ToListAsync();
        }

        public async Task<IEnumerable<Corrida>> ObterCorridasPorVeiculo(Guid veiculoId)
        {
            return await Buscar(p => p.VeiculoId == veiculoId);
        }

        public async Task<IEnumerable<Corrida>> ObterTodasCorridasVeiculos()
        {
            try
            {
                var retorno = await Db.Corridas.Include(f => f.Veiculo.Corridas).ToListAsync();
                //.FirstOrDefaultAsync(p => p.Id == id);
                return retorno;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}