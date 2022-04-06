using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeReport.API.Migrations
{
    public partial class RemovePropInTimeRep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "TimeReports");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "TimeReports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
