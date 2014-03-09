using System.Runtime.Serialization;

namespace SyncModel.SyncService.DataContracts
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int UserId;

        [DataMember] 
        public string Username;
    }
}
