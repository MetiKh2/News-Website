using Microsoft.EntityFrameworkCore;
using MyCms.Domain.Entities.Categories;
using MyCms.Domain.Entities.News;
using MyCms.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyCms.Application.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<User> Users { set; get; }
        DbSet<Roles> Roles { set; get; }
        DbSet<UserInRoles> UserInRoles { set; get; }
        DbSet<Category> Categories { set; get; }
        DbSet<News> News { set; get; }
        DbSet<NewsImage> NewsImage { set; get; }
        DbSet<NewsLikes> NewsLikes { set; get; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
