using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddStudyPlanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "study_plan",
                columns: table => new
                {
                    id = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    total_hours = table.Column<int>(type: "int", nullable: false),
                    course_id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    semester_id = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    subject_id = table.Column<int>(type: "int", nullable: false),
                    form_of_control = table.Column<int>(type: "int", nullable: false),
                    type_of_occupation = table.Column<int>(type: "int", nullable: false),
                    study_group_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_study_plan", x => x.id);
                    table.ForeignKey(
                        name: "FK_study_plan_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_study_plan_form_of_control_form_of_control",
                        column: x => x.form_of_control,
                        principalTable: "form_of_control",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_study_plan_semester_semester_id",
                        column: x => x.semester_id,
                        principalTable: "semester",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_study_plan_study_group_study_group_id",
                        column: x => x.study_group_id,
                        principalTable: "study_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_study_plan_subject_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_study_plan_type_of_occupation_type_of_occupation",
                        column: x => x.type_of_occupation,
                        principalTable: "type_of_occupation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_study_plan_course_id",
                table: "study_plan",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_study_plan_form_of_control",
                table: "study_plan",
                column: "form_of_control");

            migrationBuilder.CreateIndex(
                name: "IX_study_plan_semester_id",
                table: "study_plan",
                column: "semester_id");

            migrationBuilder.CreateIndex(
                name: "IX_study_plan_study_group_id",
                table: "study_plan",
                column: "study_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_study_plan_subject_id",
                table: "study_plan",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_study_plan_type_of_occupation",
                table: "study_plan",
                column: "type_of_occupation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "study_plan");
        }
    }
}
