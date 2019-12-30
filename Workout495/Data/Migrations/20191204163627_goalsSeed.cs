using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workout495.Migrations
{
    public partial class goalsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 23, 12, 2, 44f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight" },
                values: new object[] { 25, 2, 20f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight" },
                values: new object[] { 16, 5, 9f });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 17.0, new DateTime(2019, 12, 4, 11, 36, 26, 495, DateTimeKind.Local).AddTicks(6293), new DateTime(2019, 12, 4, 11, 36, 26, 498, DateTimeKind.Local).AddTicks(7277), 197.0 });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BMI", "Changed", "Created", "Description", "Title", "Weight" },
                values: new object[] { 11.0, new DateTime(2019, 12, 4, 11, 36, 26, 498, DateTimeKind.Local).AddTicks(8287), new DateTime(2019, 12, 4, 11, 36, 26, 498, DateTimeKind.Local).AddTicks(8311), "Goal 2 Description.", "Goal 2", 193.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "NumberOfCompletions", "Reps", "Weight" },
                values: new object[] { 64, 6, 39f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight" },
                values: new object[] { 74, 1, 63f });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 23.0, new DateTime(2019, 12, 4, 9, 52, 33, 831, DateTimeKind.Local).AddTicks(8480), new DateTime(2019, 12, 4, 9, 52, 33, 834, DateTimeKind.Local).AddTicks(6410), 100.0 });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BMI", "Changed", "Created", "Description", "Title", "Weight" },
                values: new object[] { 18.0, new DateTime(2019, 12, 4, 9, 52, 33, 834, DateTimeKind.Local).AddTicks(7308), new DateTime(2019, 12, 4, 9, 52, 33, 834, DateTimeKind.Local).AddTicks(7329), "ProgressPoint 2 Description.", "ProgressPoint 2", 210.0 });

            migrationBuilder.InsertData(
                table: "ProgressPoints",
                columns: new[] { "Id", "BMI", "Changed", "Created", "Description", "GoalsId", "ProgressPointDate", "Title", "UserId", "Weight" },
                values: new object[,]
                {
                    { 1, 28.0, new DateTime(2019, 12, 4, 9, 52, 33, 835, DateTimeKind.Local).AddTicks(1455), new DateTime(2019, 12, 4, 9, 52, 33, 835, DateTimeKind.Local).AddTicks(2013), "ProgressPoint 1 Description.", null, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProgressPoint 1", null, 108.0 },
                    { 2, 16.0, new DateTime(2019, 12, 4, 9, 52, 33, 835, DateTimeKind.Local).AddTicks(2631), new DateTime(2019, 12, 4, 9, 52, 33, 835, DateTimeKind.Local).AddTicks(2648), "Goal 2 Description.", null, new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Goal 2", null, 245.0 }
                });
        }
    }
}
