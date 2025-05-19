using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie.Models.Entities
{
    [Table("MemberUnit")]
    public class MemberUnit
    {
        [Key]
        public int MemberUnitId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string WebsiteUrl { get; set; }
    }
}
