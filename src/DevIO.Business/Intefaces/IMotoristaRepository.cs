using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IMotoristaRepository : IRepository<Motorista>
    {
        Task<Motorista> ObterMotorista(Guid id);
        Task<Motorista> ObterMotoristaCorridasVeiculo(Guid id);
    }
}