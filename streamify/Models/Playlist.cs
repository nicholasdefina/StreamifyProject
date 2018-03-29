using System;
using System.Collections.Generic;
using streamify.Models;
using streamify;
using System.ComponentModel.DataAnnotations;

namespace streamify.Models

{
    public class Playlist:BaseEntity

    {
        public int PlaylistId {get;set;}
        public int UserId {get;set;}

        [Required]
        [MinLength(2, ErrorMessage="Playlist name must be at least 2 characters long.")]
        public string PName {get;set;}

        public List<Music>Musics {get;set;}

        public Playlist()  //constructor class

        {
            Musics = new List<Music>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

        }
    }
}