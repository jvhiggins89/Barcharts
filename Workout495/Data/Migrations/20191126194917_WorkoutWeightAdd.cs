using Microsoft.EntityFrameworkCore.Migrations;

namespace Workout495.Migrations
{
    public partial class WorkoutWeightAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Workout",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Workout");
        }
    }
}
