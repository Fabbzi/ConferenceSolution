using System.ComponentModel.DataAnnotations;

namespace ConferenceAPI.Models
{
    public class Attendee
    {
        [Key]
        public int AttendeeID { get; set;}

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}
