using Meli.Interview.Domain.DTO;

namespace Meli.Interview.DistroCenter.Model
{
    public class ListaDeCentrosDeDistribuicao
    {
        private List<CentroDistribuicaoDTO> _centrosDeDistribuicao;

        public ListaDeCentrosDeDistribuicao()
        {
            _centrosDeDistribuicao = new List<CentroDistribuicaoDTO>();
        }

        public void AdicionarCentroDeDistribuicao(CentroDistribuicaoDTO centroDeDistribuicao)
        {
            _centrosDeDistribuicao.Add(centroDeDistribuicao);
        }

        public List<CentroDistribuicaoDTO> ObterCentrosDeDistribuicao()
        {
            return _centrosDeDistribuicao;
        }
    }
}
