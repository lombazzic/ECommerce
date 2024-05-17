using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

    public class databaseP : DbContext
    {
        public databaseP (DbContextOptions<databaseP> options)
            : base(options)
        {
        }

        public DbSet<Prodotto> Prodotti { get; set; } = default!;
    }
