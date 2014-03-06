using System.Data.Entity;

namespace SyncModel.Models
{
    public class FileMVCdb :DbContext
    {
        public FileMVCdb()
            : base("name = DefaultConnection")
        { }
        public DbSet<Files> fisiere { get; set; }
        public DbSet<UserProfile>  UserProfiles { get; set; }
    }
}