namespace Meli.Interview.Domain.Model
{
    public class CentroDistribuicao
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Endereco { get; set; }
        public required string Cidade { get; set; }
        public required string Estado { get; set; }
        public required string CEP { get; set; }
    }
}
