using GameWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameWeb
{
    public class GameWebDbContext : DbContext
    {
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public GameWebDbContext() : base("name=GameWebDbContext")
        {
            Database.SetInitializer<GameWebDbContext>(new DropCreateDatabaseIfModelChanges<GameWebDbContext>());
        }
    }
}