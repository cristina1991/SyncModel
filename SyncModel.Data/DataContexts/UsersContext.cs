using System.Data.Entity;
using SyncModel.Data.Models;

namespace SyncModel.Data.DataContexts
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
