using AutoMapper;
using CleanArchitecture.Core.Application.DTOs;
using CleanArchitecture.Core.Domain.Entities;

namespace CleanArchitecture.Core.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
