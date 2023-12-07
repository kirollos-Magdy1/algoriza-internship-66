using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCouponDoctorPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "Coupons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_PatientId",
                table: "Coupons",
                column: "PatientId");


            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_AspNetUsers_PatientId",
                table: "Coupons",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_AspNetUsers_PatientId",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_Coupons_PatientId",
                table: "Coupons");


            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Coupons");

        }
    }
}
