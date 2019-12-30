using Microsoft.EntityFrameworkCore.Migrations;

namespace Workout495.Migrations
{
    public partial class ExerciseSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Workout_WorkoutId",
                table: "Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Exercise");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "Exercise",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Exercise",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Exercise",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Name", "NumberOfCompletions", "Reps", "Sets", "UserId", "Weight", "WorkoutId" },
                values: new object[] { 1, "Air Squat of Death", 8, 11, 5, null, 31f, null });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Name", "NumberOfCompletions", "Reps", "Sets", "UserId", "Weight", "WorkoutId" },
                values: new object[] { 2, "Incline Dumbell Press With Swim Fins on", 80, 9, 5, null, 99f, null });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Name", "NumberOfCompletions", "Reps", "Sets", "UserId", "Weight", "WorkoutId" },
                values: new object[] { 3, "Super Set for Super Abs", 64, 9, 2, null, 71f, null });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Workout_WorkoutId",
                table: "Exercise",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Workout_WorkoutId",
                table: "Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Exercise");

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Workout",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "Exercise",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Exercise",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Workout_WorkoutId",
                table: "Exercise",
                column: "WorkoutId",
                principalTable: "Workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
