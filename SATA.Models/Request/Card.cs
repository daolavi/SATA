using System.ComponentModel.DataAnnotations;

namespace SATA.Models.Request
{
    public class Card
    {
        [Required]
        public string CardNumber { get; set; }

        [Required]
        [MinLength(6),MaxLength(6)]
        [RegularExpression("^[0-9]*$")]
        public string ExpiryDate { get; set; }
    }
}
