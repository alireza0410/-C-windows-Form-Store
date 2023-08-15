namespace project1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<project1.DB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "project1.DB";
        }

        protected override void Seed(project1.DB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
