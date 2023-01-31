using Core.Entities;
using Web.ViewModels.Components;
using Web.ViewModels.Product;

namespace Web.Services.Abstract
{
    public interface IProductService
    {
        Task<ProductIndexVM> GetAllAsync(ProductIndexVM model);
        Task<ProductIndexVM> GetAllFilterAsync(ProductIndexVM model, string? gender);

        Task<ProductDetailsVM> GetDetailsAsync(int id);

        Task<ProductLoadMoreVM> GetLoadMoreAsync(int skipRow);
        Task<HeaderComponentVM> FilterAllByName(string? name);
        Task<IQueryable<Product>> FilterByName(string? name);
        Task<ProductIndexVM> FilterByGender(ProductIndexVM model, string? gender);
        Task<ProductIndexVM> FilterByModel(ProductIndexVM model, string? productmodel);
        Task<ProductIndexVM> GetProductsWithPaginate(int page);

        Task<IQueryable<Product>> FilterProduct(ProductIndexVM model);

    }
}
