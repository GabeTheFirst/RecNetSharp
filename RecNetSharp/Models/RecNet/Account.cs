using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecNetSharp.Models.RecNet
{
    public class Account
    {
        // this is actually an int I'm pretty sure, but why not just in case (other than SPEED)?
        public long accountId { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string profileImage { get; set; }
        public string bannerImage { get; set; }
        public bool isJunior { get; set; }
        public PlatformMask platforms { get; set; }
        public PronounsMask personalPronouns { get; set; }
        public IdentityFlagsMask identityFlags { get; set; }
        public DateTime createdAt { get; set; }
        public bool isMetaPlatformBlocked { get; set; }
    }
}
