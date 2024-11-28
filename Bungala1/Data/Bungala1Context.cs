using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bungala1.Models;

namespace Bungala1.Data
{
    public class Bungala1Context : DbContext
    {
        public Bungala1Context (DbContextOptions<Bungala1Context> options)
            : base(options)
        {
        }

        public DbSet<Bungala1.Models.ShrekMitiu> ShrekMitiu { get; set; } = default!;
    }
}
