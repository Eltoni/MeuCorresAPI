using System.ComponentModel.DataAnnotations;

namespace DevIO.API.ViewModels
{
    public class MotoristaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        public string Documento { get; set; }
        //public VeiculoViewModel Veiculo { get; set; }
        /* EF Relation */
        

        public IEnumerable<CorridaViewModel> CorridasPrimeiroMotorista { get; set; }
        public IEnumerable<CorridaViewModel> CorridasSegundoMotorista { get; set; }

    }
}
