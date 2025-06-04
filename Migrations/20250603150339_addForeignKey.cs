using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bookish.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookOuts_BookOutID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_BookOuts_BookOutID",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_BookOutID",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookOutID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookOutID",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "BookOutID",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "MemberID",
                table: "Members",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_BookOuts_MemberID",
                table: "Members",
                column: "MemberID",
                principalTable: "BookOuts",
                principalColumn: "BookOutID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_BookOuts_MemberID",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "MemberID",
                table: "Members",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "BookOutID",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookOutID",
                table: "Books",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_BookOutID",
                table: "Members",
                column: "BookOutID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookOutID",
                table: "Books",
                column: "BookOutID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookOuts_BookOutID",
                table: "Books",
                column: "BookOutID",
                principalTable: "BookOuts",
                principalColumn: "BookOutID");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_BookOuts_BookOutID",
                table: "Members",
                column: "BookOutID",
                principalTable: "BookOuts",
                principalColumn: "BookOutID");
        }
    }
}
