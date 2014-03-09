using System.Data.Entity;
using SyncModel.Data.Models;

namespace SyncModel.Data.DataContexts
{
    public class FilesContext :DbContext
    {
        public FilesContext()
            : base("name = DefaultConnection")
        { }
        public DbSet<File> Fisiere { get; set; }
        public DbSet<UserProfile>  UserProfiles { get; set; }
    }
}