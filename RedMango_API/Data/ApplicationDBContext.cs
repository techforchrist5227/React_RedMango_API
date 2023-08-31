using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedMango_API.Models;
using static System.Net.Mime.MediaTypeNames;

namespace RedMango_API.Data
{//get user, registration, and roles tables by using the identity entity framework core
    //this is the application db context to connect the api to the sql database
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>//uses authentication and authorization
    {       
            //constructor that initializes the access to the DB Context. passes in "options" as an argument to the "identitydbcontext"
            public ApplicationDBContext (DbContextOptions options) : base(options)  
            {
                
             }
        //Entity framework will create a database table for these db sets
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }//Identityframework knows that application user is a subset of User
        public DbSet<MenuItem> MenuItems { get; set; }

        //overriding OnModelCreating method to "Seed" the menu items so we can play around with them. You can override the OnModelCreating method in your derived context and use the fluent API to configure your model. This is the most powerful method of configuration and allows configuration to be specified without modifying your entity classes.

        //Creating MenuItems
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //basic config that's always needed due to the identity tables
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MenuItem>().HasData(
               new MenuItem
               {
                Id = 1,
                Name = "Spring Roll",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Image = "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/spring roll.jpg",
                Price = 7.99,
                Category = "Appetizer",
                SpecialTag = ""
            }, new MenuItem
            {
                Id = 2,
                Name = "Idli",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Image = "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/idli.jpg",
                Price = 8.99,
                Category = "Appetizer",
                SpecialTag = ""
            }, new MenuItem
            {
                Id = 3,
                Name = "Panu Puri",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Image = "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/pani puri.jpg",
                Price = 8.99,
                Category = "Appetizer",
                SpecialTag = "Best Seller"
            }, new MenuItem
            {
                Id = 4,
                Name = "Hakka Noodles",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Image = "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/hakka noodles.jpg",
                Price = 10.99,
                Category = "Entrée",
                SpecialTag = ""
            }, new MenuItem
            {
                Id = 5,
                Name = "Malai Kofta",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Image = "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/malai kofta.jpg",
                Price = 12.99,
                Category = "Entrée",
                SpecialTag = "Top Rated"
            }, new MenuItem
            {
                Id = 6,
                Name = "Paneer Pizza",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Image = "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/paneer pizza.jpg",
                Price = 11.99,
                Category = "Entrée",
                SpecialTag = ""
            }, new MenuItem
            {
                Id = 7,
                Name = "Paneer Tikka",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Image = "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/paneer tikka.jpg",
                Price = 13.99,
                Category = "Entrée",
                SpecialTag = "Chef's Special"
            }, new MenuItem
            {
                Id = 8,
                Name = "Carrot Love",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Image = "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/carrot love.jpg",
                Price = 4.99,
                Category = "Dessert",
                SpecialTag = ""
            }, new MenuItem
            {
                Id = 9,
                Name = "Rasmalai",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Image = "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/rasmalai.jpg",
                Price = 4.99,
                Category = "Dessert",
                SpecialTag = "Chef's Special"
            }, new MenuItem
            {
                Id = 10,
                Name = "Sweet Rolls",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                Image = "https://reactredmangopiczures.blob.core.windows.net/reactecommerceredmango/sweet rolls.jpg",
                Price = 3.99,
                Category = "Dessert",
                SpecialTag = "Top Rated"
            });
        }

         
        
    }
}
