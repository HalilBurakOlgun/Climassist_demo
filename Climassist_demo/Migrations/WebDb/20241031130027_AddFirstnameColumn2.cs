using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Climassist_demo.Migrations.WebDb
{
    /// <inheritdoc />
    public partial class AddFirstnameColumn2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Requests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
