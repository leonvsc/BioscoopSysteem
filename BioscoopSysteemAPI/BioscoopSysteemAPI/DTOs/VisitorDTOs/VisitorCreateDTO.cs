using System.ComponentModel.DataAnnotations;

namespace BioscoopSysteemAPI.DTOs.VisitorDTOs
{
    public class VisitorCreateDTO
    {

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public byte Age { get; set; }
    }
}