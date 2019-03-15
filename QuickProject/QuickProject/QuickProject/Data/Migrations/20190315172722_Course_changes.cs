using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickProject.Data.Migrations
{
    public partial class Course_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_People_StudentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AcadamicYears_AcadamicYearId1",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StudentId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AcadamicYearId1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ScholarShipDeduction",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AcadamicYearId1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "AppliedCourseId",
                table: "Subjects",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppliedCourses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdateOn = table.Column<DateTime>(nullable: false),
                    CreatedByUserId = table.Column<string>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CommentThreadId = table.Column<string>(nullable: true),
                    StudentId = table.Column<string>(nullable: true),
                    AcadamicYearId = table.Column<string>(nullable: true),
                    Fee = table.Column<double>(nullable: false),
                    ScholarShipDeduction = table.Column<double>(nullable: false),
                    CourseName = table.Column<string>(nullable: true),
                    Fees = table.Column<double>(nullable: false),
                    DurationInDays = table.Column<int>(nullable: false),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppliedCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppliedCourses_AcadamicYears_AcadamicYearId",
                        column: x => x.AcadamicYearId,
                        principalTable: "AcadamicYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppliedCourses_CommentThreads_CommentThreadId",
                        column: x => x.CommentThreadId,
                        principalTable: "CommentThreads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppliedCourses_People_StudentId",
                        column: x => x.StudentId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_AppliedCourseId",
                table: "Subjects",
                column: "AppliedCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AppliedCourses_AcadamicYearId",
                table: "AppliedCourses",
                column: "AcadamicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AppliedCourses_CommentThreadId",
                table: "AppliedCourses",
                column: "CommentThreadId");

            migrationBuilder.CreateIndex(
                name: "IX_AppliedCourses_StudentId",
                table: "AppliedCourses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AppliedCourses_AppliedCourseId",
                table: "Subjects",
                column: "AppliedCourseId",
                principalTable: "AppliedCourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AppliedCourses_AppliedCourseId",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "AppliedCourses");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_AppliedCourseId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "AppliedCourseId",
                table: "Subjects");

            migrationBuilder.AddColumn<double>(
                name: "Fee",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ScholarShipDeduction",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AcadamicYearId1",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Courses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentId",
                table: "Courses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AcadamicYearId1",
                table: "Courses",
                column: "AcadamicYearId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_People_StudentId",
                table: "Courses",
                column: "StudentId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AcadamicYears_AcadamicYearId1",
                table: "Courses",
                column: "AcadamicYearId1",
                principalTable: "AcadamicYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
