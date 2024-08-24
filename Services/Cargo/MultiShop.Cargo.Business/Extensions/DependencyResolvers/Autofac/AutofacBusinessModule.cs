using Autofac;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Business.Concrete;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.Business.Extensions.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EfCargoCompanyDal>().As<ICargoCompanyDal>();
            builder.RegisterType<EfCargoCustomerDal>().As<ICargoCustomerDal>();
            builder.RegisterType<EfCargoDetailDal>().As<ICargoDetailDal>();
            builder.RegisterType<EfCargoOperationDal>().As<ICargoOperaitonDal>();

            builder.RegisterType<CargoCompanyManager>().As<ICargoCompanyService>();
            builder.RegisterType<CargoCustomerManager>().As<ICargoCustomerService>();
            builder.RegisterType<CargoDetailManager>().As<ICargoDetailService>();
            builder.RegisterType<CargoOperationManager>().As<ICargoOperationService>();

        }
    }
}
