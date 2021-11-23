using System;
using System.Collections.Generic;
using System.Text;

namespace MurrrcatConsoleCodeFirst.DAL
{
    class Cat
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float CutenessSum { get; set; }
        public int VotesCount { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public string Description { get; set; }

        public Owner Owner { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
