using Microsoft.EntityFrameworkCore.Migrations;

namespace Strengths.API.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Domain",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Strategic Thinking" },
                    { 2, "Executing" },
                    { 3, "Influencing" },
                    { 4, "Relationship Building" }
                });

            migrationBuilder.InsertData(
                table: "Theme",
                columns: new[] { "Id", "DomainId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Analytical" },
                    { 32, 4, "Individualization" },
                    { 31, 4, "Includer" },
                    { 30, 4, "Harmony" },
                    { 29, 4, "Empathy" },
                    { 28, 4, "Developer" },
                    { 27, 4, "Connectedness" },
                    { 26, 4, "Adaptability" },
                    { 25, 3, "Woo" },
                    { 24, 3, "Significance" },
                    { 23, 3, "Self-Assurance" },
                    { 22, 3, "Maximizer" },
                    { 21, 3, "Competition" },
                    { 20, 3, "Communication" },
                    { 19, 3, "Command" },
                    { 18, 3, "Activator" },
                    { 17, 2, "Restorative" },
                    { 16, 2, "Responsibility" },
                    { 2, 1, "Context" },
                    { 3, 1, "Futuristic" },
                    { 4, 1, "Ideation" },
                    { 5, 1, "Input" },
                    { 6, 1, "Intellection" },
                    { 7, 1, "Learner" },
                    { 33, 4, "Positivity" },
                    { 8, 1, "Strategic" },
                    { 10, 2, "Arranger" },
                    { 11, 2, "Belief" },
                    { 12, 2, "Consistency" },
                    { 13, 2, "Deliberative" },
                    { 14, 2, "Discipline" },
                    { 15, 2, "Focus" },
                    { 9, 2, "Achiever" },
                    { 34, 4, "Relator" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "LastName", "Theme1Id", "Theme2Id", "Theme3Id", "Theme4Id", "Theme5Id" },
                values: new object[] { 1, "James", "Getrost", 1, 2, 34, 21, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Domain",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Domain",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Domain",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Domain",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
