using RecNetSharp.Models.RecNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecNetSharp.Models.RecNetSharp
{
    //  this is basically account but the masks are replaced with lists
    public class Profile
    {
        public long accountId { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string profileImage { get; set; }
        public string bannerImage { get; set; }
        public bool isJunior { get; set; }
        public List<Platform> platforms { get; set; }
        public List<Pronoun> personalPronouns { get; set; }
        public List<IdentityFlag> identityFlags { get; set; }
        public DateTime createdAt { get; set; }
        public bool isMetaPlatformBlocked { get; set; }
    }
}
