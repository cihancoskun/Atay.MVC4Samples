
namespace Atay.MVC4Samples.Web.Models
{
    using System.Data.Entity;

    public class AtayMvc4SamplesWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        public AtayMvc4SamplesWebContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AtayMvc4SamplesWebContext>());
        }


        public DbSet<Page> Pages { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}