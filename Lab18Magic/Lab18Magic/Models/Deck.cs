using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18Magic.Models
{
    public class Deck
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Card> Cards { get; set; }
    }
}
