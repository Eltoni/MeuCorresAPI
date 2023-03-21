
namespace DevIO.Business.Models
{
    public class Motorista : Entity
    {
        
        public string Nome { get; set; }
        public string Documento { get; set; }

       // public Veiculo Veiculo { get; set; }
        /* EF Relation */
       

        public IEnumerable<Corrida> CorridasPrimeiroMotorista { get; set; }
        public IEnumerable<Corrida> CorridasSegundoMotorista { get; set; }




    }
}