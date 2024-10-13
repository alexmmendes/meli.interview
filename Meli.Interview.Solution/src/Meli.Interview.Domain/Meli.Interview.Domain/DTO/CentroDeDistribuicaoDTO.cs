namespace Meli.Interview.Domain.DTO
{
    public sealed class CentroDistribuicaoDTO
    {
        public int Codigo { get; private set; }
        public string Descricao { get; private set; }
        public string EnderecoCompleto { get; private set; }
        public int ItemID { get; set; }

        public CentroDistribuicaoDTO(int codigo, string descricao, string enderecoCompleto, int itemID)
        {
            Codigo = codigo;
            Descricao = descricao;
            EnderecoCompleto = enderecoCompleto;
            ItemID = itemID;
        }
    }
}
