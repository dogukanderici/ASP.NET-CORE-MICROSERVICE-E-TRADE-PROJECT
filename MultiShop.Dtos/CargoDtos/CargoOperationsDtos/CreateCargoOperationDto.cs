using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.CargoDtos.CargoOperationsDtos
{
    public class CreateCargoOperationDto
    {
        public Guid Barcode { get; set; }
        public string Description { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
