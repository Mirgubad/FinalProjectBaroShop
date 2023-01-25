using Microsoft.AspNetCore.Mvc;

using Web.Services.Abstract;
using Web.ViewModels.Components;
using Web.ViewModels.Product;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index(ProductIndexVM model)
        {
            model = await _productService.GetAllAsync(model);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _productService.GetDetailsAsync(id);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> LoadMore(int skipRow)
        {
            var model = await _productService.GetLoadMoreAsync(skipRow);
            return PartialView("_BestSellingPartial", model);
        }


        [HttpGet]
        public async Task<IActionResult> FilterByName(string? name)
        {
            var model = await _productService.FilterByName(name);
            return PartialView("_SearchProductPartial", model);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsPaginate(int pageNumber)
        {
            var data = await _productService.GetProductsWithPaginate(pageNumber);
            return PartialView("_ProductsPartial", data);
        }
    }
}
