using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.CatalogDtos.SpecialOfferDtos
{
    public class ResultSpecialOfferDto
    {
        public string SpecailOfferId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
