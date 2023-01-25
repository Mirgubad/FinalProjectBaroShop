using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstarct
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetAllWithBrandAsync();
        Task<Product> GetProductDetailsAsync(int id);
        Task<List<Product>> GetProductsBestSellingAsync();
        Task<List<Product>> GetProductsInSaleAsync();
        Task<IQueryable<Product>> PaginateProductAsync(IQueryable<Product> products, int page, int take);
        Task<int> GetPageCountAsync(IQueryable<Product> products, int take);
        Task<IQueryable<Product>> FilterByName(string? name);
        Task<List<Product>> GetRelatedProductsAsync(int productId, int model, int gender);

        Task<Product> GetUpdateModelAsync(int id);

        Task<List<Product>> ProductsLoadMoreAsync(int skipRow);

        Task<bool> CheckIsLastAsync(int skiprow);





    }
}
