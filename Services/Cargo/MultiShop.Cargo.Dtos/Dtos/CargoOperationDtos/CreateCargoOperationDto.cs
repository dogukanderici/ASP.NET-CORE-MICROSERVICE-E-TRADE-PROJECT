using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Dtos.Dtos.CargoOperationDtos
{
    public class CreateCargoOperationDto
    {
        public Guid Barcode { get; set; }
        public string Description { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
