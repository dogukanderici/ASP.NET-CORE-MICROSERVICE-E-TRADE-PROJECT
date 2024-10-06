using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Business.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }

        public List<CargoCompany> TGetAll(Guid? barcode)
        {
            return _cargoCompanyDal.GetAll();
        }

        public CargoCompany TGetByFilter(int id)
        {
            return _cargoCompanyDal.GetByFilter(cc => cc.CargoCompanyId == id);
        }

        public void TAdd(CargoCompany entity)
        {
            _cargoCompanyDal.AddData(entity);
        }

        public void TDelete(int id)
        {
            _cargoCompanyDal.DeleteData(id);
        }

        public void TUpdate(CargoCompany entity)
        {
            _cargoCompanyDal.UpdateData(entity);
        }
    }
}
