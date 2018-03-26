using System;

namespace streamify.Models

{
    public class Playlist:BaseEntity

    {
        public int PlaylistId {get;set;}
        public int UserId {get;set;}

        public int SongId {get;set;}  //create object of User type named User. For queries only, not placed in DB

        public Playlist()  //constructor class

        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

        }
    }
}