namespace OAuthAttempt.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OAuthAttempt.OAuthDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OAuthAttempt.OAuthDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Clients.AddOrUpdate(
        client => client.Name,
        new Client
        {
            Id = "42ff5dad3c274c97a3a7c3d44b67bb42",
            Name = "Demo Resource Owner Password Credentials Grant Client",
            ClientSecretHash = new PasswordHasher().HashPassword("client123456"),
            AllowedGrant = OAuthGrant.ResourceOwner,
            CreatedOn = DateTimeOffset.UtcNow
        });

            context.Users.AddOrUpdate(
                user => user.UserName,
                new IdentityUser("Tugberk")
                {
                    Id = Guid.NewGuid().ToString("N"),
                    PasswordHash = new PasswordHasher().HashPassword("user123456"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Email = "tugberk@example.com",
                    EmailConfirmed = true
                });
        }
    }
}
