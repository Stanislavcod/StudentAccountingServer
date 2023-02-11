using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentAccounting.Migrations
{
    /// <inheritdoc />
    public partial class AddHasDataForRankBonus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Bonuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BonusDescription", "BonusName" },
                values: new object[] { "Description for Bonus 1", "Bonus 1" });

            migrationBuilder.UpdateData(
                table: "Bonuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BonusDescription", "BonusName" },
                values: new object[] { "Description for Bonus 2", "Bonus 2" });

            migrationBuilder.InsertData(
                table: "RankBonus",
                columns: new[] { "BonusId", "RankId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "MaxMmr", "MinMmr", "RankName" },
                values: new object[] { "Description for Rank 1", 1000, 0, "Rank 1" });

            migrationBuilder.UpdateData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "MaxMmr", "MinMmr", "OrganizationId", "RankName" },
                values: new object[] { "Description for Rank 2", 2000, 1001, 1, "Rank 2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RankBonus",
                keyColumns: new[] { "BonusId", "RankId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Bonuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BonusDescription", "BonusName" },
                values: new object[] { "2 базовых", "Деньги" });

            migrationBuilder.UpdateData(
                table: "Bonuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BonusDescription", "BonusName" },
                values: new object[] { "1 выходной", "Выходные" });

            migrationBuilder.UpdateData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "MaxMmr", "MinMmr", "RankName" },
                values: new object[] { "Новичек", 222, 111, "Джун" });

            migrationBuilder.UpdateData(
                table: "Ranks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "MaxMmr", "MinMmr", "OrganizationId", "RankName" },
                values: new object[] { "Опытен", 333, 222, 2, "Мидл" });
        }
    }
}
