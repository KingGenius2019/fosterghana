using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDbConext : DbContext
    {
        
        public ApplicationDbConext(DbContextOptions options) : base(options)
        {
        }

    //    public DbSet<Child> Children;
      public DbSet<Child> Children {get; set;}
    }
}