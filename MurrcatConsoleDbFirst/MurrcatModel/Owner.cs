using System;
using System.Collections.Generic;

#nullable disable

namespace MurrcatConsole.MurrcatModel
{
    public partial class Owner
    {
        public Owner()
        {
            Cats = new HashSet<Cat>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Contacts { get; set; }

        public virtual ICollection<Cat> Cats { get; set; }
    }
}
