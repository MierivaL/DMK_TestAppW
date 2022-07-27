using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMK_TestAppW.Migrations
{
    public partial class ManyToManyDirect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookUser_Books_BooksBookId",
                table: "BookUser");

            migrationBuilder.DropForeignKey(
                name: "FK_BookUser_Users_UsersUserId",
                table: "BookUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookUser",
                table: "BookUser");

            migrationBuilder.RenameTable(
                name: "BookUser",
                newName: "UserBooks");

            migrationBuilder.RenameIndex(
                name: "IX_BookUser_UsersUserId",
                table: "UserBooks",
                newName: "IX_UserBooks_UsersUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBooks",
                table: "UserBooks",
                columns: new[] { "BooksBookId", "UsersUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserBooks_Books_BooksBookId",
                table: "UserBooks",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBooks_Users_UsersUserId",
                table: "UserBooks",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBooks_Books_BooksBookId",
                table: "UserBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBooks_Users_UsersUserId",
                table: "UserBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBooks",
                table: "UserBooks");

            migrationBuilder.RenameTable(
                name: "UserBooks",
                newName: "BookUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserBooks_UsersUserId",
                table: "BookUser",
                newName: "IX_BookUser_UsersUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookUser",
                table: "BookUser",
                columns: new[] { "BooksBookId", "UsersUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookUser_Books_BooksBookId",
                table: "BookUser",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookUser_Users_UsersUserId",
                table: "BookUser",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
