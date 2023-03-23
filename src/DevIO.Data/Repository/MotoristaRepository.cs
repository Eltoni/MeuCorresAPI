using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class MotoristaRepository : Repository<Motorista>, IMotoristaRepository
    {
        public MotoristaRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<Motorista> ObterMotorista(Guid id)
        {
            return await Db.Motoristas.AsNoTracking()

                //.Include(m => m.CorridasPrimeiroMotorista)

                //.Include(m => m.CorridasPrimeiroMotorista)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Motorista> ObterMotoristaCorridasVeiculo(Guid id)
        {

            //return await Db.Motoristas.AsNoTracking()
            //    .Include(m => m.CorridasPrimeiroMotorista)
            //    .Include(m => m.CorridasSegundoMotorista)
            //    .FirstOrDefaultAsync(m => m.Id == id);


            var motoristas = await Db.Motoristas
                .Include(c => c.CorridasPrimeiroMotorista.Where(v => v.PrimeiroMotorista.Id == id))
                .Include(c => c.CorridasSegundoMotorista.Where(v => v.SegundoMotorista.Id == id)).ToListAsync();



            foreach (var item in motoristas)
                foreach (var it in item.CorridasPrimeiroMotorista)
                {
                    it.Veiculo = await Db.Veiculos.FirstOrDefaultAsync(x => x.Id == it.VeiculoId);
                   
                }

            foreach (var item in motoristas)
                foreach (var it in item.CorridasSegundoMotorista)
                {
                    it.Veiculo = await Db.Veiculos.FirstOrDefaultAsync(x => x.Id == it.VeiculoId);

                }

            return motoristas.FirstOrDefault(c => c.Id == id);

            return await Db.Motoristas.AsNoTracking()
                .Include(m => m.CorridasPrimeiroMotorista)
                .Include(m => m.CorridasSegundoMotorista)
                .FirstOrDefaultAsync(m => m.Id == id);

        }
    }
}