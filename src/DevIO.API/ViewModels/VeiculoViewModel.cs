using System.ComponentModel.DataAnnotations;

namespace DevIO.API.ViewModels
{
    public class VeiculoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Modelo { get; set; }
        public int Ano { get; set; }


        //[ScaffoldColumn(false)]
        //public string NomeMotoristaPrimeiro { get; set; }

        //[ScaffoldColumn(false)]
        //public string NomeMotoristaSegundo { get; set; }

        //[ScaffoldColumn(false)]
        //public string DocumentoMotoristaPrimeiro { get; set; }

        //[ScaffoldColumn(false)]
        //public string DocumentoMotoristaSegundo { get; set; }
        /* EF Relation */

        public IEnumerable<CorridaViewModel> Corridas { get; set; }

        //public CorridaViewModel Corrida { get; set; }






    }
}
