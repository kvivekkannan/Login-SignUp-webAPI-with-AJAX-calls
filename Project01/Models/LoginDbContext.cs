using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Project01.Models
{
    public class LoginDbContext : DbContext
    {
        public DbSet<UserDetails> userdetails { get; set; }
    }
}