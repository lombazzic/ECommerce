using cancellieri.andre.ecommerc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


    public class Database : DbContext
    {
        public Database(){}

        protected override void 
                OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source=database.db");

        public DbSet<Utente> Utenti { get ; set; }
        public string? Nome { get; set; }
    }
