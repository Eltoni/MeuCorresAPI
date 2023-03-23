using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
    public class MotoristaService : BaseService, IMotoristaService
    {
        private readonly IMotoristaRepository _motoristaRepository;
       

        public MotoristaService(IMotoristaRepository motoristaRepository, 
                                 INotificador notificador) : base(notificador)
        {
            _motoristaRepository = motoristaRepository;
           
        }

        public async Task <bool> Adicionar(Motorista motorista)
        {
            if (!ExecutarValidacao(new MotoristaValidation(), motorista)) return false;

            if (_motoristaRepository.Buscar(f => f.Documento == motorista.Documento).Result.Any())
            {
                Notificar("Já existe um Motorista com este documento infomado.");
                return false;
            }

            await _motoristaRepository.Adicionar(motorista);

            return true;
        }

        public async Task<bool> Atualizar(Motorista fornecedor)
        {
            if (!ExecutarValidacao(new MotoristaValidation(), fornecedor)) return false;

            if (_motoristaRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return false;
            }

            await _motoristaRepository.Atualizar(fornecedor);
            return true;
        }

      

        public async Task<bool> Remover(Guid id)
        {

            if (_motoristaRepository.ObterMotoristaCorridasVeiculo(id).Result.CorridasPrimeiroMotorista.Any())
            {
                Notificar("O Motorista possui corridas cadastrados!");
                return false;
            }




            await _motoristaRepository.Remover(id);

            //if (_motoristaRepository.ObterMotoristaCorridasVeiculo(id).Result.Corridas.Any())
            //{
            //    Notificar("O Motorista possui corridas cadastrados!");
            //    return false;
            //}


           

            //await _motoristaRepository.Remover(id);

            return true;
        }

        public void Dispose()
        {
            _motoristaRepository?.Dispose();
           
        }
    }
}