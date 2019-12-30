using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workout495.Migrations
{
    public partial class seeddata3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight", "WorkoutId" },
                values: new object[] { 27, 5, 5, 31f, 1 });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight", "WorkoutId" },
                values: new object[] { 14, 5, 58f, 2 });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight", "WorkoutId" },
                values: new object[] { 2, 4, 72f, 2 });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 26.0, new DateTime(2019, 12, 8, 16, 31, 35, 902, DateTimeKind.Local).AddTicks(132), new DateTime(2019, 12, 8, 16, 31, 35, 905, DateTimeKind.Local).AddTicks(8633), 200.0 });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 17.0, new DateTime(2019, 12, 8, 16, 31, 35, 905, DateTimeKind.Local).AddTicks(9637), new DateTime(2019, 12, 8, 16, 31, 35, 905, DateTimeKind.Local).AddTicks(9658), 240.0 });

            migrationBuilder.UpdateData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BMI", "Changed", "Created", "GoalsId", "Weight" },
                values: new object[] { 21.0, new DateTime(2019, 12, 8, 16, 31, 35, 906, DateTimeKind.Local).AddTicks(4504), new DateTime(2019, 12, 8, 16, 31, 35, 906, DateTimeKind.Local).AddTicks(5158), null, 205.0 });

            migrationBuilder.UpdateData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 24.0, new DateTime(2019, 12, 8, 16, 31, 35, 906, DateTimeKind.Local).AddTicks(5981), new DateTime(2019, 12, 8, 16, 31, 35, 906, DateTimeKind.Local).AddTicks(6009), 208.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight", "WorkoutId" },
                values: new object[] { 21, 2, 1, 51f, null });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight", "WorkoutId" },
                values: new object[] { 36, 6, 85f, null });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight", "WorkoutId" },
                values: new object[] { 95, 11, 37f, null });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 25.0, new DateTime(2019, 12, 8, 16, 17, 54, 850, DateTimeKind.Local).AddTicks(3312), new DateTime(2019, 12, 8, 16, 17, 54, 852, DateTimeKind.Local).AddTicks(9844), 237.0 });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 16.0, new DateTime(2019, 12, 8, 16, 17, 54, 853, DateTimeKind.Local).AddTicks(1040), new DateTime(2019, 12, 8, 16, 17, 54, 853, DateTimeKind.Local).AddTicks(1063), 246.0 });

            migrationBuilder.UpdateData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BMI", "Changed", "Created", "GoalsId", "Weight" },
                values: new object[] { 29.0, new DateTime(2019, 12, 8, 16, 17, 54, 853, DateTimeKind.Local).AddTicks(1692), new DateTime(2019, 12, 8, 16, 17, 54, 853, DateTimeKind.Local).AddTicks(1699), 1, 105.0 });

            migrationBuilder.UpdateData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 20.0, new DateTime(2019, 12, 8, 16, 17, 54, 853, DateTimeKind.Local).AddTicks(3239), new DateTime(2019, 12, 8, 16, 17, 54, 853, DateTimeKind.Local).AddTicks(3250), 129.0 });
        }
    }
}
