using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MurrrcatConsoleCodeFirst.DAL
{
    class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Cat> Cats { get; set; }
    }
}
