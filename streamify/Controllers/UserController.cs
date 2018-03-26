using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using streamify.Models;
using streamify;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace streamify.Controllers
{
    public class UserController : Controller
    {
        private StreamifyContext _context;
        
        public UserController(StreamifyContext context)

        {
            _context = context;
        }

        public int SessionCheck()
        {
          int? userid = HttpContext.Session.GetInt32("userid");
          if(userid ==null)

          {
              return 0;
          }
          return (int)userid;
        }
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(SessionCheck()==0)
            {
                return View("Index");
            }
            else
            {
                return RedirectToAction("Success");
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserViewModels model)  //checking passed in model against UserViewModel validations
        {
            if (ModelState.IsValid)
            {
                User exist = _context.Users.SingleOrDefault(u =>u.Email == model.Reg.Email); //query to set exist to check if email input already exists in db

                if(exist !=null)
                {
                    ModelState.AddModelError("Reg.Email","That email already exists in the database.");
                    return View ("Index");
                }
                else
                {
                    PasswordHasher<UserViewModels> hasher = new PasswordHasher<UserViewModels>();
                    string hashed = hasher.HashPassword(model, model.Reg.Password);
                    User newUser = new User
                    {
                        First = model.Reg.First,
                        Last = model.Reg.Last,
                        Email = model.Reg.Email,
                        Password = hashed,
                    };

                    _context.Add(newUser);
                    _context.SaveChanges();
                    User CurrUser = _context.Users.SingleOrDefault(user => user.Email == newUser.Email); //see the newly created object by grabbing email
                    HttpContext.Session.SetInt32("userid", CurrUser.UserId); //setting session id
                    HttpContext.Session.SetString("username", CurrUser.First); //seting username to first name of session user
                    

                    return RedirectToAction("Success", "User");
                }
            }
            else
            {
                return View("Index");
            }

            
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserViewModels model)
        {
            if (ModelState.IsValid)

            {
                User exist = _context.Users.SingleOrDefault(u =>u.Email == model.Login.Email); //query to set exist to check if email input already exists in db
                if(exist == null)
                {
                    ModelState.AddModelError("Login.Email", "Email not found.");
                    return View("Index");
                }

                var hasher = new PasswordHasher<User>();

                if(hasher.VerifyHashedPassword(exist, exist.Password, model.Login.Password) == 0)
                {
                    ModelState.AddModelError("Login.Password", "Incorrect Password");
                    return View("Index");
                }
                else
                {
                    HttpContext.Session.SetInt32("userid",exist.UserId);
                    HttpContext.Session.SetString("username",exist.First);

                    return RedirectToAction("Success","User");
                }

            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        [Route("success")]

        public IActionResult Success()
        {
            ViewBag.Name = HttpContext.Session.GetString("username");
            return View("success");
        }

        [HttpGet]
        [Route("logout")]

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
