using System;
using System.Collections.Generic;

#nullable disable

namespace MurrcatConsole.MurrcatModel
{
    public partial class CatCategory
    {
        public string Cat { get; set; }
        public int Category { get; set; }

        public virtual Cat CatNavigation { get; set; }
        public virtual Category CategoryNavigation { get; set; }
    }
}
