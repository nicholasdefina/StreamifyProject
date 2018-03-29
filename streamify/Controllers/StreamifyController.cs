using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using streamify.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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
            ViewBag.Results = "";
            ViewBag.Playlists = _context.Playlists.ToList();
            return View("dashboard");
        }

        [HttpGet]
        [Route("GetArtist/{search}")]
        public IActionResult GetArtist(string search)
        {
            
            object ArtistInfo = new JObject();
            WebRequest.GetArtist(search, ApiResponse =>
                {
                    ArtistInfo = ApiResponse;
                    System.Console.WriteLine("=============ArtistInfo 1===", ArtistInfo);
                    ViewBag.Results = ArtistInfo;
                    
                }
            ).Wait();
            // System.Console.WriteLine("=============ArtistInfo 2===", ArtistInfo);
            
            return View("artistresult");
        }


        [HttpGet]
        [Route("GetAlbum/{search}")]
        public IActionResult GetAlbum(string search)
        {
            
            object AlbumInfo = new JObject();
            WebRequest.GetAlbum(search, ApiResponse =>
                {
                    AlbumInfo = ApiResponse;  //albuminfo object equals the entire result from the api response
                    System.Console.WriteLine("=============AlbumInfo 1===", AlbumInfo);
                    ViewBag.Results = AlbumInfo;
                    
                }
            ).Wait();
        
            return View("albumresult");
        }

        [HttpGet]
        [Route("GetTrack/{search}")]
        public IActionResult GetTrack(string search)
        {
            
            object TrackInfo = new JObject();
            WebRequest.GetTrack(search, ApiResponse =>
                {
                    TrackInfo = ApiResponse;
                    System.Console.WriteLine("=============TrackInfo 1===", TrackInfo);
                    ViewBag.Results = TrackInfo;
                    
                }
            ).Wait();
        
            return View("trackresult");
        }


        [HttpPost]
        [Route("newplaylist")]
        public IActionResult NewPlaylist(Playlist model)

        {
            if (SessionCheck()==0)
            {
                return RedirectToAction("Index","User");
            }

            if (ModelState.IsValid)
            {
                Playlist exist = _context.Playlists.SingleOrDefault(x =>x.PName == model.PName); //query to set exist to check if playlist input already exists in db

                if(exist !=null)
                {
                    ModelState.AddModelError("PName","That playlist name already exists in the database.");
                    return View ("dashboard");
                }

                else
                {
                    Playlist newPlaylist = new Playlist
                    {
                        PName=model.PName,
                        UserId=(int)SessionCheck()
                    };

                    _context.Add(newPlaylist);
                    _context.SaveChanges(); 
                    return RedirectToAction("Dashboard","Streamify");  
                }
            }

            else
            {
                return View("dashboard");
            }
        }

        [HttpGet]
        [Route("playlists")]
        public IActionResult Playlists()

        {
            if (SessionCheck()==0)
            {
                return RedirectToAction("Index","User");
            }

            return RedirectToAction("playlists");
        }


        [HttpGet]
        [Route("show/{playlistId}")]
        public IActionResult Playlists(int playlistId)
        {
            if (SessionCheck()==0)
            {
                return RedirectToAction("Index","User");
            }
            
            User userInSession = _context.Users.SingleOrDefault(u=>u.UserId == SessionCheck());
            ViewBag.User = userInSession;
            // ViewBag.Playlists = _context.Music.Include (p => p.)
        
            return View("playlists");
        }
    }
}