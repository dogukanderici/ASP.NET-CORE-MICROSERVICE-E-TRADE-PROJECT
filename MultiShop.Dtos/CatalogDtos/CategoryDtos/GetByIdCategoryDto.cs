﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.CatalogDtos.CategoryDtos
{
    public class GetByIdCategoryDto
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImageUrl { get; set; }
    }
}
