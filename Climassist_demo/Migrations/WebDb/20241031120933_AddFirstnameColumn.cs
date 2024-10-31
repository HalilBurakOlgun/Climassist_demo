using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Climassist_demo.Migrations.WebDb
{
    /// <inheritdoc />
    public partial class AddFirstnameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Requests");
        }
    }
}
