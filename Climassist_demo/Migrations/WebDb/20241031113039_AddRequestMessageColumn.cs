using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Climassist_demo.Migrations.WebDb
{
    /// <inheritdoc />
    public partial class AddRequestMessageColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Requests");
        }
    }
}
