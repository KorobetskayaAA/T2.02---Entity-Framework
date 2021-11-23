using System;
using System.Collections.Generic;

#nullable disable

namespace MurrcatConsole.MurrcatModel
{
    public partial class Cat
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float CutenessSum { get; set; }
        public int VotesCount { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public string Description { get; set; }
        public int Owner { get; set; }

        public virtual Owner OwnerNavigation { get; set; }
    }
}
