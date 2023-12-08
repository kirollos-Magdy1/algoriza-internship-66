using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class SeedSpecializations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Specializations",
               columns: new[] { "Name" },
               values: new object[] { "Psychology" });

            migrationBuilder.InsertData(
               table: "Specializations",
               columns: new[] { "Name" },
               values: new object[] { "Cardiology" });

            migrationBuilder.InsertData(
               table: "Specializations",
               columns: new[] { "Name" },
               values: new object[] { "Dermatology" });

            migrationBuilder.InsertData(
               table: "Specializations",
               columns: new[] { "Name" },
               values: new object[] { "Orthopedics" });

            migrationBuilder.InsertData(
               table: "Specializations",
               columns: new[] { "Name" },
               values: new object[] { "Neurology" });

            migrationBuilder.InsertData(
               table: "Specializations",
               columns: new[] { "Name" },
               values: new object[] { "Oncology" });

            migrationBuilder.InsertData(
               table: "Specializations",
               columns: new[] { "Name" },
               values: new object[] { "Gastroenterology" });

            migrationBuilder.InsertData(
               table: "Specializations",
               columns: new[] { "Name" },
               values: new object[] { "Ophthalmology" });

            migrationBuilder.InsertData(
               table: "Specializations",
               columns: new[] { "Name" },
               values: new object[] { "Urology" });

            migrationBuilder.InsertData(
               table: "Specializations",
               columns: new[] { "Name" },
               values: new object[] { "Endocrinology" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
