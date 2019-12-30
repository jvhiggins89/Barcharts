using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workout495.Migrations
{
    public partial class goalsSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 16, 12, 3, 71f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumberOfCompletions", "Sets", "Weight" },
                values: new object[] { 53, 1, 18f });

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
                columns: new[] { "Changed", "Created", "Weight" },
                values: new object[] { new DateTime(2019, 12, 4, 11, 37, 56, 238, DateTimeKind.Local).AddTicks(7192), new DateTime(2019, 12, 4, 11, 37, 56, 238, DateTimeKind.Local).AddTicks(7212), 226.0 });

            migrationBuilder.InsertData(
                table: "ProgressPoints",
                columns: new[] { "Id", "BMI", "Changed", "Created", "Description", "GoalsId", "ProgressPointDate", "Title", "UserId", "Weight" },
                values: new object[,]
                {
                    { 1, 13.0, new DateTime(2019, 12, 4, 11, 37, 56, 238, DateTimeKind.Local).AddTicks(7774), new DateTime(2019, 12, 4, 11, 37, 56, 238, DateTimeKind.Local).AddTicks(7781), "ProgressPoint 1 Description.", 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProgressPoint 1", null, 182.0 },
                    { 2, 10.0, new DateTime(2019, 12, 4, 11, 37, 56, 238, DateTimeKind.Local).AddTicks(9768), new DateTime(2019, 12, 4, 11, 37, 56, 238, DateTimeKind.Local).AddTicks(9780), "ProgressPoint 2 Description.", null, new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProgressPoint 2", null, 206.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 25, 2, 6, 20f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumberOfCompletions", "Sets", "Weight" },
                values: new object[] { 16, 4, 9f });

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
                columns: new[] { "Changed", "Created", "Weight" },
                values: new object[] { new DateTime(2019, 12, 4, 11, 36, 26, 498, DateTimeKind.Local).AddTicks(8287), new DateTime(2019, 12, 4, 11, 36, 26, 498, DateTimeKind.Local).AddTicks(8311), 193.0 });
        }
    }
}
