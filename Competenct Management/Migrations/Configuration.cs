namespace Competenct_Management.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<User_CapabilityDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Competenct_Management.Models.User_CapabilityDBContext context)
        {
            ///Competenct_Management.Models.User_Capability
              ///This method will be called after migrating to the latest version.

              ///You can use the DbSet<T>.AddOrUpdate() helper extension method 
              ///to avoid creating duplicate seed data. E.g.
            
                ////context.People.AddOrUpdate(
                  ///p => p.FullName,
                  ///new Person { FullName = "Andrew Peters" },
                  ///new Person { FullName = "Brice Lambson" },
                  ///new Person { FullName = "Rowan Miller" }
                ///);
            
        }
    }
 }


