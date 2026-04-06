using AutoMapper;
using OrderApi.Models;

namespace OrderApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderResponseDto>();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
