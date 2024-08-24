using MultiShop.Cargo.Core.DataAccess.Concrete.EntityFramework;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccess.Concrete.Context;
using MultiShop.Cargo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccess.Concrete.EntityFramework
{
    public class EfCargoCustomerDal : EfRepositoryBase<CargoCustomer, CargoContext>, ICargoCustomerDal
    {
    }
}
