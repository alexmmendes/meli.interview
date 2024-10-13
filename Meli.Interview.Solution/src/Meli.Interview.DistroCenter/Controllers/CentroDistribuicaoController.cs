using Meli.Interview.Application.Interfaces.CentroDistribuicao;
using Meli.Interview.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Meli.Interview.DistroCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CentroDistribuicaoController : Controller
    {
        private readonly ICentroDistribuicaoService _service;
        private readonly ILogger<CentroDistribuicaoController> _logger;

        public CentroDistribuicaoController(ILogger<CentroDistribuicaoController> logger,
            ICentroDistribuicaoService centroDistribuicaoService
            )
        {
            _logger = logger;
            _service = centroDistribuicaoService;
        }

        [HttpGet(Name = "GetCentroDistribuicaoProximoItem/{itemCD}")]
        public async Task<IReadOnlyCollection<CentroDistribuicaoDTO>> GetCentroDistribuicaoProximoItem(
            [FromQuery] CentroDistribuicaoDTO? filter = null)
        {
            {
                List<CentroDistribuicaoDTO> centrosDeDistribuicao = await _service.ObterCDsProximidadeAsync(filter);
                return (IReadOnlyCollection<CentroDistribuicaoDTO>)Ok(centrosDeDistribuicao);
            }

        }

        [HttpGet(Name = "GetCentroDeDistribuicao")]
        public IActionResult GetCentroDeDistribuicao()
        {
            List<CentroDistribuicaoDTO> centrosDeDistribuicao = _service.AdicionaListaCentroDistribuicaoFake();
            return Ok(centrosDeDistribuicao);
        }



        [HttpGet("GetDistrosCenterByItemCDAsync/{itemId}")]
        public ActionResult<List<CentroDistribuicaoDTO>> GetDistrosCenterByItemCD(int itemId)
        {
            List<CentroDistribuicaoDTO> centrosDeDistribuicao = _service.BuscaListaCentroDistribuicaoItemId(itemId);
            return Ok(centrosDeDistribuicao);
        }

        [HttpGet("GetDistrosCenterByCodigoCD/{IdCD}")]
        public ActionResult<List<CentroDistribuicaoDTO>> GetDistrosCenterByCodigoCD(int IdCD)
        {
            List<CentroDistribuicaoDTO> centrosDeDistribuicao = _service.BuscaListaCentroDistribuicaoId(IdCD);
            return Ok(centrosDeDistribuicao);
        }
    }
}
