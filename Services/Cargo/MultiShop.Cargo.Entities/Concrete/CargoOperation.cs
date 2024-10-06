using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Entities.Concrete
{
    public class CargoOperation
    {
        public int CargoOperationId { get; set; }
        public Guid Barcode { get; set; }
        public string Description { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
