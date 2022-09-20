using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurryFriends.Data.Migrations
{
    public partial class DbUpdate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_OwnerId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_User_OwnerId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Reply_Comment_CommentId",
                table: "Reply");

            migrationBuilder.DropIndex(
                name: "IX_Reply_CommentId",
                table: "Reply");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_OwnerId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Post_OwnerId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Comment_PostId",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "RelatedPostId",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_RelatedPostId",
                table: "Comment",
                column: "RelatedPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_RelatedPostId",
                table: "Comment",
                column: "RelatedPostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_RelatedPostId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_RelatedPostId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "RelatedPostId",
                table: "Comment");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_CommentId",
                table: "Reply",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_OwnerId",
                table: "Profiles",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_OwnerId",
                table: "Post",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_PostId",
                table: "Comment",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_OwnerId",
                table: "Post",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_User_OwnerId",
                table: "Profiles",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_Comment_CommentId",
                table: "Reply",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
