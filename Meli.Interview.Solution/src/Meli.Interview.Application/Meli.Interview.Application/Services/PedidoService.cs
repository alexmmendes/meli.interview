using AutoMapper;
using GoogleApi.Entities.Maps.DistanceMatrix.Response;
using Meli.Interview.Application.Interfaces.Pedido;
using Meli.Interview.Application.ViewModel;
using Meli.Interview.Domain.Core.Interfaces;
using Meli.Interview.Domain.DTO;
using Meli.Interview.Domain.Interfaces.Repository;
using Meli.Interview.Domain.Model;
using System.Collections.Generic;
using System.Net.Http;

namespace Meli.Interview.Application.Services
{
    public sealed class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PedidoService(
            IPedidoRepository pedidoRepository,
            IUnitOfWork uow,
            IMapper mapper)
        {
            _pedidoRepository = pedidoRepository ?? throw new ArgumentNullException(nameof(pedidoRepository));
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<PedidoDTO> ProcessarPedido(PedidoDTO pedidoDTO)
        {
            var pedido = _mapper.Map<Pedido>(pedidoDTO);
            _mapper.Map(pedidoDTO, pedido);

            await _pedidoRepository.SalvarPedido(pedido);

            pedidoDTO = _mapper.Map<PedidoDTO>(pedido);
            _mapper.Map(pedido, pedidoDTO);

            await _uow.CommitAsync();

            return pedidoDTO;
        }

        public async Task<IEnumerable<PedidoDTO>> ConsultarPedidos()
        {
            return (IEnumerable<PedidoDTO>)await _pedidoRepository.ObterPedidos();
        }
    }
}
