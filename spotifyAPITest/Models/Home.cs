using System;
using System.Collections.Generic;
using spotifyAPITest.Models;
using spotifyAPITest;
using System.ComponentModel.DataAnnotations;

namespace spotifyAPITest.Models  //this model is all the fields to be passed into the DB.

{
    public class Home : BaseEntity
    {
        public int HomeId {get;set;}
        public string First {get;set;}
        public string Last {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public Home() //constructor class
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}