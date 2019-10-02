using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chefs_and_Dishes.Models;
using Microsoft.EntityFrameworkCore;

namespace Chefs_and_Dishes.Controllers
{

    public class HomeController : Controller
    {
        private ChefDishContext dbContext;

        // here we can "inject" our context service into the constructor
        public HomeController(ChefDishContext context)
        {
            dbContext = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Chef> allChefs = dbContext.chefs.ToList();
            ViewBag.Chefs = allChefs;
            return View();
        }
        [HttpGet]
        [Route("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> allDishes = dbContext.dishes
            .Include(dish => dish.Creator)
            .ToList();
            ViewBag.Dishes = allDishes;
            return View();
        }
        [HttpGet]
        [Route("new")]
        public IActionResult NewChef(string msg)
        {
            ViewBag.ErrorMessage = msg;
            return View();
        }

        [HttpPost]
        [Route("new/add_chef")]
        public IActionResult ProcessChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                int age = DateTime.Now.Year - newChef._birthday.Year;
                DateTime date= newChef._birthday;
                DateTime ageGap = DateTime.Now.AddYears(-18);
                if(date > ageGap)
                {
                    string msg = "Chef must be 18!";
                    return RedirectToAction("NewChef", new{msg = msg});
                }
                newChef._age = age;
                dbContext.chefs.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewChef", newChef);       
            }
        }
        
        [HttpGet]
        [Route("dishes/new")]
        public IActionResult NewDish()
        {
            List<Chef> allChefs = dbContext.chefs.ToList();
            ViewBag.Chefs = allChefs;
            return View();
        }
        
        [HttpPost]
        [Route("dishes/new/add_dish")]
        public IActionResult ProcessDish(Dish newDish)
        {
            dbContext.dishes.Add(newDish);
            dbContext.SaveChanges();
            return RedirectToAction("Dishes");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
