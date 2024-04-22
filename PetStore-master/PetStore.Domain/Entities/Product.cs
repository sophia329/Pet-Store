﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Domain.Entities
{
	public class Product
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public string Description { get; set; }
		public string Pet { get; set; }
		public decimal Price { get; set; }
		public string Category { get; set; }
	}
}
