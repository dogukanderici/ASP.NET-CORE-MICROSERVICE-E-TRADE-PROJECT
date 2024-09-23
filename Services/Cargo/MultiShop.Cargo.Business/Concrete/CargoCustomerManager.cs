using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Business.Concrete
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal cargocustomerDal)
        {
            _cargoCustomerDal = cargocustomerDal;
        }

        public List<CargoCustomer> TGetAll()
        {
            return _cargoCustomerDal.GetAll();
        }

        public CargoCustomer TGetByFilter(int id)
        {
            return _cargoCustomerDal.GetByFilter(cc => cc.CargoCustomerId == id);
        }

        public void TAdd(CargoCustomer entity)
        {
            _cargoCustomerDal.AddData(entity);
        }

        public void TDelete(int id)
        {
            _cargoCustomerDal.DeleteData(id);
        }

        public void TUpdate(CargoCustomer entity)
        {
            _cargoCustomerDal.UpdateData(entity);
        }

        public CargoCustomer TGetByIdCargoCustomer(string userId)
        {
            return _cargoCustomerDal.GetByFilter(cc => cc.UserCustomerId == userId);
        }
    }
}
