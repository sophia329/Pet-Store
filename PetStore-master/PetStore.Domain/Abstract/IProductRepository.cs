using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStore.Domain.Entities;

namespace PetStore.Domain.Abstract
{
	public interface IProductRepository
	{
		IEnumerable<Product> Products { get; }
	}
}
