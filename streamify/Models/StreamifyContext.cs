using Microsoft.EntityFrameworkCore;

namespace streamify.Models  //A DbContext instance represents a session with the database and can be used to query and save instances of your entities. 

{
    public class StreamifyContext: DbContext

    {
        //this context is what actually sets tables in pgadmin
        public StreamifyContext(DbContextOptions<StreamifyContext>options) : base(options){}
        public DbSet<Playlist>Playlists {get;set;}
        public DbSet<User>Users {get;set;}

        public DbSet<Music> Musics {get;set;}

    }
}