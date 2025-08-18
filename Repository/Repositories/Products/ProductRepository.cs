using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Domain.Features.Products;

namespace Infrastructure.Repositories.Products
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepositoryRepository
    {
        public ProductRepository(AppDataContext context) : base(context)
        {
        }
    }
}
