using Microsoft.EntityFrameworkCore.Migrations;

namespace Workout495.Migrations
{
    public partial class andrewgoalsprogressps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Goals_GoalsId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ProgressPoints_ProgressPointsId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GoalsId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProgressPointsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GoalsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProgressPointsId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ProgressPoints",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Goals",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight" },
                values: new object[] { 89, 8, 5f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 26, 11, 3, 86f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 14, 7, 4, 14f });

            migrationBuilder.CreateIndex(
                name: "IX_ProgressPoints_UserId",
                table: "ProgressPoints",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_UserId",
                table: "Goals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_AspNetUsers_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressPoints_AspNetUsers_UserId",
                table: "ProgressPoints",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_AspNetUsers_UserId",
                table: "Goals");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgressPoints_AspNetUsers_UserId",
                table: "ProgressPoints");

            migrationBuilder.DropIndex(
                name: "IX_ProgressPoints_UserId",
                table: "ProgressPoints");

            migrationBuilder.DropIndex(
                name: "IX_Goals_UserId",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProgressPoints");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Goals");

            migrationBuilder.AddColumn<int>(
                name: "GoalsId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProgressPointsId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight" },
                values: new object[] { 8, 11, 31f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 80, 9, 5, 99f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 64, 9, 2, 71f });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GoalsId",
                table: "AspNetUsers",
                column: "GoalsId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProgressPointsId",
                table: "AspNetUsers",
                column: "ProgressPointsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Goals_GoalsId",
                table: "AspNetUsers",
                column: "GoalsId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ProgressPoints_ProgressPointsId",
                table: "AspNetUsers",
                column: "ProgressPointsId",
                principalTable: "ProgressPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
