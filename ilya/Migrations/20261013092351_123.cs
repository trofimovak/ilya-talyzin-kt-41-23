using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ilya.Migrations
{
    /// <inheritdoc />
    public partial class _123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_discipline_name = table.Column<string>(type: "nvarchar(150)", nullable: false, comment: "Название дисциплины"),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Статус удаления дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_speciality",
                columns: table => new
                {
                    speciality_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор специальности")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_title = table.Column<string>(type: "nvarchar(200)", nullable: false, comment: "Название специальности"),
                    c_code = table.Column<string>(type: "nvarchar(20)", nullable: false, comment: "Код специальности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_speciality_speciality_id", x => x.speciality_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи группы")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_group_name = table.Column<string>(type: "nvarchar(100)", nullable: false, comment: "Название группы"),
                    c_course = table.Column<int>(type: "int", nullable: false, comment: "Курс обучения"),
                    f_speciality_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор специальности"),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Статус удаления группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_group_id", x => x.group_id);
                    table.ForeignKey(
                        name: "fk_cd_group_speciality",
                        column: x => x.f_speciality_id,
                        principalTable: "cd_speciality",
                        principalColumn: "speciality_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cd_student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи студента")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_student_firstname = table.Column<string>(type: "nvarchar(100)", nullable: false, comment: "Имя студента"),
                    c_student_lastname = table.Column<string>(type: "nvarchar(100)", nullable: false, comment: "Фамилия студента"),
                    c_student_middlename = table.Column<string>(type: "nvarchar(100)", nullable: false, comment: "Отчество студента"),
                    f_group_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор группы"),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Статус удаления студента")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.f_group_id,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_grade",
                columns: table => new
                {
                    grade_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор оценки")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_value = table.Column<int>(type: "int", nullable: false, comment: "Значение оценки"),
                    f_student_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор студента"),
                    f_discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_grade_grade_id", x => x.grade_id);
                    table.ForeignKey(
                        name: "fk_cd_grade_discipline",
                        column: x => x.f_discipline_id,
                        principalTable: "cd_discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_cd_grade_student",
                        column: x => x.f_student_id,
                        principalTable: "cd_student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_grade_fk_discipline_id",
                table: "cd_grade",
                column: "f_discipline_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_grade_fk_student_id",
                table: "cd_grade",
                column: "f_student_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_group_fk_speciality_id",
                table: "cd_group",
                column: "f_speciality_id");

            migrationBuilder.CreateIndex(
                name: "uq_cd_speciality_code",
                table: "cd_speciality",
                column: "c_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_fk_f_group_id",
                table: "cd_student",
                column: "f_group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_grade");

            migrationBuilder.DropTable(
                name: "cd_discipline");

            migrationBuilder.DropTable(
                name: "cd_student");

            migrationBuilder.DropTable(
                name: "cd_group");

            migrationBuilder.DropTable(
                name: "cd_speciality");
        }
    }
}
