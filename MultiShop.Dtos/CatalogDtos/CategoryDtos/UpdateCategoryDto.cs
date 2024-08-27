﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.CatalogDtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImageUrl { get; set; }
        public IFormFile CategoryImage { get; set; }
    }
}
