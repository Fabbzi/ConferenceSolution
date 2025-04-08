using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceAPI.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationID { get; set; }

        [Required]
        [ForeignKey("Attendee")]
        public int AttendeeID { get; set; }

        [Required]
        [ForeignKey("Session")]
        public int SessionID { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public Attendee Attendee { get; set; }
        public Session Session { get; set; }
    }
}