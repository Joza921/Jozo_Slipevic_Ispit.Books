using Ispit.Books.Models.Dbo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Books.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed Autori
            modelBuilder.Entity<Author>().HasData(

                new Author
                {
                     Id = 1,
                    FirstName = "Mato",
                    LastName = "Lovrak"


                },

                new Author
                {
                    Id = 2,
                    FirstName = "Zoran",
                    LastName = "Ferić"
                },

                 new Author
                 {
                     Id = 3,
                     FirstName = "Ivan",
                     LastName = "Mažuranić"
                 },
                   new Author
                   {
                       Id = 4,
                       FirstName = "Dragutin",
                       LastName = "Tadijanović"
                   },
                     new Author
                     {
                         Id = 5,
                         FirstName = "Ivo",
                         LastName = "Andrić"
                     }

                );
            #endregion


            #region Seed Izdavaci
            modelBuilder.Entity<Publisher>().HasData(

                new Publisher
                {
                     Id=1,
                    Name = "Algoritam"
                },
                 new Publisher
                 {
                     Id=2,
                     Name = "Barka"
                 },
                  new Publisher
                  {
                      Id=3,
                      Name = "Educa"
                  }



                );
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Authors { get; set; }   
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }

    }
}
