using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CreatedById",
                table: "Cars",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_CreatedById",
                table: "Cars",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_CreatedById",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CreatedById",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Cars");
        }
    }
}
