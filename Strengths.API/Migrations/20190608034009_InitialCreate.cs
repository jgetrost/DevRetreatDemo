using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Strengths.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Domain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Title = table.Column<string>(nullable: false),
                    DomainId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Theme_Domain_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Theme1Id = table.Column<int>(nullable: true),
                    Theme2Id = table.Column<int>(nullable: true),
                    Theme3Id = table.Column<int>(nullable: true),
                    Theme4Id = table.Column<int>(nullable: true),
                    Theme5Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Theme_Theme1Id",
                        column: x => x.Theme1Id,
                        principalTable: "Theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Theme_Theme2Id",
                        column: x => x.Theme2Id,
                        principalTable: "Theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Theme_Theme3Id",
                        column: x => x.Theme3Id,
                        principalTable: "Theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Theme_Theme4Id",
                        column: x => x.Theme4Id,
                        principalTable: "Theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Theme_Theme5Id",
                        column: x => x.Theme5Id,
                        principalTable: "Theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Theme_DomainId",
                table: "Theme",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Theme1Id",
                table: "User",
                column: "Theme1Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Theme2Id",
                table: "User",
                column: "Theme2Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Theme3Id",
                table: "User",
                column: "Theme3Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Theme4Id",
                table: "User",
                column: "Theme4Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Theme5Id",
                table: "User",
                column: "Theme5Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Theme");

            migrationBuilder.DropTable(
                name: "Domain");
        }
    }
}
