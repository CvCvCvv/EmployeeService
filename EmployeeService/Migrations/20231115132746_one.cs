using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmployeeService.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SalaryIncrement = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Firstname = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateOfEmployment = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tariff = table.Column<double>(type: "double precision", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    JobPostId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_JobPosts_JobPostId",
                        column: x => x.JobPostId,
                        principalTable: "JobPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "коммерческий отдел" },
                    { 2, "производственный отдел" },
                    { 3, "конструкторский отдел" }
                });

            migrationBuilder.InsertData(
                table: "JobPosts",
                columns: new[] { "Id", "Name", "SalaryIncrement" },
                values: new object[,]
                {
                    { 1, "директор", 2.5 },
                    { 2, "заведующий архивом", 2.1000000000000001 },
                    { 3, "менеджер", 2.0 },
                    { 4, "мастер", 2.0 }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "DateOfBirth", "Firstname", "Patronymic", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1993, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Андрей", "Васильевич", "Иванов" },
                    { 2, new DateTime(1983, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Артём", "Дмитриевич", "Крылов" },
                    { 3, new DateTime(1987, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Милана", "Максимовна", "Крючкова" },
                    { 4, new DateTime(1977, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мария", "Арсентьевна", "Кононова" },
                    { 5, new DateTime(2000, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Роман", "Маркович", "Орлов" },
                    { 6, new DateTime(1991, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Вероника", "Александровна", "Сорокина" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfEmployment", "DepartmentId", "JobPostId", "PersonId", "Tariff" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, 20000.0 },
                    { 2, new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 2, 15000.0 },
                    { 3, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 3, 10000.0 },
                    { 4, new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 4, 9000.0 },
                    { 5, new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 5, 5000.0 },
                    { 6, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 6, 12000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobPostId",
                table: "Employees",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PersonId",
                table: "Employees",
                column: "PersonId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "JobPosts");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
