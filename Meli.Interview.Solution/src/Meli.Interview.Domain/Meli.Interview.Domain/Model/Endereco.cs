namespace Meli.Interview.Domain.Model
{
    public class Endereco(string logradouro, string numero, string complemento, string bairro, string cidade, string estado, string cep)
    {
        public required string Logradouro { get; set; } = logradouro;
        public required string Numero { get; set; } = numero;
        public required string Complemento { get; set; } = complemento;
        public required string Bairro { get; set; } = bairro;
        public required string Cidade { get; set; } = cidade;
        public required string Estado { get; set; } = estado;
        public required string CEP { get; set; } = cep;
    }
}
