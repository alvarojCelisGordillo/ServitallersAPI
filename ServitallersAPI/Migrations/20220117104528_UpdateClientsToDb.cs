using Microsoft.EntityFrameworkCore.Migrations;

namespace ServitallersAPI.Migrations
{
    public partial class UpdateClientsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelefoneNumber",
                table: "Clients",
                newName: "TelephoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelephoneNumber",
                table: "Clients",
                newName: "TelefoneNumber");
        }
    }
}
