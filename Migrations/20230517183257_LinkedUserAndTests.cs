using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeachersPet.Migrations
{
    /// <inheritdoc />
    public partial class LinkedUserAndTests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tests",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_UserId",
                table: "Tests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Users_UserId",
                table: "Tests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Users_UserId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_UserId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tests");
        }
    }
}
