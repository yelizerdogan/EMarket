namespace Vektorel.EMarket.Datacore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vektorel.EMarket.Datacore.Context;
    using Vektorel.EMarket.Domain.Model.EMarketDb;
    using MAA.Basecore.Helpers.Common;

    internal sealed class Configuration : DbMigrationsConfiguration<Vektorel.EMarket.Datacore.Context.EMarketDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EMarketDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Users.AddOrUpdate(x => x.Email, new ApplicationUser
            {
                Password = "admin2019".GetMD5Hash(),
                Email = "admin@email.com",
                FullName = "Admin User",
                PicturePath = "default.jpg"
            });


            context.SaveChanges();
        }
    }
}
