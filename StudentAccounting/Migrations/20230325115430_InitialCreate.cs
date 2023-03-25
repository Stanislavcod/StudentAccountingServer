using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentAccounting.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bonuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BonusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BonusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contacts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Individuals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialNetwork = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individuals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contacts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BSR = table.Column<double>(type: "float", nullable: true),
                    FoundationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    NormalName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LectorFIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LectorDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCourses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicalSpecification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    idLocalPM = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentCard = table.Column<long>(type: "bigint", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseNumber = table.Column<int>(type: "int", nullable: false),
                    University = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndividualsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Individuals_IndividualsId",
                        column: x => x.IndividualsId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectorId = table.Column<int>(type: "int", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxMmr = table.Column<int>(type: "int", nullable: false),
                    MinMmr = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ranks_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regulations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regulations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regulations_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleOfСlasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkSpaceLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingCoursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleOfСlasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleOfСlasses_TrainingCourses_TrainingCoursesId",
                        column: x => x.TrainingCoursesId,
                        principalTable: "TrainingCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StagesOfProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StagesOfProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StagesOfProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationalPortals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalPortals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalPortals_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RankBonus",
                columns: table => new
                {
                    RankId = table.Column<int>(type: "int", nullable: false),
                    BonusId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndividualsId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateExit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mmr = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GitHub = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Individuals_IndividualsId",
                        column: x => x.IndividualsId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responsibilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Budget = table.Column<double>(type: "float", nullable: true),
                    RatingCoefficient = table.Column<double>(type: "float", nullable: true),
                    StagesOfProjectId = table.Column<int>(type: "int", nullable: false),
                    isOpened = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacancies_StagesOfProjects_StagesOfProjectId",
                        column: x => x.StagesOfProjectId,
                        principalTable: "StagesOfProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMentor = table.Column<int>(type: "int", nullable: true),
                    ParticipantsId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employments_Participants_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employments_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationForCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParticipantsId = table.Column<int>(type: "int", nullable: false),
                    TrainingCoursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationForCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrationForCourses_Participants_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistrationForCourses_TrainingCourses_TrainingCoursesId",
                        column: x => x.TrainingCoursesId,
                        principalTable: "TrainingCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationsInTheProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParticipantsId = table.Column<int>(type: "int", nullable: false),
                    VacancyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationsInTheProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationsInTheProjects_Participants_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationsInTheProjects_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinalProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GitHub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Links = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmploymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalProjects_Employments_EmploymentId",
                        column: x => x.EmploymentId,
                        principalTable: "Employments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Individuals",
                columns: new[] { "Id", "DateOfBirth", "FIO", "Gender", "Mail", "Phone", "SocialNetwork" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 25, 14, 54, 29, 979, DateTimeKind.Local).AddTicks(3691), "первый", "aaa", "aaa", "aaa", "aaa" },
                    { 2, new DateTime(2023, 3, 25, 14, 54, 29, 979, DateTimeKind.Local).AddTicks(3694), "второй", "aaa", "aaa", "aaa", "aaa" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Address", "BSR", "Contacts", "FoundationDate", "Fullname", "WebSite" },
                values: new object[,]
                {
                    { 1, "aaa", 4.5, "aaa", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Первый", "aaa" },
                    { 2, "aaa", 4.5, "aaa", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Второй", "aaa" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NormalName" },
                values: new object[,]
                {
                    { 1, 1, "Application user" },
                    { 2, 2, "User with additional rights" },
                    { 3, 3, "Pm which has limited access to the table" },
                    { 4, 4, "Local Pm has limited access to one table" },
                    { 5, 5, "Has access to editing the tables of his department" },
                    { 6, 6, "Has access to editing the tables of his department and registration users" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DateEnd", "DateStart", "Description", "DirectorId", "FullName", "OrganizationId", "Status" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 3, 25, 14, 54, 29, 979, DateTimeKind.Local).AddTicks(3600), "Description 1", 1, "Department 1", 1, "Active" },
                    { 2, null, new DateTime(2023, 3, 25, 14, 54, 29, 979, DateTimeKind.Local).AddTicks(3611), "Description 2", 2, "Department 2", 2, "Active" }
                });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "DateEntry", "DateExit", "GitHub", "IndividualsId", "Mmr", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 25, 14, 54, 29, 979, DateTimeKind.Local).AddTicks(3647), null, "github.com/user1", 1, 1000, "Active", 1 },
                    { 2, new DateTime(2023, 3, 25, 14, 54, 29, 979, DateTimeKind.Local).AddTicks(3649), null, "github.com/user2", 2, 1200, "Active", 2 }
                });

            migrationBuilder.InsertData(
                table: "Ranks",
                columns: new[] { "Id", "Description", "MaxMmr", "MinMmr", "OrganizationId", "RankName" },
                values: new object[,]
                {
                    { 1, "aaa", 999, 1, 1, "Первый" },
                    { 2, "bbb", 999, 1, 2, "Второй" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "DepartmentId", "Description", "FullName" },
                values: new object[,]
                {
                    { 1, 1, "Description 1", "Position 1" },
                    { 2, 2, "Description 2", "Position 2" }
                });

            migrationBuilder.InsertData(
                table: "Employments",
                columns: new[] { "Id", "DateEnd", "DateStart", "IdMentor", "ParticipantsId", "PositionId", "Status", "StatusDescription", "isActive" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 24, 14, 54, 29, 979, DateTimeKind.Local).AddTicks(3671), new DateTime(2023, 3, 25, 14, 54, 29, 979, DateTimeKind.Local).AddTicks(3670), null, 1, 1, "Active", "Description 1", "Yes" },
                    { 2, new DateTime(2023, 4, 24, 14, 54, 29, 979, DateTimeKind.Local).AddTicks(3676), new DateTime(2023, 3, 25, 14, 54, 29, 979, DateTimeKind.Local).AddTicks(3676), null, 2, 2, "Active", "Description 2", "Yes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationsInTheProjects_ParticipantsId",
                table: "ApplicationsInTheProjects",
                column: "ParticipantsId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationsInTheProjects_VacancyId",
                table: "ApplicationsInTheProjects",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_OrganizationId",
                table: "Departments",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalPortals_DepartmentId",
                table: "EducationalPortals",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_ParticipantsId",
                table: "Employments",
                column: "ParticipantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_PositionId",
                table: "Employments",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalProjects_EmploymentId",
                table: "FinalProjects",
                column: "EmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_IndividualsId",
                table: "Participants",
                column: "IndividualsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_UserId",
                table: "Participants",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DepartmentId",
                table: "Positions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RankBonus_BonusId",
                table: "RankBonus",
                column: "BonusId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_OrganizationId",
                table: "Ranks",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationForCourses_ParticipantsId",
                table: "RegistrationForCourses",
                column: "ParticipantsId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationForCourses_TrainingCoursesId",
                table: "RegistrationForCourses",
                column: "TrainingCoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_Regulations_OrganizationId",
                table: "Regulations",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleOfСlasses_TrainingCoursesId",
                table: "ScheduleOfСlasses",
                column: "TrainingCoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_StagesOfProjects_ProjectId",
                table: "StagesOfProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IndividualsId",
                table: "Students",
                column: "IndividualsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_StagesOfProjectId",
                table: "Vacancies",
                column: "StagesOfProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationsInTheProjects");

            migrationBuilder.DropTable(
                name: "EducationalPortals");

            migrationBuilder.DropTable(
                name: "FinalProjects");

            migrationBuilder.DropTable(
                name: "RankBonus");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "RegistrationForCourses");

            migrationBuilder.DropTable(
                name: "Regulations");

            migrationBuilder.DropTable(
                name: "ScheduleOfСlasses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "Employments");

            migrationBuilder.DropTable(
                name: "Bonuses");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "TrainingCourses");

            migrationBuilder.DropTable(
                name: "StagesOfProjects");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Individuals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
