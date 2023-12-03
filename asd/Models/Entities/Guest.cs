using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asd.Models.Entities
{
    public class Guest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GuestID { get; set; }

        [ForeignKey("Company")]
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
