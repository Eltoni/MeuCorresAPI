using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIO.Business.Models
{
    public class Corrida : Entity
    {
        public Guid VeiculoId { get; set; }
        public Guid? IdMotoristaPrimeiro { get; set; }
        public Guid? IdMotoristaSegundo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public DateTime DataHoraChegada { get; set; }
        public string TipoViagem { get; set; }
        public Motorista PrimeiroMotorista { get; set; }
        public Motorista SegundoMotorista { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}

