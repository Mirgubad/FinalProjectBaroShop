using Core.Entities;
using Web.ViewModels.Product;

namespace Web.Services.Abstract
{
    public interface IProductService
    {
        Task<ProductIndexVM> GetAllAsync(ProductIndexVM model);

        Task<ProductDetailsVM> GetDetailsAsync(int id);

        Task<ProductLoadMoreVM> GetLoadMoreAsync(int skipRow);
      
    }
}
