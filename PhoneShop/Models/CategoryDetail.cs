using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneShop.Models
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="CategoryName Required")]
        [StringLength(100,ErrorMessage ="Minimum 3 to 5 and maximum 100 characters allowed",MinimumLength =3)]
        public string CategoryName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }

    public class ProductDetail
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Product name is required")]
        [StringLength(100,ErrorMessage = "Minimum 3 to 5 and maximum 100 characters allowed", MinimumLength = 3)]
        public string ProductName { get; set; }
        [Required]
        [Range(1,50)]
        public Nullable<int> CategoryId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        [Required(ErrorMessage ="Description required")]
        public string Description { get; set; }
        public string ProduuctImage { get; set; }
        [Required]
        [Range(typeof(int),"1","500",ErrorMessage ="Invalid quantity")]
        public Nullable<int> Quantity { get; set; }
        [Required]
        [Range(typeof(decimal),"1","200000",ErrorMessage ="Invalid Price")]
        public Nullable<decimal> Price { get; set; }

        public SelectList Categories { get; set; }
    }
}