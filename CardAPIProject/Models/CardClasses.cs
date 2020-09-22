using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardAPIProject.Models
{

    public class SingleCard
    {
        public string code { get; set; }
        public string image { get; set; }
        public string suit { get; set; }
        public string value { get; set; }
    }

    public class Cards
    {
        public string deck_id { get; set; }
        public int remaining { get; set; }
        public bool shuffled { get; set; }

        public SingleCard[] cards { get; set; }
    }
}
