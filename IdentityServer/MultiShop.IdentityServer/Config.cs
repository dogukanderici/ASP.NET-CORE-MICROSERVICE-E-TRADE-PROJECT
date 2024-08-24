// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Identity.Client;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        // Her mikroservis için o mikroservise erişim sağlayacak kaynak ve o kaynağın kapsamları belirlenir.
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            // Categories Api'sinde Program.cs içerisindeki JwtBearer ayarlarında Auidence değerine atanır. 
            // Bu tanımlamada Categories için istekler atıldığında ResourceCatalog altındaki Scope'lar hangi kullanıcılara verilmişse o kullanıcıların alacağı token ile işlem yapılabileceğini tanımlar.
            new ApiResource("ResourceCatalog"){Scopes ={"CatalogFullPermission","CatalogReadPermission"}},
            new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
            new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        // Identity kaynağına sahip olan kişi hangi değerlere erişim sağlayacağı belirlenir.
        // Token'ı alınan kullanıcının o token içeriğinde hangi bilgilerine erişim sağlanacağı bildirilir.
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(), // Herkese açık olan id'ye
            new IdentityResources.Email(), // Herkese açık olan email'e
            new IdentityResources.Profile() // Herkese açık profillere erişim sağlanır.
        };

        // Kaynaklarda tanımlanan kapsamların tanımlanması
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full Authority For Catalog Operations"),
            new ApiScope("CatalogReadPermission","Reading Authority For Catalog Operations"),
            new ApiScope("DiscountFullPermission","Full Authority For Discount Operations"),
            new ApiScope("OrderFullPermission","Full Authority For Order Operations"),
            new ApiScope("CargoFullPermission","Full Authority For Cargo Operations"),
            new ApiScope("BasketFullPermission","Full Authority For Basket Operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        // Token alacak kullanıcı tipleri tanımlanır.
        // Her kullanıcı tipi bir ClientId ve ClientSecret ile tanımlanır.
        public static IEnumerable<Client> Clients => new Client[]
        {
            // Visitor
            // Ziyaretçinin Sahip Olacağı Yetkiler

            new Client()
            {
                ClientId="MultiShopVisitorId",
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "DiscountFullPermission" }
            },

            //Manager
            new Client()
            {
                ClientId="MultiShopManagerId",
                ClientName="Multi Shop Manager User",
                //AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission" }

            },

            //Admin
            new Client()
            {
                ClientId="MultiShopAdminId",
                ClientName="Multi Shop Admin User",
                //AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission",
                    "CargoFullPermission","BasketFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName, // Yereldeki api üzeriden kapsam adına ulaşır.
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=600
            }
        };
    }
}