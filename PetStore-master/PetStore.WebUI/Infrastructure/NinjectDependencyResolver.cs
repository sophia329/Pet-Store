using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using Ninject;
using PetStore.Domain.Abstract;
using PetStore.Domain.Entities;
using PetStore.Domain.Concrete;

namespace PetStore.WebUI.Infrastructure
{
	public class NinjectDependencyResolver : IDependencyResolver
	{
		private IKernel mykernel;

		public NinjectDependencyResolver(IKernel kernelParam) 
		{
			mykernel = kernelParam;
			AddBindings();
		}

		public object GetService(Type myserviceType) 
		{
			return mykernel.TryGet(myserviceType);
		}

		public IEnumerable<object> GetServices(Type myserviceType) 
		{
			return mykernel.GetAll(myserviceType);
		}

		private void AddBindings() 
		{
            //Mock<IProductRepository> myMock = new Mock<IProductRepository>();
            //myMock.Setup(m => m.Products).Returns(new List<Product>{
            //    new Product { ProductName = "Football", Price = 25 },
            //    new Product { ProductName = "Surfboard", Price = 179 },
            //    new Product { ProductName = "Running Shoes", Price = 95 }
            //    });
            //mykernel.Bind<IProductRepository>().ToConstant(myMock.Object);
            mykernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
	}
}