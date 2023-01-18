using Core.Constants;
using Core.Entities;
using DataAccess.Repositories.Abstarct;
using Org.BouncyCastle.Asn1.CryptoPro;
using Web.Services.Abstract;
using Web.ViewModels.Product;

namespace Web.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IColorRepository _colorRepository;

        public ProductService(IProductRepository productRepository,
            IBrandRepository brandRepository,
            IColorRepository colorRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _colorRepository = colorRepository;
        }



        public async Task<ProductIndexVM> GetAllAsync(ProductIndexVM model)
        {
            var products = await _productRepository.FilterByName(model.SearchInput);

            var pageCount = await _productRepository.GetPageCountAsync(products, model.Take);
            products = await _productRepository.PaginateProductAsync(products, model.Page, model.Take);
            model = new ProductIndexVM
            {

                Products = products.OrderByDescending(pr => pr.CreatedAt).ToList(),
                Brands = await _brandRepository.GetAllAsync(),
                Colors = await _colorRepository.GetAllAsync(),
                Page = model.Page,
                PageCount = pageCount,
                Take = model.Take,
                SearchInput = model.SearchInput,
            };
            return model;
        }

        public async Task<ProductDetailsVM> GetDetailsAsync(int id)
        {
            var product = await _productRepository.GetProductDetailsAsync(id);
            var model = new ProductDetailsVM
            {
                Product = product,
                RelatedProducts = await _productRepository.GetRelatedProductsAsync(((int)product.Model), ((int)product.Gender))
            };
            return model;
        }

        public async Task<ProductLoadMoreVM> GetLoadMoreAsync(int skipRow)
        {
            var products = await _productRepository.ProductsLoadMoreAsync(skipRow);
            var model = new ProductLoadMoreVM
            {
                BestSellingProducts = products,
                IsLast = await _productRepository.CheckIsLastAsync(skipRow)
            };
            return model;
        }
    }
}
