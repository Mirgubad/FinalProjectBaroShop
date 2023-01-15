using Core.Constants;
using Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Web.Areas.Admin.ViewModels.Product
{
    public class ProductCreateVM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public ShippingStatus? ShippingStatus { get; set; }
        public IFormFile MainPhoto { get; set; }
        public List<IFormFile> Photos { get; set; }
        //[Display(Name = "Colors")]
        //public int ColorId { get; set; }

        //public List<SelectListItem>? Colors { get; set; }

        public Gender Gender { get; set; }
        public Material Material { get; set; }
        public Model Model { get; set; }
        public bool BestSelling { get; set; }
        public bool InSale { get; set; }

        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        public List<SelectListItem>? Brands { get; set; }




    }
}
