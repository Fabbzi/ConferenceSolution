using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConferenceAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    AttendeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.AttendeeID);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SessionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Speaker = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionID);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendeeID = table.Column<int>(type: "int", nullable: false),
                    SessionID = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationID);
                    table.ForeignKey(
                        name: "FK_Registrations_Attendees_AttendeeID",
                        column: x => x.AttendeeID,
                        principalTable: "Attendees",
                        principalColumn: "AttendeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Sessions_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Sessions",
                        principalColumn: "SessionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "AttendeeID", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", "Doe" },
                    { 2, "jane.smith@example.com", "Jane", "Smith" },
                    { 3, "emily.jones@example.com", "Emily", "Jones" }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionID", "SessionDateTime", "SessionTitle", "Speaker" },
                values: new object[,]
                {
                    { 101, new DateTime(2025, 4, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Introduction to C#", "Dr. Alan Turing" },
                    { 102, new DateTime(2025, 4, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), "Advanced SQL Queries", "Prof. Grace Hopper" },
                    { 103, new DateTime(2025, 4, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), "IoT: The Future of Tech", "Mr. Elon Mask" }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "RegistrationID", "AttendeeID", "RegistrationDate", "SessionID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 101 },
                    { 2, 2, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 102 },
                    { 3, 3, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 103 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_AttendeeID",
                table: "Registrations",
                column: "AttendeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_SessionID",
                table: "Registrations",
                column: "SessionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
