using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MurrrcatConsoleCodeFirst.DAL
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Cat> Cats { get; set; }
    }
}
