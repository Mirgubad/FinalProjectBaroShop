using Core.Entities;
using Web.ViewModels.Components;
using Web.ViewModels.Product;

namespace Web.Services.Abstract
{
    public interface IProductService
    {
        Task<ProductIndexVM> GetAllAsync(ProductIndexVM model);

        Task<ProductDetailsVM> GetDetailsAsync(int id);

        Task<ProductLoadMoreVM> GetLoadMoreAsync(int skipRow);
        Task<HeaderComponentVM> FilterByName(string? name);
        Task<ProductIndexVM> GetProductsWithPaginate(/*ProductIndexVM model,*/ int page);

    }
}
