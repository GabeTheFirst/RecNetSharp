using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecNetSharp.Models.RecNet
{
    public class ImageComment
    {
        public long SavedImageCommentId { get; set; }
        public long SavedImageId { get; set; }
        public string Comment { get; set; }
        public int CheerCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
