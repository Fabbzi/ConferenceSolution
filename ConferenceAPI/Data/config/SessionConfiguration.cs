using ConferenceAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ConferenceAPI.Data.config
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(s => s.SessionID);

            builder.Property(s => s.SessionTitle)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Speaker)
                .HasMaxLength(50);

            builder.Property(s => s.SessionDateTime)
                .IsRequired();

            builder.HasData(
                new Session
                {
                    SessionID = 101,
                    SessionTitle = "Introduction to C#",
                    Speaker = "Dr. Alan Turing",
                    SessionDateTime = DateTime.Parse("2025-04-01T09:00:00")
                },
                new Session
                {
                    SessionID = 102,
                    SessionTitle = "Advanced SQL Queries",
                    Speaker = "Prof. Grace Hopper",
                    SessionDateTime = DateTime.Parse("2025-04-01T11:00:00")
                },
                new Session
                {
                    SessionID = 103,
                    SessionTitle = "IoT: The Future of Tech",
                    Speaker = "Mr. Elon Mask",
                    SessionDateTime = DateTime.Parse("2025-04-01T14:00:00")
                }
            );
        }
    }
}
