using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPCAuthenticationModule.Models
{
    public class AuthDBContext: IdentityDbContext
    {
        public AuthDBContext(DbContextOptions<AuthDBContext> options): base(options)
        {

        }

        public DbSet<RPCAuthenticationModule.viewModels.User> User { get; set; }
    }
}
