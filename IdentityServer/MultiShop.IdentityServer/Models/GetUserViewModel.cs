﻿namespace MultiShop.IdentityServer.Models
{
    public class GetUserViewModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsExist { get; set; }
    }
}
