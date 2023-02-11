using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAccounting.Migrations
{
    /// <inheritdoc />
    public partial class EditEntityAndHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bydget",
                table: "Vacancies",
                newName: "Budget");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RankBonus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "RankBonus",
                keyColumns: new[] { "BonusId", "RankId" },
                keyValues: new object[] { 1, 2 },
                column: "Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RankBonus",
                keyColumns: new[] { "BonusId", "RankId" },
                keyValues: new object[] { 2, 2 },
                column: "Id",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "RankBonus");

            migrationBuilder.RenameColumn(
                name: "Budget",
                table: "Vacancies",
                newName: "Bydget");
        }
    }
}
