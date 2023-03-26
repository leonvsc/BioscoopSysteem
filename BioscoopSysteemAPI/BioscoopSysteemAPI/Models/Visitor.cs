using System.ComponentModel.DataAnnotations;

namespace BioscoopSysteemAPI.Models
{
    public class Visitor
    {
        // Properties
        public int VisitorId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public byte Age { get; set; }

    }
}