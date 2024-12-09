using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mesta.CompetenceManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valg",
                table: "Competencies");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Competencies",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Competencies");

            migrationBuilder.AddColumn<string>(
                name: "Valg",
                table: "Competencies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
