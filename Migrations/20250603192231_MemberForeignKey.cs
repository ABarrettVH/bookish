using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bookish.Migrations
{
    /// <inheritdoc />
    public partial class MemberForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_BookOuts_MemberID",
                table: "BookOuts",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookOuts_Members_MemberID",
                table: "BookOuts",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookOuts_Members_MemberID",
                table: "BookOuts");

            migrationBuilder.DropIndex(
                name: "IX_BookOuts_MemberID",
                table: "BookOuts");

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
    }
}
