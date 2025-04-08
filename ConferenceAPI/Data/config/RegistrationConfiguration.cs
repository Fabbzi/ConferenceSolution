using ConferenceAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ConferenceAPI.Data.config
{
    public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.HasKey(r => r.RegistrationID);

            builder.Property(r => r.RegistrationDate)
                .IsRequired();

            builder.HasOne(r => r.Attendee)
                .WithMany(a => a.Registrations)
                .HasForeignKey(r => r.AttendeeID);

            builder.HasOne(r => r.Session)
                .WithMany(s => s.Registrations)
                .HasForeignKey(r => r.SessionID);

            builder.HasData(
                new Registration
                {
                    RegistrationID = 1,
                    AttendeeID = 1,
                    SessionID = 101,
                    RegistrationDate = DateTime.Parse("2025-03-15")
                },
                new Registration
                {
                    RegistrationID = 2,
                    AttendeeID = 2,
                    SessionID = 102,
                    RegistrationDate = DateTime.Parse("2025-03-20")
                },
                new Registration
                {
                    RegistrationID = 3,
                    AttendeeID = 3,
                    SessionID = 103,
                    RegistrationDate = DateTime.Parse("2025-03-25")
                }
            );
        }
    }
}
