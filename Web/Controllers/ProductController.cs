﻿using Core.Constants;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Web.Services.Abstract;
using Web.ViewModels.Components;
using Web.ViewModels.Product;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly AppDbContext _context;

        public ProductController(IProductService productService,
            AppDbContext context)
        {
            _productService = productService;
            _context = context;
        }
        public async Task<IActionResult> Index(ProductIndexVM model)
        {
            model = await _productService.GetAllAsync(model);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> FilterProducts(ProductIndexVM model)
        {
            model = await _productService.GetAllFilterAsync(model, model.Gender);
            return PartialView("_ProductsPartial", model);
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

        [HttpGet]
        public async Task<IActionResult> FilterByGender(string? genders)
        {
            var model = new ProductIndexVM();
            model = await _productService.FilterByGender(model, genders);
            return PartialView("_ProductsPartial", model);
        }

        [HttpGet]
        public async Task<IActionResult> FilterByModel(string? models)
        {
            var model = new ProductIndexVM();
            model = await _productService.FilterByModel(model, models);
            return PartialView("_ProductsPartial", model);
        }
    }
}
