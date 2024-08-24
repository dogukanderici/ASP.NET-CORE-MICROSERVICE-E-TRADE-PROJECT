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
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperaitonDal _cargoOperationDal;

        public CargoOperationManager(ICargoOperaitonDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }

        public List<CargoOperation> TGetAll()
        {
            return _cargoOperationDal.GetAll();
        }

        public CargoOperation TGetByFilter(int id)
        {
            return _cargoOperationDal.GetByFilter(co => co.CargoOperationId == id);
        }

        public void TAdd(CargoOperation entity)
        {
            _cargoOperationDal.AddData(entity);
        }

        public void TDelete(int id)
        {
            _cargoOperationDal.DeleteData(id);
        }

        public void TUpdate(CargoOperation entity)
        {
            _cargoOperationDal.UpdateData(entity);
        }
    }
}
