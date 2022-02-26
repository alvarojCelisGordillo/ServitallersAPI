using Microsoft.EntityFrameworkCore.Migrations;

namespace ServitallersAPI.Migrations
{
    public partial class uppdateVehicleBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Placa",
                table: "VehicleBrands");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "VehicleBrands",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
