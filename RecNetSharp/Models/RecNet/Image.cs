using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecNetSharp.Models.RecNet
{
    public class Image
    {
        public long Id { get; set; }
        public string ImageName { get; set; }
        public string? Description { get; set; }
        public long PlayerId { get; set; }
        public long RoomId { get; set; }
        public long? PlayerEventId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CheerCount { get; set; }
        public int CommentCount { get; set; }
    }
}
