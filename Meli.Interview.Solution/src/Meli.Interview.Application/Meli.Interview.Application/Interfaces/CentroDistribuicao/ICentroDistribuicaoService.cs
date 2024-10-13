using Meli.Interview.Application.ViewModel;
using Meli.Interview.Domain.DTO;

namespace Meli.Interview.Application.Interfaces.CentroDistribuicao
{
    public interface ICentroDistribuicaoService
    {
        List<CentroDistribuicaoDTO> Obter(int itemCDId);
        List<CentroDistribuicaoDTO> BuscaListaCentroDistribuicaoId(int IdCD);
        List<CentroDistribuicaoDTO> BuscaListaCentroDistribuicaoItemId(int itemId);
        List<CentroDistribuicaoDTO> AdicionaListaCentroDistribuicaoFake();
        Task<List<CentroDistribuicaoDTO>> ObterCDsProximidadeAsync(CentroDistribuicaoDTO? filter);
    }
}