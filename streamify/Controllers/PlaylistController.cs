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
using Microsoft.EntityFrameworkCore;

namespace streamify.Controllers
{
    public class PlaylistController : Controller
    {
        private StreamifyContext _context;
        
        public PlaylistController(StreamifyContext context)

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
        [Route("dashboard")] 

        public IActionResult Dashboard()
        {
            if (SessionCheck()==0)
            {
                return RedirectToAction("Index","User");
            }

            return View("dashboard");

        }


    }
}
