﻿namespace MultiShop.Catalog.Dtos.SpecialOfferDtos
{
    public class ResultSpecialOfferDto
    {
        public string SpecailOfferId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
