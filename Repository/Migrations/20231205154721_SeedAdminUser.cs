using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "CompletedBookings", "CouponsUsed","UserName", "NormalizedUserName", "Email", "NormalizedEmail" ,
                    "EmailConfirmed", "PhoneNumberConfirmed" ,"TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount","Gender", "DateOfBirth","FirstName","LastName" ,"Phone" },
                values: new object[] { Guid.NewGuid().ToString(), 0, 0,"admin" , "Admin".ToUpper(), "Admin@gmail.com","Admin@gmail.com".ToUpper()
                ,false, false, false,false,0,0,"30/7/1999","admin","admin", "0101212421"
                });


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
