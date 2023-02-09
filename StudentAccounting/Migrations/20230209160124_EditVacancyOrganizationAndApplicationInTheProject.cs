using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAccounting.Migrations
{
    /// <inheritdoc />
    public partial class EditVacancyOrganizationAndApplicationInTheProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budjet",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "WorkStatus",
                table: "ApplicationsInTheProjects");

            migrationBuilder.AddColumn<double>(
                name: "PaymentRatio",
                table: "Vacancies",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RatingCoefficient",
                table: "Vacancies",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BSO",
                table: "Organizations",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BSR",
                table: "Organizations",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "ApplicationsInTheProjects",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ApplicationsInTheProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusDescription",
                table: "ApplicationsInTheProjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentRatio",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "RatingCoefficient",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "BSO",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "BSR",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "ApplicationsInTheProjects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ApplicationsInTheProjects");

            migrationBuilder.DropColumn(
                name: "StatusDescription",
                table: "ApplicationsInTheProjects");

            migrationBuilder.AddColumn<double>(
                name: "Budjet",
                table: "Vacancies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "WorkStatus",
                table: "ApplicationsInTheProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
