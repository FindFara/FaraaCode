using CodeTo.Domain.Entities.Users;
using CodeTo.Domain.Entities.Wallet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
