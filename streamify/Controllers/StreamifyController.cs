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
    public class StreamifyController : Controller
    {
        private StreamifyContext _context;

        public StreamifyController(StreamifyContext context)

        {
            _context = context;
        }

        public int SessionCheck()
        {
            int? userid = HttpContext.Session.GetInt32("userid");
            if (userid == null)

            {
                return 0;
            }
            return (int)userid;
        }

        [HttpGet]
        [Route("dashboard")]

        public IActionResult Dashboard()
        {
            if (SessionCheck() == 0)
            {
                return RedirectToAction("Index", "User");
            }

            return View("dashboard");

        }


        [HttpGet]
        [Route("album/{albumid}")]
        public IActionResult Album(int albumid)
        {
            if (SessionCheck() == 0)
            {
                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("Dashboard", "Streamify");
            // Other code
        }


        [HttpGet]
        [Route("search")]
        public IActionResult Search (string input)
        {
            if (SessionCheck() == 0)
            {
                return RedirectToAction("Index", "User");
            }

            return RedirectToAction ("Dashboard", "Streamify");
        }

        [HttpGet]
        [Route("addsong")]

        public IActionResult AddSong ()
        {
            if (SessionCheck() == 0)
            {
                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("Dashboard","Streamify");
        }


        [HttpGet]
        [Route("artist/{artistId}")]
        public IActionResult Artist()

        {
            if (SessionCheck() == 0)
            {
                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("Dashboard","Streamify");
        }


        [HttpGet]
        [Route("playlist/{playlistId}")]
        public IActionResult Playlist()
        {
            if (SessionCheck() == 0)
            {
                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("Dashboard","Streamify");
        }

        [HttpGet]
        [Route("suggestions")]

        public IActionResult Suggestions()
        {
            if (SessionCheck() == 0)
            {
                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("Dashboard","Streamify");
        }

        [HttpGet]
        [Route("friends/{friendId}")]
        public IActionResult Friends()

        {
            if (SessionCheck() == 0)
            {
                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("Dashboard","Streamify");
        }


        [HttpGet]
        [Route("profile/{userid}")]
        public IActionResult Profile()

        {
            if (SessionCheck() == 0)
            {
                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("Dashboard","Streamify");
        }
    }
}
