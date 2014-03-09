using System;
using System.Linq;
using SyncModel.Data.DataContexts;
using SyncModel.Data.Models;

namespace SyncModel.Data.Repositories
{
    public class UsersRepository
    {
        public UserProfile GetUserProfileByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Parameter is null or empty","name");
            }

            using (var usersContext = new UsersContext())
            {
                return usersContext.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == name.ToLower());
            }
        }
    }
}
