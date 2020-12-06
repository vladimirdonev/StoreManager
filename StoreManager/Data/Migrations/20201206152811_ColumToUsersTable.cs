using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreManager.Data.Migrations
{
    public partial class ColumToUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersStores",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsersStores_UserId",
                table: "UsersStores",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersStores_UserId",
                table: "UsersStores");

            migrationBuilder.DropColumn(
                name: "UsersStores",
                table: "AspNetUsers");
        }
    }
}
