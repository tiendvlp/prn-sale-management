using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.MSSQL_Intergration.Migrations
{
    public partial class editproducttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
