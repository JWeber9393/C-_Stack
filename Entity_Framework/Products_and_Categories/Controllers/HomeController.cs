using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products_and_Categories.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace Products_and_Categories.Controllers
{
    public class HomeController : Controller
    {
        private ProdCatContext dbContext;
        public HomeController(ProdCatContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Product> dbProducts = dbContext.products.ToList(); 
            NewProductModel viewModel = new NewProductModel();
            viewModel.allProducts = dbProducts;
            return View("Index", viewModel);
        }
        
        [HttpPost]
        [Route("/create_product")]
        public IActionResult CreateProduct(Product newProd)
        { 
            dbContext.Add(newProd);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/products/{id}")]
        public IActionResult ViewProduct(int id)
        {
            ProductViewModel viewModel = new ProductViewModel();
            Product thisProduct = dbContext.products.Include(a => a.catAssociation).ThenInclude(c => c.Category).FirstOrDefault(prod => prod.ProductId == id);

            List<Category> usedCategories = new List<Category>();
            foreach(Association association in thisProduct.catAssociation)
            {
                usedCategories.Add(association.Category);
            }

            List<Category> allCats = dbContext.categories.Include(a => a.prodAssociation).ThenInclude(p => p.Product).ToList();
            List<Category> unusedCategories =allCats.Except(usedCategories).ToList();

            viewModel.Product = thisProduct;
            viewModel.CatsOfProd = usedCategories;
            viewModel.notMyCats = unusedCategories;
            return View("ViewProduct", viewModel);
        }

        [HttpPost]
        [Route("/update_product")]
        public IActionResult UpdateProduct(ProductViewModel newAssociation)
        //Using the view model to get access to association
        {
            dbContext.Add(newAssociation.association);
            //adding the association from the viewmodel
            dbContext.SaveChanges();
            
            return RedirectToAction("ViewProduct", new{id = newAssociation.association.ProductId});
            //redirecting the id of the product with its new category
        }
        
        [HttpGet]
        [Route("/categories")]
        public IActionResult Categories()
        {
            List<Category> dbCategories = dbContext.categories.ToList();
            NewCategoryModel viewModel = new NewCategoryModel();
            viewModel.allCategories = dbCategories;
            return View("Categories", viewModel);
        }
        
        [HttpPost]
        [Route("/create_category")]
        public IActionResult CreateCategory(Category newCat)
        { 
            dbContext.Add(newCat);
            dbContext.SaveChanges();
            return RedirectToAction("Categories");
        }
        
        [HttpGet]
        [Route("/category/{id}")]
        public IActionResult ViewCategory(int id)
        {
            Console.WriteLine("**********VIEWING CATEGORIES***************");
            CategoryViewModel viewModel = new CategoryViewModel();
            Category thisCategory = dbContext.categories.Include(a => a.prodAssociation).ThenInclude(p => p.Product).FirstOrDefault(cat => cat.CategoryId == id);

            List<Product> usedProducts = new List<Product>();
            foreach(Association association in thisCategory.prodAssociation)
            {
                usedProducts.Add(association.Product);
            }

            List<Product> allProds = dbContext.products.Include(a => a.catAssociation).ThenInclude(c => c.Category).ToList();
            List<Product> unusedProducts = allProds.Except(usedProducts).ToList();

            viewModel.Category = thisCategory;
            viewModel.ProdsOfCat = usedProducts;
            viewModel.notMyProds = unusedProducts;
            return View("ViewCategory", viewModel);
        }

        [HttpPost]
        [Route("/update_category")]
        public IActionResult UpdateCategory(ProductViewModel newAssociation)
        //Using the view model to get access to association
        {
            dbContext.Add(newAssociation.association);
            //adding the association from the viewmodel
            dbContext.SaveChanges();
            
            return RedirectToAction("ViewCategory", new{id = newAssociation.association.CategoryId});
            //redirecting the id of the product with its new category
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
