using Microsoft.EntityFrameworkCore.Migrations;
using System.Runtime.CompilerServices;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
     table: "AspNetUsers",
     columns: new[] { "Id", "Gender", "FirstName", "LastName", "Phone", "DateOfBirth",
         "CompletedBookings", "CouponsUsed", "UserName", "Email",
         "EmailConfirmed", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled",
         "AccessFailedCount" },
     values: new object[] {
        Guid.NewGuid().ToString(),
        1,
        "Admin",
        "Admin",
        "123456789",
        "1990-01-01",
        0,
        0,
        "Admin",
        "admin@email.com",
        false,        
        false,
        false,
        false,
        0
     });

        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
