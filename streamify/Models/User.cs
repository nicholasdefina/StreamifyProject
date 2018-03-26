using System;
using System.Collections.Generic;
using streamify.Models;
using streamify;
using System.ComponentModel.DataAnnotations;

namespace streamify.Models  //this model is all the fields to be passed into the DB.

{
    public class User : BaseEntity
    {
        public int UserId {get;set;}
        public string First {get;set;}
        public string Last {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}

        public DateTime BDay {get;set;}

        public List<Playlist> Playlists {get;set;} //creating a blueprint list type of playlist called RSVP to use as a join table
        public User() //constructor class
        {
            Playlists = new List<Playlist>();  //instantiating playlists as a new list of playlist type
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}