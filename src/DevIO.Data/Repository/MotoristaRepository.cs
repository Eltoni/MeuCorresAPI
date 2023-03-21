﻿using DevIO.Business.Intefaces;
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
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Motorista> ObterMotoristaCorridasVeiculo(Guid id)
        {
            return await Db.Motoristas.AsNoTracking()
                .Include(m => m.CorridasPrimeiroMotorista)
                .Include(m => m.CorridasSegundoMotorista)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}