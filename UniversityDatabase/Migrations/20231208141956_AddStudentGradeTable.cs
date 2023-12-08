using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentGradeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student_grade",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    grade_value_id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    study_plan_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_grade", x => x.id);
                    table.ForeignKey(
                        name: "FK_student_grade_grade_value_grade_value_id",
                        column: x => x.grade_value_id,
                        principalTable: "grade_value",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_grade_student_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_grade_study_plan_study_plan_id",
                        column: x => x.study_plan_id,
                        principalTable: "study_plan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_student_grade_grade_value_id",
                table: "student_grade",
                column: "grade_value_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_grade_student_id",
                table: "student_grade",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_grade_study_plan_id",
                table: "student_grade",
                column: "study_plan_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student_grade");
        }
    }
}
