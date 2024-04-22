using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetStore.Domain.Abstract;
using PetStore.WebUI.Models;

namespace PetStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository myrepository;

        public ProductController (IProductRepository productRepository)
        {
            this.myrepository = productRepository;
        }
        //public ViewResult List()
        //{
        //    return View(myrepository.Products);
        //}

        public int PageSize = 5;
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = myrepository.Products
                            .Where(p => category == null || p.Category == category)
                            .OrderBy(p => p.ProductID)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                                myrepository.Products.Count() :
                                myrepository.Products.Where 
                                            (e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}