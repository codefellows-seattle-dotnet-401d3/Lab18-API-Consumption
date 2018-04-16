using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeTheAPI.Models
{
    public class CommentCollection
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public object Titles { get; internal set; }
    }
}
