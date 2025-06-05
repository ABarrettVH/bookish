using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookish.Migrations
{
    /// <inheritdoc />
    public partial class AddColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookOuts_Members_MemberID",
                table: "BookOuts");

            migrationBuilder.DropIndex(
                name: "IX_BookOuts_MemberID",
                table: "BookOuts");

            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "BookOuts");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "BookOuts",
                newName: "MemberID");

            migrationBuilder.AddColumn<int>(
                name: "MemberID",
                table: "Books",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "BookOuts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Books_MemberID",
                table: "Books",
                column: "MemberID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Members_MemberID",
                table: "Books",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookOuts_Members_MemberID",
                table: "BookOuts");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Members_MemberID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_MemberID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_BookOuts_MemberID",
                table: "BookOuts");

            migrationBuilder.DropColumn(
                name: "MemberID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "BookOuts");

            migrationBuilder.RenameColumn(
                name: "MemberID",
                table: "BookOuts",
                newName: "MemberId");

            migrationBuilder.AddColumn<int>(
                name: "MemberID",
                table: "BookOuts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
    }
}
