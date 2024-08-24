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
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public List<CargoDetail> TGetAll()
        {
            return _cargoDetailDal.GetAll();
        }

        public CargoDetail TGetByFilter(int id)
        {
            return _cargoDetailDal.GetByFilter(cd => cd.CargoDetailId == id);
        }

        public void TAdd(CargoDetail entity)
        {
            _cargoDetailDal.AddData(entity);
        }

        public void TDelete(int id)
        {
            _cargoDetailDal.DeleteData(id);
        }

        public void TUpdate(CargoDetail entity)
        {
            _cargoDetailDal.UpdateData(entity);
        }
    }
}
