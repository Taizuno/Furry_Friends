using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurryFriends.Data.Migrations
{
    public partial class DbUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Profiles_OwnerId",
                table: "Profiles",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_User_OwnerId",
                table: "Profiles",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_User_OwnerId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_OwnerId",
                table: "Profiles");
        }
    }
}
