using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachersPet.Migrations
{
    /// <inheritdoc />
    public partial class AddedGeneratorSettings3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneratorSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    Topic = table.Column<string>(type: "TEXT", nullable: false),
                    Grade = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfQuestions = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfAnswers = table.Column<int>(type: "INTEGER", nullable: false),
                    PercentageOfDifficulty = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratorSettings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneratorSettings");
        }
    }
}
