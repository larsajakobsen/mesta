using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mesta.CompetenceManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddCompetence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Valg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Projects = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Program = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Issuer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsible = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    SendEmailOnExpiring = table.Column<bool>(type: "bit", nullable: false),
                    IncludeInCV = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competencies");
        }
    }
}
