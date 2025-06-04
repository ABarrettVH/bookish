using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bookish.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookOuts",
                columns: table => new
                {
                    BookOutID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberID = table.Column<int>(type: "integer", nullable: false),
                    BookID = table.Column<int>(type: "integer", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookOuts", x => x.BookOutID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    Copies = table.Column<int>(type: "integer", nullable: false),
                    AvailableCopies = table.Column<int>(type: "integer", nullable: false),
                    BookOutID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Books_BookOuts_BookOutID",
                        column: x => x.BookOutID,
                        principalTable: "BookOuts",
                        principalColumn: "BookOutID");
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    BookOutID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Members_BookOuts_BookOutID",
                        column: x => x.BookOutID,
                        principalTable: "BookOuts",
                        principalColumn: "BookOutID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookOutID",
                table: "Books",
                column: "BookOutID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_BookOutID",
                table: "Members",
                column: "BookOutID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "BookOuts");
        }
    }
}
