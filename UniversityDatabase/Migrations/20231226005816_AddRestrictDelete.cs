using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddRestrictDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_department_faculty_faculty_id",
                table: "department");

            migrationBuilder.DropForeignKey(
                name: "FK_faculty_dean_dean_id",
                table: "faculty");

            migrationBuilder.DropForeignKey(
                name: "FK_grade_value_form_of_control_form_of_control_id",
                table: "grade_value");

            migrationBuilder.DropForeignKey(
                name: "FK_student_sex_sex_id",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "FK_student_study_group_study_group_id",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "FK_student_grade_grade_value_grade_value_id",
                table: "student_grade");

            migrationBuilder.DropForeignKey(
                name: "FK_student_grade_student_student_id",
                table: "student_grade");

            migrationBuilder.DropForeignKey(
                name: "FK_student_grade_study_plan_study_plan_id",
                table: "student_grade");

            migrationBuilder.DropForeignKey(
                name: "FK_study_group_course_course_id",
                table: "study_group");

            migrationBuilder.DropForeignKey(
                name: "FK_study_group_faculty_faculty_id",
                table: "study_group");

            migrationBuilder.DropForeignKey(
                name: "FK_study_plan_course_course_id",
                table: "study_plan");

            migrationBuilder.DropForeignKey(
                name: "FK_study_plan_form_of_control_form_of_control",
                table: "study_plan");

            migrationBuilder.DropForeignKey(
                name: "FK_study_plan_semester_semester_id",
                table: "study_plan");

            migrationBuilder.DropForeignKey(
                name: "FK_study_plan_study_group_study_group_id",
                table: "study_plan");

            migrationBuilder.DropForeignKey(
                name: "FK_study_plan_subject_subject_id",
                table: "study_plan");

            migrationBuilder.DropForeignKey(
                name: "FK_study_plan_type_of_occupation_type_of_occupation",
                table: "study_plan");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_department_department_id",
                table: "teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_sex_sex_id",
                table: "teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_teacher_position_teacher_position_id",
                table: "teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_workload_study_plan_study_plan_id",
                table: "workload");

            migrationBuilder.DropForeignKey(
                name: "FK_workload_teacher_teacher_id",
                table: "workload");

            migrationBuilder.AddForeignKey(
                name: "FK_department_faculty_faculty_id",
                table: "department",
                column: "faculty_id",
                principalTable: "faculty",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_faculty_dean_dean_id",
                table: "faculty",
                column: "dean_id",
                principalTable: "dean",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_grade_value_form_of_control_form_of_control_id",
                table: "grade_value",
                column: "form_of_control_id",
                principalTable: "form_of_control",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_student_sex_sex_id",
                table: "student",
                column: "sex_id",
                principalTable: "sex",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_student_study_group_study_group_id",
                table: "student",
                column: "study_group_id",
                principalTable: "study_group",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_student_grade_grade_value_grade_value_id",
                table: "student_grade",
                column: "grade_value_id",
                principalTable: "grade_value",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_student_grade_student_student_id",
                table: "student_grade",
                column: "student_id",
                principalTable: "student",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_student_grade_study_plan_study_plan_id",
                table: "student_grade",
                column: "study_plan_id",
                principalTable: "study_plan",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_study_group_course_course_id",
                table: "study_group",
                column: "course_id",
                principalTable: "course",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_study_group_faculty_faculty_id",
                table: "study_group",
                column: "faculty_id",
                principalTable: "faculty",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_study_plan_course_course_id",
                table: "study_plan",
                column: "course_id",
                principalTable: "course",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_study_plan_form_of_control_form_of_control",
                table: "study_plan",
                column: "form_of_control",
                principalTable: "form_of_control",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_study_plan_semester_semester_id",
                table: "study_plan",
                column: "semester_id",
                principalTable: "semester",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_study_plan_study_group_study_group_id",
                table: "study_plan",
                column: "study_group_id",
                principalTable: "study_group",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_study_plan_subject_subject_id",
                table: "study_plan",
                column: "subject_id",
                principalTable: "subject",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_study_plan_type_of_occupation_type_of_occupation",
                table: "study_plan",
                column: "type_of_occupation",
                principalTable: "type_of_occupation",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_department_department_id",
                table: "teacher",
                column: "department_id",
                principalTable: "department",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_sex_sex_id",
                table: "teacher",
                column: "sex_id",
                principalTable: "sex",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_teacher_position_teacher_position_id",
                table: "teacher",
                column: "teacher_position_id",
                principalTable: "teacher_position",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_workload_study_plan_study_plan_id",
                table: "workload",
                column: "study_plan_id",
                principalTable: "study_plan",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_workload_teacher_teacher_id",
                table: "workload",
                column: "teacher_id",
                principalTable: "teacher",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_department_faculty_faculty_id",
                table: "department");

            migrationBuilder.DropForeignKey(
                name: "FK_faculty_dean_dean_id",
                table: "faculty");

            migrationBuilder.DropForeignKey(
                name: "FK_grade_value_form_of_control_form_of_control_id",
                table: "grade_value");

            migrationBuilder.DropForeignKey(
                name: "FK_student_sex_sex_id",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "FK_student_study_group_study_group_id",
                table: "student");

            migrationBuilder.DropForeignKey(
                name: "FK_student_grade_grade_value_grade_value_id",
                table: "student_grade");

            migrationBuilder.DropForeignKey(
                name: "FK_student_grade_student_student_id",
                table: "student_grade");

            migrationBuilder.DropForeignKey(
                name: "FK_student_grade_study_plan_study_plan_id",
                table: "student_grade");

            migrationBuilder.DropForeignKey(
                name: "FK_study_group_course_course_id",
                table: "study_group");

            migrationBuilder.DropForeignKey(
                name: "FK_study_group_faculty_faculty_id",
                table: "study_group");

            migrationBuilder.DropForeignKey(
                name: "FK_study_plan_course_course_id",
                table: "study_plan");

            migrationBuilder.DropForeignKey(
                name: "FK_study_plan_form_of_control_form_of_control",
                table: "study_plan");

            migrationBuilder.DropForeignKey(
                name: "FK_study_plan_semester_semester_id",
                table: "study_plan");

            migrationBuilder.DropForeignKey(
                name: "FK_study_plan_study_group_study_group_id",
                table: "study_plan");

            migrationBuilder.DropForeignKey(
                name: "FK_study_plan_subject_subject_id",
                table: "study_plan");

            migrationBuilder.DropForeignKey(
                name: "FK_study_plan_type_of_occupation_type_of_occupation",
                table: "study_plan");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_department_department_id",
                table: "teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_sex_sex_id",
                table: "teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_teacher_position_teacher_position_id",
                table: "teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_workload_study_plan_study_plan_id",
                table: "workload");

            migrationBuilder.DropForeignKey(
                name: "FK_workload_teacher_teacher_id",
                table: "workload");

            migrationBuilder.AddForeignKey(
                name: "FK_department_faculty_faculty_id",
                table: "department",
                column: "faculty_id",
                principalTable: "faculty",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_faculty_dean_dean_id",
                table: "faculty",
                column: "dean_id",
                principalTable: "dean",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_grade_value_form_of_control_form_of_control_id",
                table: "grade_value",
                column: "form_of_control_id",
                principalTable: "form_of_control",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_sex_sex_id",
                table: "student",
                column: "sex_id",
                principalTable: "sex",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_study_group_study_group_id",
                table: "student",
                column: "study_group_id",
                principalTable: "study_group",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_grade_grade_value_grade_value_id",
                table: "student_grade",
                column: "grade_value_id",
                principalTable: "grade_value",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_student_grade_student_student_id",
                table: "student_grade",
                column: "student_id",
                principalTable: "student",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_grade_study_plan_study_plan_id",
                table: "student_grade",
                column: "study_plan_id",
                principalTable: "study_plan",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_study_group_course_course_id",
                table: "study_group",
                column: "course_id",
                principalTable: "course",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_study_group_faculty_faculty_id",
                table: "study_group",
                column: "faculty_id",
                principalTable: "faculty",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_study_plan_course_course_id",
                table: "study_plan",
                column: "course_id",
                principalTable: "course",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_study_plan_form_of_control_form_of_control",
                table: "study_plan",
                column: "form_of_control",
                principalTable: "form_of_control",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_study_plan_semester_semester_id",
                table: "study_plan",
                column: "semester_id",
                principalTable: "semester",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_study_plan_study_group_study_group_id",
                table: "study_plan",
                column: "study_group_id",
                principalTable: "study_group",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_study_plan_subject_subject_id",
                table: "study_plan",
                column: "subject_id",
                principalTable: "subject",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_study_plan_type_of_occupation_type_of_occupation",
                table: "study_plan",
                column: "type_of_occupation",
                principalTable: "type_of_occupation",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_department_department_id",
                table: "teacher",
                column: "department_id",
                principalTable: "department",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_sex_sex_id",
                table: "teacher",
                column: "sex_id",
                principalTable: "sex",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_teacher_position_teacher_position_id",
                table: "teacher",
                column: "teacher_position_id",
                principalTable: "teacher_position",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workload_study_plan_study_plan_id",
                table: "workload",
                column: "study_plan_id",
                principalTable: "study_plan",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workload_teacher_teacher_id",
                table: "workload",
                column: "teacher_id",
                principalTable: "teacher",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
