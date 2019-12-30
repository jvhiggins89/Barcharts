using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workout495.Migrations
{
    public partial class seedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight" },
                values: new object[] { 21, 2, 51f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 36, 6, 6, 85f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 95, 11, 2, 37f });

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
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 29.0, new DateTime(2019, 12, 8, 16, 17, 54, 853, DateTimeKind.Local).AddTicks(1692), new DateTime(2019, 12, 8, 16, 17, 54, 853, DateTimeKind.Local).AddTicks(1699), 105.0 });

            migrationBuilder.UpdateData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 20.0, new DateTime(2019, 12, 8, 16, 17, 54, 853, DateTimeKind.Local).AddTicks(3239), new DateTime(2019, 12, 8, 16, 17, 54, 853, DateTimeKind.Local).AddTicks(3250), 129.0 });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "Active", "Name", "ScheduledDate", "UserId" },
                values: new object[] { 3, true, "Workout 3", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight" },
                values: new object[] { 76, 1, 19f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 15, 10, 3, 36f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 100, 7, 6, 43f });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 10.0, new DateTime(2019, 12, 8, 16, 14, 30, 556, DateTimeKind.Local).AddTicks(1502), new DateTime(2019, 12, 8, 16, 14, 30, 559, DateTimeKind.Local).AddTicks(9451), 101.0 });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 22.0, new DateTime(2019, 12, 8, 16, 14, 30, 560, DateTimeKind.Local).AddTicks(409), new DateTime(2019, 12, 8, 16, 14, 30, 560, DateTimeKind.Local).AddTicks(432), 114.0 });

            migrationBuilder.UpdateData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 26.0, new DateTime(2019, 12, 8, 16, 14, 30, 560, DateTimeKind.Local).AddTicks(1111), new DateTime(2019, 12, 8, 16, 14, 30, 560, DateTimeKind.Local).AddTicks(1118), 156.0 });

            migrationBuilder.UpdateData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 18.0, new DateTime(2019, 12, 8, 16, 14, 30, 560, DateTimeKind.Local).AddTicks(2653), new DateTime(2019, 12, 8, 16, 14, 30, 560, DateTimeKind.Local).AddTicks(2665), 178.0 });
        }
    }
}
