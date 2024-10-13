using Meli.Interview.Domain.DTO;
using AutoMapper;
using Meli.Interview.Domain.Model;

namespace Meli.Interview.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PedidoDTO, Pedido>();
            CreateMap<Pedido, PedidoDTO>();
        }
    }
}
