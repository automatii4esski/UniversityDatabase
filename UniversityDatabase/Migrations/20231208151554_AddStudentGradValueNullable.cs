using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentGradValueNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_grade_grade_value_grade_value_id",
                table: "student_grade");

            migrationBuilder.AlterColumn<byte>(
                name: "grade_value_id",
                table: "student_grade",
                type: "tinyint unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");

            migrationBuilder.AddForeignKey(
                name: "FK_student_grade_grade_value_grade_value_id",
                table: "student_grade",
                column: "grade_value_id",
                principalTable: "grade_value",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_grade_grade_value_grade_value_id",
                table: "student_grade");

            migrationBuilder.AlterColumn<byte>(
                name: "grade_value_id",
                table: "student_grade",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_student_grade_grade_value_grade_value_id",
                table: "student_grade",
                column: "grade_value_id",
                principalTable: "grade_value",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
