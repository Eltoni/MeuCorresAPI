namespace DevIO.Business.Models
{
    public class Veiculo : Entity
    {
       
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }

        /* EF Relation */
        public IEnumerable<Corrida> Corridas { get; set; }



        // public Corrida Corrida { get; set; }

    }
}