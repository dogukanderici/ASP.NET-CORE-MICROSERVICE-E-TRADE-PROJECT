using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.CargoDtos.CargoCustomerDtos
{
    public class GetByIdCargoCustomerDto
    {
        public int CargoCustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Discrict { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string? UserCustomerId { get; set; }
    }
}
