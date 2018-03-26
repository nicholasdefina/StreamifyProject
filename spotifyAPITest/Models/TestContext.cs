using Microsoft.EntityFrameworkCore;

namespace spotifyAPITest.Models  //A DbContext instance represents a session with the database and can be used to query and save instances of your entities. 

{
    public class TestContext: DbContext

    {
        //this context is what actually sets tables in pgadmin
        public TestContext(DbContextOptions<TestContext>options) : base(options){}
        public DbSet<Home>Homes {get;set;}
        
    }
}