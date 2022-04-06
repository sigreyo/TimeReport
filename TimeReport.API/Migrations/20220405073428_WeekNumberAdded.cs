using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeReport.API.Migrations
{
    public partial class WeekNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeekNumber",
                table: "TimeReports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeekNumber",
                table: "TimeReports");
        }
    }
}
