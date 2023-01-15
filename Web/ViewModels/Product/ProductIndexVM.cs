﻿using Core.Constants;
using Core.Entities;

namespace Web.ViewModels.Product
{
    public class ProductIndexVM
    {
        public List<Core.Entities.Product> Products { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Color> Colors { get; set; }
        public List<Gender> Genders { get; set; }
        public List<Model> Models { get; set; }
        public List<Material> Materials { get; set; }
        public int Page { get; set; } = 1;
        public int Take { get; set; } = 9;
        public int PageCount { get; set; }
        public string SearchInput { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
