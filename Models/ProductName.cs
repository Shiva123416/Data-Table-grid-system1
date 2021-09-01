using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceGrid.Models
{
    public class ProductName
    {
        
        public int Id { get; set; }

        [Required]
        [Display(Name ="Product Type")]
        public string ProductType { get; set; }

        [Required]
        [Display(Name = "Product Number")]
        public string ProductNumber { get; set; }

        [Required]
        [Display(Name = "Product Subcategory")]
        public string ProductSubcategory { get; set; }

        [Required]
        [Display(Name = "Standard Cost")]
        public string  StandardCost { get; set; }

        [Required]
        [Display(Name = "List Price")]
        public string  ListPrice { get; set; }

    }
}
