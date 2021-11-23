using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MurrrcatConsoleCodeFirst.DAL
{
    class Cat
    {
        [Key]
        [MaxLength(50)]
        public string Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public float CutenessSum { get; set; } = 0;
        public int VotesCount { get; set; } = 0;
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public int OwnerId { get; set; }
        [Required]
        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
