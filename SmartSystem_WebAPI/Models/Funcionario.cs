namespace SmartSystem_WebAPI.Models
{
    public class Funcionario
    {
        public Funcionario(){}

        public Funcionario(int id,string Nome,string Foto, int RG , int DepartamentoId)
        {
            this.Id = id;
            this.Nome = Nome; 
            this.Foto = Foto;
            this.RG = RG;
            this.DepartamentoId = DepartamentoId;   
        }



        public int Id { get; set; }

        public string Nome { get; set; }

        public string Foto { get; set; }

        public int RG { get; set; }

        public int DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }

       
    }
}
