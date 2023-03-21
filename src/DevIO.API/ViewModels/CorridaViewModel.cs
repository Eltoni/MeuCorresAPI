using System.ComponentModel.DataAnnotations;

namespace DevIO.API.ViewModels
{
    public class CorridaViewModel
    {

        [Key]
        public Guid Id { get; set; }
        public Guid VeiculoId { get; set; }
        public Guid IdMotoristaPrimeiro { get; set; }
        public Guid IdMotoristaSegundo { get; set; }
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataHoraSaida { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataHoraChegada { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string TipoViagem { get; set; }
       

        [ScaffoldColumn(false)]
        public string NomePlaca { get; set; }

        [ScaffoldColumn(false)]
        public string NomeModelo { get; set; }

        [ScaffoldColumn(false)]
        public string NomeMotoristaPrimeiro { get; set; }

        [ScaffoldColumn(false)]
        public string NomeMotoristaSegundo { get; set; }

        [ScaffoldColumn(false)]
        public string DocumentoMotoristaPrimeiro { get; set; }

        [ScaffoldColumn(false)]
        public string DocumentoMotoristaSegundo { get; set; }

     
    }
}
