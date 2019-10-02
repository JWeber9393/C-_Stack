using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Login_and_Registration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Login_and_Registration.Controllers
{
    public class HomeController : Controller
    {
        private LogRegContext dbContext;
        public HomeController(LogRegContext context)
        {
            dbContext = context;
        }
        
        [HttpGet]
        [Route("")]
        public IActionResult Index(string msg)
        {
            Console.WriteLine("***********************************************");
            Console.WriteLine("INDEX");
            Console.WriteLine("***********************************************");
            if(msg != null)
            {
                ViewBag.ErrorMessage = msg;
            }
            return View();
        }
        
        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            if(HttpContext.Session.GetObjectFromJson<RegUser>("User")==null)
            {
                string msg = "Unauthorized access! Please sign in!";
                return RedirectToAction("Index", new{msg = msg});
            }
            else
            {
                Console.WriteLine("***********************************************");
                Console.WriteLine("Success!");
                Console.WriteLine("***********************************************");
                RegUser i = HttpContext.Session.GetObjectFromJson<RegUser>("User");
                RegUser liveUser = dbContext.users.FirstOrDefault(p => p.email == i.email);
                return View("Success", liveUser);
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegUser newUser)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.users.Any(u => u.email == newUser.email))
                {
                    string msg = "Email already in use!";
                    return RedirectToAction("Index", new { msg = msg });
                }
                else
                {
                    PasswordHasher<RegUser> Hasher = new PasswordHasher<RegUser>();
                    newUser.password = Hasher.HashPassword(newUser, newUser.password);
                    dbContext.Add(newUser);
                    dbContext.SaveChanges();
                    //session user
                    HttpContext.Session.SetObjectAsJson("User", newUser);
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("REGISTERING");
                    Console.WriteLine("***********************************************");
                    return RedirectToAction("Success");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LogUser userSubmission)
        {
            if (ModelState.IsValid)
            {
                // If inital ModelState is valid, query for a user with provided email
                var userInDb = dbContext.users.FirstOrDefault(u => u.email == userSubmission.log_email);
                // If no user exists with provided email
                if (userInDb == null)
                {
                    // Add an error to ModelState and return to View!
                    string msg = "Invalid Email/Password!";
                    return RedirectToAction("Index", new { msg = msg });
                }

                // Initialize hasher object
                var hasher = new PasswordHasher<LogUser>();

                // verify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.password, userSubmission.log_password);

                // result can be compared to 0 for failure
                if (result == 0)
                {
                    string msg = "Invalid Email/Password!";
                    return RedirectToAction("Index", new { msg = msg });
                }
                else
                {
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("Logging In");
                    Console.WriteLine("***********************************************");
                    HttpContext.Session.SetObjectAsJson("User", userInDb);
                    return RedirectToAction("Success");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }

    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes the object to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}

// ViewBag.Errors = new List<string>();
// ViewBag.Errors = ModelState.Values;
