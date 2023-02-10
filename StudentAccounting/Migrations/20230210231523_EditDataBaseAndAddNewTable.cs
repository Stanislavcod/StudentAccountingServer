using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAccounting.Migrations
{
    /// <inheritdoc />
    public partial class EditDataBaseAndAddNewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bonuses_Ranks_RankId",
                table: "Bonuses");

            migrationBuilder.DropIndex(
                name: "IX_Bonuses_RankId",
                table: "Bonuses");

            migrationBuilder.DropColumn(
                name: "BSO",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "RankId",
                table: "Bonuses");

            migrationBuilder.RenameColumn(
                name: "PaymentRatio",
                table: "Vacancies",
                newName: "Bydget");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "TrainingCourses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStart",
                table: "TrainingCourses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TrainingCourses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LectorDescription",
                table: "TrainingCourses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LectorFIO",
                table: "TrainingCourses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RankBonus",
                columns: table => new
                {
                    RankId = table.Column<int>(type: "int", nullable: false),
                    BonusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankBonus", x => new { x.RankId, x.BonusId });
                    table.ForeignKey(
                        name: "FK_RankBonus_Bonuses_BonusId",
                        column: x => x.BonusId,
                        principalTable: "Bonuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RankBonus_Ranks_RankId",
                        column: x => x.RankId,
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RankBonus_BonusId",
                table: "RankBonus",
                column: "BonusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RankBonus");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "TrainingCourses");

            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "TrainingCourses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TrainingCourses");

            migrationBuilder.DropColumn(
                name: "LectorDescription",
                table: "TrainingCourses");

            migrationBuilder.DropColumn(
                name: "LectorFIO",
                table: "TrainingCourses");

            migrationBuilder.RenameColumn(
                name: "Bydget",
                table: "Vacancies",
                newName: "PaymentRatio");

            migrationBuilder.AddColumn<double>(
                name: "BSO",
                table: "Organizations",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RankId",
                table: "Bonuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bonuses_RankId",
                table: "Bonuses",
                column: "RankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bonuses_Ranks_RankId",
                table: "Bonuses",
                column: "RankId",
                principalTable: "Ranks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
