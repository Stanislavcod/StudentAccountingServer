using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAccounting.Migrations
{
    /// <inheritdoc />
    public partial class EditHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankBonus",
                keyColumns: new[] { "BonusId", "RankId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "RankBonus",
                columns: new[] { "BonusId", "RankId" },
                values: new object[] { 1, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankBonus",
                keyColumns: new[] { "BonusId", "RankId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "RankBonus",
                columns: new[] { "BonusId", "RankId" },
                values: new object[] { 2, 1 });
        }
    }
}
