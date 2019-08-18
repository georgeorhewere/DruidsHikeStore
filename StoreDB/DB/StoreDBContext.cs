using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDB.DB
{
    public class StoreDBContext:DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options)
                            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreDB.User>().HasData(
                new StoreDB.User("Kenny", "Rogers", "kennyrg@gmail.com") {  UserId = 1},
                new StoreDB.User("Barry", "White", "barryr@gmail.com") { UserId = 2 },
                new StoreDB.User("Jane", "Fonda", "janefonda@gmail.com") { UserId = 3 },
                new StoreDB.User("Sam", "Etto", "sametto@gmail.com") { UserId = 4 }
                , new StoreDB.User("Adam", "Sandler", "adamsandler@gmail.com") { UserId = 5 }
                , new StoreDB.User("Olivia", "stone", "oliviastone@gmail.com") { UserId = 6 });
            }

        }
}
