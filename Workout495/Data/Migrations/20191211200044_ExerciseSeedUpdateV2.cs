using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workout495.Migrations
{
    public partial class ExerciseSeedUpdateV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 65, 9, 2, 20f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 49, 6, 1, 11f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumberOfCompletions", "Sets", "Weight" },
                values: new object[] { 40, 4, 53f });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Name", "NumberOfCompletions", "Reps", "Sets", "UserId", "Weight", "WorkoutId" },
                values: new object[,]
                {
                    { 12, "Workout 12", 53, 4, 4, null, 79f, 2 },
                    { 11, "Workout 11", 83, 2, 5, null, 31f, 2 },
                    { 10, "Workout 10", 73, 10, 2, null, 3f, 2 },
                    { 13, "Workout 13", 31, 10, 4, null, 54f, 2 },
                    { 8, "Workout 8", 3, 11, 6, null, 38f, 2 },
                    { 7, "Workout 7", 72, 3, 3, null, 3f, 2 },
                    { 6, "Workout 6", 82, 6, 3, null, 28f, 2 },
                    { 5, "Workout 5", 77, 8, 1, null, 98f, 2 },
                    { 9, "Workout 9", 21, 1, 4, null, 85f, 2 },
                    { 4, "Workout 4", 17, 5, 5, null, 79f, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 25.0, new DateTime(2019, 12, 11, 21, 0, 43, 883, DateTimeKind.Local).AddTicks(131), new DateTime(2019, 12, 11, 21, 0, 43, 883, DateTimeKind.Local).AddTicks(613), 129.0 });

            migrationBuilder.UpdateData(
                table: "Goals",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 12.0, new DateTime(2019, 12, 11, 21, 0, 43, 883, DateTimeKind.Local).AddTicks(1108), new DateTime(2019, 12, 11, 21, 0, 43, 883, DateTimeKind.Local).AddTicks(1123), 175.0 });

            migrationBuilder.UpdateData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 28.0, new DateTime(2019, 12, 11, 21, 0, 43, 883, DateTimeKind.Local).AddTicks(3793), new DateTime(2019, 12, 11, 21, 0, 43, 883, DateTimeKind.Local).AddTicks(4187), 149.0 });

            migrationBuilder.UpdateData(
                table: "ProgressPoints",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BMI", "Changed", "Created", "Weight" },
                values: new object[] { 14.0, new DateTime(2019, 12, 11, 21, 0, 43, 883, DateTimeKind.Local).AddTicks(4619), new DateTime(2019, 12, 11, 21, 0, 43, 883, DateTimeKind.Local).AddTicks(4633), 172.0 });

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: 1,
                column: "ScheduledDate",
                value: new DateTime(2019, 12, 12, 21, 0, 43, 878, DateTimeKind.Local).AddTicks(329));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: 2,
                column: "ScheduledDate",
                value: new DateTime(2019, 12, 13, 21, 0, 43, 881, DateTimeKind.Local).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "Id",
                keyValue: 3,
                column: "ScheduledDate",
                value: new DateTime(2019, 12, 14, 21, 0, 43, 881, DateTimeKind.Local).AddTicks(5266));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 13);

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
                columns: new[] { "NumberOfCompletions", "Reps", "Sets", "Weight" },
                values: new object[] { 12, 10, 6, 51f });

            migrationBuilder.UpdateData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NumberOfCompletions", "Sets", "Weight" },
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
    }
}
