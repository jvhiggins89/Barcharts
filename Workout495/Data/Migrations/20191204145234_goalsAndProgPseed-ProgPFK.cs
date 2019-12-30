using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workout495.Migrations
{
    public partial class goalsAndProgPseedProgPFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalsId",
                table: "ProgressPoints",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 12, 9, 6, 56f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 64, 6, 6, 39f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight" },
                values: new object[] { 74, 1, 63f });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "Id", "BMI", "Changed", "Created", "Description", "GoalDate", "Title", "UserId", "Weight" },
                values: new object[,]
                {
                    { 1, 23.0, new DateTime(2019, 12, 4, 9, 52, 33, 831, DateTimeKind.Local).AddTicks(8480), new DateTime(2019, 12, 4, 9, 52, 33, 834, DateTimeKind.Local).AddTicks(6410), "Goal 1 Description.", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Goal 1", null, 100.0 },
                    { 2, 18.0, new DateTime(2019, 12, 4, 9, 52, 33, 834, DateTimeKind.Local).AddTicks(7308), new DateTime(2019, 12, 4, 9, 52, 33, 834, DateTimeKind.Local).AddTicks(7329), "ProgressPoint 2 Description.", new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProgressPoint 2", null, 210.0 }
                });

            migrationBuilder.InsertData(
                table: "ProgressPoints",
                columns: new[] { "Id", "BMI", "Changed", "Created", "Description", "GoalsId", "ProgressPointDate", "Title", "UserId", "Weight" },
                values: new object[,]
                {
                    { 1, 28.0, new DateTime(2019, 12, 4, 9, 52, 33, 835, DateTimeKind.Local).AddTicks(1455), new DateTime(2019, 12, 4, 9, 52, 33, 835, DateTimeKind.Local).AddTicks(2013), "ProgressPoint 1 Description.", null, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProgressPoint 1", null, 108.0 },
                    { 2, 16.0, new DateTime(2019, 12, 4, 9, 52, 33, 835, DateTimeKind.Local).AddTicks(2631), new DateTime(2019, 12, 4, 9, 52, 33, 835, DateTimeKind.Local).AddTicks(2648), "Goal 2 Description.", null, new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Goal 2", null, 245.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgressPoints_GoalsId",
                table: "ProgressPoints",
                column: "GoalsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressPoints_Goals_GoalsId",
                table: "ProgressPoints",
                column: "GoalsId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgressPoints_Goals_GoalsId",
                table: "ProgressPoints");

            migrationBuilder.DropIndex(
                name: "IX_ProgressPoints_GoalsId",
                table: "ProgressPoints");

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "GoalsId",
                table: "ProgressPoints");

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 89, 8, 5, 5f });

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
                columns: new[] { "NumberOfCompletions", "Reps", "Weight" },
                values: new object[] { 14, 7, 14f });
        }
    }
}
