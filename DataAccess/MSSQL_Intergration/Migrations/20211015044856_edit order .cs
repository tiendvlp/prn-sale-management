using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.MSSQL_Intergration.Migrations
{
    public partial class editorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MemberId",
                table: "Orders",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Members_MemberId",
                table: "Orders",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Members_MemberId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MemberId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "MemberId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
