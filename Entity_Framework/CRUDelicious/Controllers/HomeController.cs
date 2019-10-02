using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            List<Dish> AllDishes= dbContext.Dishes.ToList();
            ViewBag.Dishes = AllDishes;
            return View();
        }
        
        [HttpPost]
        [Route("add")]
        public IActionResult Add(Dish createdDish)
        {
            dbContext.Add(createdDish);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("add_dish")]
        public IActionResult AddDish()
        {
            return View();
        }
        
        [HttpPost]
        [Route("/edit/{id}")]
        public IActionResult Edit(Dish newDish, int id)
        {
            Dish thisDish = dbContext.Dishes.FirstOrDefault(p=>p.DishId == id);
            thisDish.Name = newDish.Name;
            thisDish.Chef = newDish.Chef;
            thisDish.Tastiness = newDish.Tastiness;
            thisDish.Calories = newDish.Calories;
            thisDish.Description = newDish.Description;
            
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        [Route("/edit_dish/{id}")]
        public IActionResult EditDish(int id)
        {
            Dish thisDish = dbContext.Dishes.FirstOrDefault(p => p.DishId == id);
            return View(thisDish);
        }
        
        [HttpGet]
        [Route("/delete_dish/{id}")]
        public IActionResult DeleteDish(int id)
        {
            Dish thisDish = dbContext.Dishes.FirstOrDefault(p => p.DishId == id);
            dbContext.Dishes.Remove(thisDish);
            dbContext.SaveChanges();
            return RedirectToAction("Index", thisDish);
        }

        [HttpGet]
        [Route("view/{id}")]
        public IActionResult ViewDish(int id)
        {
            Dish thisDish = dbContext.Dishes.FirstOrDefault(u => u.DishId == id);
            return View("ViewDish", thisDish);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
