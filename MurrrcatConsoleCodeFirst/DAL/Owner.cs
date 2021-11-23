using System;
using System.Collections.Generic;
using System.Text;

namespace MurrrcatConsoleCodeFirst.DAL
{
    class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contacts { get; set; }

        public virtual ICollection<Cat> Cats { get; set; } = new HashSet<Cat>();
    }
}
