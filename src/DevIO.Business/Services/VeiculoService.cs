using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class VeiculoService : BaseService, IVeiculoService
    {

        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(INotificador notificador, 
                              IVeiculoRepository veiculoRepository) : base(notificador)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<bool> Adicionar(Veiculo veiculo)
        {
            if (!ExecutarValidacao(new VeiculoValidation(), veiculo)) return false;

            if (_veiculoRepository.Buscar(b => b.Placa == veiculo.Placa).Result.Any())
            {
                Notificar("Já existe um Veiculo com esta placa infomado.");
                return false;
            }

            await _veiculoRepository.Adicionar(veiculo);

            return true;
        }
    

        public async Task<bool> Atualizar(Veiculo veiculo)
        {
            if (!ExecutarValidacao(new VeiculoValidation(), veiculo)) return false;

            if (_veiculoRepository.Buscar(b => b.Placa == veiculo.Placa).Result.Any())
            {
                Notificar("Já existe um Veiculo com esta placa infomado.");
                return false;
            }

            await _veiculoRepository.Atualizar(veiculo);

            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_veiculoRepository.ObterVeiculoCorridas(id).Result.Corridas.Any())
            {
                Notificar("O Motorista possui corridas cadastrados!");
                return false;
            }

            await _veiculoRepository.Remover(id);

            return true;
        }

        public void Dispose()
        {
            _veiculoRepository?.Dispose();

        }
    }
}
