using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workout495.Migrations
{
    public partial class workoutupdateseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 43, 12, 1, 55f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight" },
                values: new object[] { 12, 10, 51f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight" },
                values: new object[] { 19, 2, 69f });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 21.0, new DateTime(2019, 12, 11, 19, 20, 38, 664, DateTimeKind.Local).AddTicks(8945), new DateTime(2019, 12, 11, 19, 20, 38, 664, DateTimeKind.Local).AddTicks(9415), 155.0 });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 22.0, new DateTime(2019, 12, 11, 19, 20, 38, 664, DateTimeKind.Local).AddTicks(9924), new DateTime(2019, 12, 11, 19, 20, 38, 664, DateTimeKind.Local).AddTicks(9938), 221.0 });

            migrationBuilder.UpdateData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 25.0, new DateTime(2019, 12, 11, 19, 20, 38, 665, DateTimeKind.Local).AddTicks(2606), new DateTime(2019, 12, 11, 19, 20, 38, 665, DateTimeKind.Local).AddTicks(2989), 122.0 });

            migrationBuilder.UpdateData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 25.0, new DateTime(2019, 12, 11, 19, 20, 38, 665, DateTimeKind.Local).AddTicks(3412), new DateTime(2019, 12, 11, 19, 20, 38, 665, DateTimeKind.Local).AddTicks(3427), 237.0 });

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: 1,
                column: "ScheduledDate",
                value: new DateTime(2019, 12, 12, 19, 20, 38, 662, DateTimeKind.Local).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: 2,
                column: "ScheduledDate",
                value: new DateTime(2019, 12, 13, 19, 20, 38, 662, DateTimeKind.Local).AddTicks(4270));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: 3,
                column: "ScheduledDate",
                value: new DateTime(2019, 12, 14, 19, 20, 38, 662, DateTimeKind.Local).AddTicks(4289));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 27, 5, 5, 31f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight" },
                values: new object[] { 14, 5, 58f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumberOfCompletions", "Reps", "Weight" },
                values: new object[] { 2, 4, 72f });

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
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 21.0, new DateTime(2019, 12, 8, 16, 31, 35, 906, DateTimeKind.Local).AddTicks(4504), new DateTime(2019, 12, 8, 16, 31, 35, 906, DateTimeKind.Local).AddTicks(5158), 205.0 });

            migrationBuilder.UpdateData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 24.0, new DateTime(2019, 12, 8, 16, 31, 35, 906, DateTimeKind.Local).AddTicks(5981), new DateTime(2019, 12, 8, 16, 31, 35, 906, DateTimeKind.Local).AddTicks(6009), 208.0 });

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: 1,
                column: "ScheduledDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: 2,
                column: "ScheduledDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: 3,
                column: "ScheduledDate",
                value: null);
        }
    }
}
