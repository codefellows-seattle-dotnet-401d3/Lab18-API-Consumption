using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18Magic.Models
{
    public class DeckViewModel
    {
        public List<Deck> decks;
        public List<Card> cards;
        public SelectList name;
        public SelectList card;
        public string DeckName { get; set; }
    }
}
