using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindPro.DAL.Migrations
{
    /// <inheritdoc />
    public partial class GradeBehaviour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradedSkills");

            migrationBuilder.AddColumn<int>(
                name: "GradeRevisionInMonths",
                table: "SkillLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_EmployeeSkills_EmployeeSkillId",
                        column: x => x.EmployeeSkillId,
                        principalTable: "EmployeeSkills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Grades_SkillLevels_SkillLevelId",
                        column: x => x.SkillLevelId,
                        principalTable: "SkillLevels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_EmployeeId",
                table: "EmployeeSkills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_SkillId",
                table: "EmployeeSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_EmployeeSkillId",
                table: "Grades",
                column: "EmployeeSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SkillLevelId",
                table: "Grades",
                column: "SkillLevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropColumn(
                name: "GradeRevisionInMonths",
                table: "SkillLevels");

            migrationBuilder.CreateTable(
                name: "GradedSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradedSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradedSkills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GradedSkills_SkillLevels_SkillLevelId",
                        column: x => x.SkillLevelId,
                        principalTable: "SkillLevels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GradedSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradedSkills_EmployeeId",
                table: "GradedSkills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_GradedSkills_SkillId",
                table: "GradedSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_GradedSkills_SkillLevelId",
                table: "GradedSkills",
                column: "SkillLevelId");
        }
    }
}
