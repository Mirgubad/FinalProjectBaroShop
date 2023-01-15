using Core.Entities;
using Core.Utilities.FileService;
using DataAccess.Repositories.Abstarct;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Web.Areas.Admin.ViewModels.HomeMainSlider;
using Web.Services.Abstract;
using Web.ViewModels.Home;

namespace Web.Services.Concrete
{
    public class HomeService : IHomeService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IHomeMainSliderRepository _homeMainSliderRepository;
        private readonly ISpecialSliderRepository _specialSliderRepository;
        private readonly IProductRepository _productRepository;

        public HomeService(IBrandRepository brandRepository,
            IHomeMainSliderRepository homeMainSliderRepository,
            ISpecialSliderRepository specialSliderRepository,
            IProductRepository productRepository)
        {
            _brandRepository = brandRepository;
            _homeMainSliderRepository = homeMainSliderRepository;
            _specialSliderRepository = specialSliderRepository;
            _productRepository = productRepository;
        }
        public async Task<HomeIndexVM> GetAllAsync()
        {
            var model = new HomeIndexVM
            {
                Brands = await _brandRepository.GetAllAsync(),
                HomeMainSliders = await _homeMainSliderRepository.GetAllAsync(),
                SpecialSliders = await _specialSliderRepository.GetAllAsync(),
                BestSellingProducts = await _productRepository.GetProductsBestSellingAsync(),
                InSaleProducts = await _productRepository.GetProductsInSaleAsync(),
            };
            return model;
        }
    }
}
