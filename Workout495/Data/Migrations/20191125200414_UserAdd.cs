using Microsoft.EntityFrameworkCore.Migrations;

namespace Workout495.Migrations
{
    public partial class UserAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Workout",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Exercise",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workout_UserId",
                table: "Workout",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_UserId",
                table: "Exercise",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_AspNetUsers_UserId",
                table: "Exercise",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_AspNetUsers_UserId",
                table: "Workout",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_AspNetUsers_UserId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Workout_AspNetUsers_UserId",
                table: "Workout");

            migrationBuilder.DropIndex(
                name: "IX_Workout_UserId",
                table: "Workout");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_UserId",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Exercise");
        }
    }
}
