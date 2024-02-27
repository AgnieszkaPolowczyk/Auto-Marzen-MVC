using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mileage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details_BodyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details_Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details_NumberOfDoors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details_NumberofSeats = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details_FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details_Transmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details_Power = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details_ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details_Vin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
