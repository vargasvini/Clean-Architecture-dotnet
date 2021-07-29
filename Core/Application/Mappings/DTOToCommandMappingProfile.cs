using AutoMapper;
using CleanArchitecture.Core.Application.DTOs;
using CleanArchitecture.Core.Application.Products.Commands;

namespace CleanArchitecture.Core.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductRemoveCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
