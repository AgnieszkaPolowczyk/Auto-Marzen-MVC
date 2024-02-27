using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Index",
                table: "Cars",
                newName: "Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Cars",
                newName: "Index");
        }
    }
}
