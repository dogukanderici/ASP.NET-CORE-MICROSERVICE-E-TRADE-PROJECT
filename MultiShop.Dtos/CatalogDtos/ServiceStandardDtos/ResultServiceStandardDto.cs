using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.CatalogDtos.ServiceStandardDtos
{
    public class ResultServiceStandardDto
    {
        public string ServiceStandardId { get; set; }
        public string ServiceStandardName { get; set; }
        public string ServiceStandardIcon { get; set; }
        public bool IsActive { get; set; }
    }
}
