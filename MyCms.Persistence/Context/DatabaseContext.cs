using Microsoft.EntityFrameworkCore;
using MyCms.Application.Interfaces;
using MyCms.Common.Roles;
using MyCms.Domain.Entities.Categories;
using MyCms.Domain.Entities.News;
using MyCms.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Persistence.Context
{
   public class DatabaseContext:DbContext,IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<User> Users { set; get; }
        public virtual DbSet<Roles> Roles { set; get; }
        public virtual DbSet<UserInRoles> UserInRoles { set; get; }
        public virtual DbSet<Category> Categories { set; get; }
        public virtual DbSet<News> News { set; get; }
        public virtual DbSet<NewsImage> NewsImage { set; get; }
        public virtual DbSet<NewsLikes> NewsLikes { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Roles>().HasData(new Roles { ID = 1, Role = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Roles>().HasData(new Roles { ID = 2, Role = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Roles>().HasData(new Roles { ID = 3, Role = nameof(UserRoles.Customer) });
            


            modelBuilder.Entity<User>().HasIndex(e => e.Email).IsUnique(); 
            modelBuilder.Entity<User>().HasIndex(e => e.Mobile).IsUnique();


            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Roles>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserInRoles>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<News>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<NewsImage>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<NewsLikes>().HasQueryFilter(p => !p.IsRemoved);

        }


    }
}
