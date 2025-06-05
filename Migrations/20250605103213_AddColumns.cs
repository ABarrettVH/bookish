using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookish.Migrations
{
    /// <inheritdoc />
    public partial class AddColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Members_MemberID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_MemberID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberID",
                table: "Books",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_MemberID",
                table: "Books",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Members_MemberID",
                table: "Books",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberID");
        }
    }
}
