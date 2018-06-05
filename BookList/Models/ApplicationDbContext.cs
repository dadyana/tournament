using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Name).HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(b => b.Name).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Autor).HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(b => b.Editora).HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(b => b.Ano).HasMaxLength(4);

        }
    }
}
