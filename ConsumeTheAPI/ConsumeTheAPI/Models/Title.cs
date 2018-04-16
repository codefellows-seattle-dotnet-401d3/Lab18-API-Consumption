using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeTheAPI.Models
{
    public class Title
    {
        public int Id { get; set; }
        public static Title Titles { get; set; }
        public string Url { get; set; }
        public CommentCollection CommentCollection { get; set; }
    }
}
