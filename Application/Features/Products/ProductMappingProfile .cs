using AutoMapper;
using Domain.Features.Products;

namespace Application.Features.Products.Mapping
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductViewModel, Product>();
            CreateMap<CreateProductModel, Product>();
            CreateMap<UpdateProductModel, Product>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}
