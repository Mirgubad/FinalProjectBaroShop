using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Web.Areas.Admin.ViewModels.Product
{
    public class ProductUpdateColorVM
    {
        public int ProductId { get; set; }
        [Display(Name = "Colors")]
        [Required]
        public List<int> ColorsIds { get; set; }
        public List<SelectListItem>? Colors { get; set; }
    }
}
