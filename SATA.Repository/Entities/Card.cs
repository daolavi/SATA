using System;
using System.ComponentModel.DataAnnotations;

namespace SATA.Repository.Entities
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(15), MaxLength(16)]
        public string CardNumber { get; set; }
    }
}
