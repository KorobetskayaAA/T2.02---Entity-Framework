using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MurrrcatConsoleCodeFirst.DAL
{
    class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Contacts { get; set; }
        public int Rating { get; set; }

        public ICollection<Cat> Cats { get; set; } = new HashSet<Cat>();
    }
}
