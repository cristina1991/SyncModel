using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FileMVC.Models
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