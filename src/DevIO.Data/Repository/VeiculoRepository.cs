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

        //public async Task<Veiculo> ObterVeiculo(Guid id)
        //{
        //    return await Db.Veiculos.AsNoTracking()
        //        .FirstOrDefaultAsync(c => c.Id == id);
        //}

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

            public async Task<Veiculo> ObterVeiculosComId(Guid id)
        {
            var veiculos = await Db.Veiculos
                .Include(c => c.Corridas.Where(v => v.Veiculo.Id == id)).ToListAsync();

     

            foreach (var item in veiculos)
                foreach (var it in item.Corridas)
                {
                    it.PrimeiroMotorista = await Db.Motoristas.FirstOrDefaultAsync(x => x.Id == it.IdMotoristaPrimeiro);
                    it.SegundoMotorista = await Db.Motoristas.FirstOrDefaultAsync(x => x.Id == it.IdMotoristaSegundo);
                }

            return veiculos.FirstOrDefault(c => c.Id == id);

        }

        public async Task<IEnumerable<Veiculo>> GetTodos()
        {
            var veiculos = await Db.Veiculos
                 .Include(c => c.Corridas).ToListAsync();

            //veiculos.ForEach(c => {
            //    foreach (var it in c.Corridas)
            //    {
            //        it.PrimeiroMotorista = Db.Motoristas.FirstOrDefault(x => x.Id == it.IdMotoristaPrimeiro);
            //        it.SegundoMotorista = Db.Motoristas.FirstOrDefault(x => x.Id == it.IdMotoristaSegundo);
            //    }
            //});


            foreach (var item in veiculos)
                foreach (var it in item.Corridas)
                {
                    it.PrimeiroMotorista = await Db.Motoristas.FirstOrDefaultAsync(x=> x.Id == it.IdMotoristaPrimeiro);
                    it.SegundoMotorista = await Db.Motoristas.FirstOrDefaultAsync(x=> x.Id == it.IdMotoristaSegundo);
                }

            return veiculos;


        }

      
    }
}
    

