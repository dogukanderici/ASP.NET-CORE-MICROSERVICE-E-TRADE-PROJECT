using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.CatalogDtos.ProductImageDtos
{
    public class UpdateProductImageDto
    {
        public string ProductImageID { get; set; }
        public string Image1 { get; set; }
        public IFormFile ImageUrl1 { get; set; }
        public string Image2 { get; set; }
        public IFormFile ImageUrl2 { get; set; }
        public string Image3 { get; set; }
        public IFormFile ImageUrl3 { get; set; }
        public string Image4 { get; set; }
        public IFormFile ImageUrl4 { get; set; }
        public string ProductID { get; set; }
    }
}
