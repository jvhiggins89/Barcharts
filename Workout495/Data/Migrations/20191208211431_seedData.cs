using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workout495.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 76, 1, 1, 19f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight" },
                values: new object[] { 15, 10, 36f });

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

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "Id", "Active", "Name", "ScheduledDate", "UserId" },
                values: new object[,]
                {
                    { 1, true, "Workout 1", null, null },
                    { 2, true, "Workout 2", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "ScheduledDate",
                table: "Workout");

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 88, 5, 5, 73f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight" },
                values: new object[] { 16, 12, 71f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 53, 5, 1, 18f });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 12.0, new DateTime(2019, 12, 4, 11, 37, 56, 235, DateTimeKind.Local).AddTicks(7478), new DateTime(2019, 12, 4, 11, 37, 56, 238, DateTimeKind.Local).AddTicks(6286), 110.0 });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 11.0, new DateTime(2019, 12, 4, 11, 37, 56, 238, DateTimeKind.Local).AddTicks(7192), new DateTime(2019, 12, 4, 11, 37, 56, 238, DateTimeKind.Local).AddTicks(7212), 226.0 });

            migrationBuilder.UpdateData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 13.0, new DateTime(2019, 12, 4, 11, 37, 56, 238, DateTimeKind.Local).AddTicks(7774), new DateTime(2019, 12, 4, 11, 37, 56, 238, DateTimeKind.Local).AddTicks(7781), 182.0 });

            migrationBuilder.UpdateData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 10.0, new DateTime(2019, 12, 4, 11, 37, 56, 238, DateTimeKind.Local).AddTicks(9768), new DateTime(2019, 12, 4, 11, 37, 56, 238, DateTimeKind.Local).AddTicks(9780), 206.0 });
        }
    }
}
