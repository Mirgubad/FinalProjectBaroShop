using Core.Entities;

namespace Web.ViewModels.Home
{
    public class HomeIndexVM
    {
        public List<HomeMainSlider> HomeMainSliders { get; set; }
        public List<Brand> Brands { get; set; }
        public List<SpecialSlider> SpecialSliders { get; set; }
        public List<Core.Entities.Product> BestSellingProducts { get; set; }
        public List<Core.Entities.Product> InSaleProducts { get; set; }


    }
}
