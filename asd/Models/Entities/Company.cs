using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asd.Models.Entities
{
    public class Company
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public ICollection<Guest> Guests { get; set; }

    }
}
