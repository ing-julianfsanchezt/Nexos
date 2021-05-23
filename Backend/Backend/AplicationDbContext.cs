using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Editorial> Editorial { get; set; }
    }
}
