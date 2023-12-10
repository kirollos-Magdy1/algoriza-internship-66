using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AssignAdminUserToRoleAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Existing migration code...

            migrationBuilder.Sql(@"
        INSERT INTO AspNetUserRoles (UserId, RoleId)
        VALUES (
            'cd26262c-930b-4277-a413-0f3aef713859',
            'e92dfc57-13fc-4b4b-abf5-c2492169eb47'
        )
    ");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
