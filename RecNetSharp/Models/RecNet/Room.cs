using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecNetSharp.Models.RecNet
{
    public class Room
    {
        public long RoomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public WarningMask WarningMask { get; set; }
        public string CustomWarning { get; set; }
        public long CreatorAccountId { get; set; }
        public bool SupportsLevelVoting { get; set; }
        public bool IsRRO { get; set; }
        public bool SupportsScreens { get; set; }
        public bool SupportsWalkVR { get; set; }
        public bool SupportsTeleportVR { get; set; }
        public bool SupportsVRLow {  get; set; }
        public bool SupportsQuest2 { get; set; }
        public bool SupportsMobile { get; set; }
        public bool SupportsJuniors { get; set; }
        public int MinLevel { get; set; }
        public DateTime CreatedAt { get; set; }
        public RoomStats Stats { get; set; }
        public bool IsDorm { get; set; }
        public int MaxPlayers { get; set; }
    }
}
