using CodeTo.Domain.Entities.Permissions;
using CodeTo.Domain.Entities.Users;
using CodeTo.Domain.Entities.Wallet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeTo.Domain.Entities.Articles;
using CodeTo.Domain.Entities.Courses;
using Microsoft.Extensions.Options;

namespace CodeTo.DataEF.Context
{
    public class CodeToContext : DbContext
    {
        public CodeToContext(DbContextOptions<CodeToContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Article> Articles { get; set; }
   
        public DbSet<ArticleGroup> ArticleGroups { get; set; }
        public DbSet<ArticleComment> ArticleComments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseGroup> CourseGroups { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<UserRole>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Article>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<ArticleGroup>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Course>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<CourseGroup>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<ArticleComment>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Wallet>().HasQueryFilter(u => !u.IsDeleted);

            #region SeedData
            //modelBuilder.Entity<User>().HasData(new User
            //{
            //    Id = 1,
            //    IsBlocked = false,
            //    AvatarImageName = "profile.png",
            //    CreateDate = new DateTime(2021, 12, 24, 13, 23, 00),
            //    Email = "hosseinKhakpoor@gmail.com",
            //    UserName = "Admin",
            //    IsEmailActive = true,
            //    Password = "ACzGe/muivlpjt6DH0gaVdzHp0y+h4xgJmT84gKoacZ6ImLRt0zpgRfBElJd1ZBF+Q==",//123 or 1234,
            //    IsDeleted = false,
            //});

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}