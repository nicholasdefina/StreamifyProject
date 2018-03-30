using System;

namespace streamify.Models

{
    public class Music:BaseEntity

    {
        public int PlaylistId{get;set;}
        public int MusicId {get;set;}

        public string Song {get;set;}

        public string Artist {get;set;}  //create object of User type named User. For queries only, not placed in DB

        
    }
}