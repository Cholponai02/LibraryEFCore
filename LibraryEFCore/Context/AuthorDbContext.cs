using LibraryEFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryEFCore.Configurations;

namespace LibraryEFCore.Context
{
    internal class AuthorDbContext : DbContext
    {
        protected string _connectionString { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public AuthorDbContext(DbContextOptions<AuthorDbContext> options) : base(options)
        {

        }
        public AuthorDbContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        }
    }
}
