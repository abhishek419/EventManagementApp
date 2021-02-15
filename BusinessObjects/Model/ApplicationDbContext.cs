using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ApplicationDbContext")
        {

        }

        public DbSet<UserDBO> User { get; set; }

        public DbSet<EventsDBO> Event { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<CommentDBO> Comment { get; set; }
    }
}
