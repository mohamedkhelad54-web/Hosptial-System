using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hosptial_System.Migrations
{
    /// <inheritdoc />
    public partial class add_columb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "doctors");
        }
    }
}
