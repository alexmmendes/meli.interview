using FluentValidation;
using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using Meli.Interview.Application.Interfaces.CentroDistribuicao;
using Meli.Interview.DistroCenter.Model;
using Meli.Interview.Domain.Core.DependencyInjection;
using Meli.Interview.Domain.DTO;

namespace Meli.Interview.Application.Services
{
    [ScopedService]
    public sealed class CentroDistribuicaoService : ICentroDistribuicaoService
    {

        private static string _keyGoogleMaps = "";
        public List<CentroDistribuicaoDTO> AdicionaListaCentroDistribuicaoFake()
        {
            List<CentroDistribuicaoDTO> centrosDeDistribuicao = DoCentroDistribuicaoFake();

            return centrosDeDistribuicao;
        }
        #region Commands

        public List<CentroDistribuicaoDTO> BuscaListaCentroDistribuicaoId(int itemCDId)
        {
            List<CentroDistribuicaoDTO> centrosDeDistribuicao = DoCentroDistribuicaoFake();
            var centroDistribuicao = centrosDeDistribuicao.Where(i => i.Codigo == itemCDId).ToList();
            return centroDistribuicao;
        }

        public List<CentroDistribuicaoDTO> Obter(int itemCDId)
        {
            List<CentroDistribuicaoDTO> centrosDeDistribuicao = DoCentroDistribuicaoFake();
            var centroDistribuicao = centrosDeDistribuicao.Where(i => i.Codigo == itemCDId).ToList();
            return centroDistribuicao;
        }
        public List<CentroDistribuicaoDTO> BuscaListaCentroDistribuicaoItemId(int itemId)
        {
            List<CentroDistribuicaoDTO> centrosDeDistribuicao = DoCentroDistribuicaoFake();
            var centroDistribuicao = centrosDeDistribuicao.Where(i => i.ItemID == itemId).ToList();
            return centroDistribuicao;
        }

        public async Task<List<CentroDistribuicaoDTO>> ObterCDsProximidadeAsync(CentroDistribuicaoDTO? filter)
        {
            List<CentroDistribuicaoDTO> items = await ValidarCDMaisProximasAsync(filter);
            return items.ToList();
        }


        #endregion


        #region Methods
        private static List<CentroDistribuicaoDTO> DoCentroDistribuicaoFake()
        {
            ListaDeCentrosDeDistribuicao listaDeCentrosDeDistribuicao = new ListaDeCentrosDeDistribuicao();

            CentroDistribuicaoDTO centroDeDistribuicao1 = new(1, "Centro de Distribuição 2", "Avenida Paulista, 789, São Paulo, SP", 121);
            CentroDistribuicaoDTO centroDeDistribuicao2 = new(2, "Centro de Distribuição 2", "Rua da Paz, 321, São Paulo, SP", 121);
            CentroDistribuicaoDTO centroDeDistribuicao3 = new(3, "Centro de Distribuição 3", "Rua do Sol, 321, São Paulo, SP", 123);

            listaDeCentrosDeDistribuicao.AdicionarCentroDeDistribuicao(centroDeDistribuicao1);
            listaDeCentrosDeDistribuicao.AdicionarCentroDeDistribuicao(centroDeDistribuicao2);
            listaDeCentrosDeDistribuicao.AdicionarCentroDeDistribuicao(centroDeDistribuicao3);

            List<CentroDistribuicaoDTO> centrosDeDistribuicao = listaDeCentrosDeDistribuicao.ObterCentrosDeDistribuicao();

            return centrosDeDistribuicao;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private async Task<List<CentroDistribuicaoDTO>> ValidarCDMaisProximasAsync(CentroDistribuicaoDTO? filter)
        {
            string enderecoItem = "Rua Doutor Penaforte Mendes, 60, São Paulo, SP";

            var centroDistribuicoes = DoCentroDistribuicaoFake();

            List<string> addresses = centroDistribuicoes.Select(cd => cd.EnderecoCompleto.ToString()).ToList();

            // Transformar a lista de endereços em uma IEnumerable<LocationEx>
            var listaEnderecos = addresses.Select(a => new LocationEx(new Address(a)));


            //IEnumerable<LocationEx> listaEnderecos = 
            //[
            //    new LocationEx(new Address("Avenida Paulista, 789, São Paulo, SP")),
            //    new LocationEx(new Address("Rua da Paz, 321, São Paulo, SP")),
            //    new LocationEx(new Address("Rua do Sol, 901, São Paulo, SP"))
            //];


            var request = new DistanceMatrixRequest
            {
                Key = _keyGoogleMaps,
                Origins = [new LocationEx(new Address(enderecoItem))],
                Destinations = listaEnderecos,
                TravelMode = TravelMode.DRIVING,
                Units = Units.Metric
            };
            var result = await GoogleMaps.DistanceMatrix.QueryAsync(request);

            var elementos = result.DestinationAddresses.Select((x, i) => new { Value = x, Index = i });

            var minElementInfo = result.Rows
           .SelectMany((row, rowIndex) => row.Elements
               .Select((element, elementIndex) => new
               {
                   Value = element.Distance.Value,
                   RowIndex = rowIndex,
                   ElementIndex = elementIndex
               }))
           .OrderBy(x => x.Value)
           .FirstOrDefault();

            if (minElementInfo != null)
            {
                Console.WriteLine($"Valor mínimo: {listaEnderecos.ElementAt(minElementInfo.ElementIndex)}, Posição: {minElementInfo?.ElementIndex}");
            }

            return new List<CentroDistribuicaoDTO>();
        }

        #endregion
    }
}
