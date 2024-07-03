using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamSystem.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRegisterDatetoCreateDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegisterDate",
                table: "Users",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "RegisterDate",
                table: "UserRoles",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "RegisterDate",
                table: "Teachers",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "RegisterDate",
                table: "Subjects",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "RegisterDate",
                table: "Students",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "RegisterDate",
                table: "Marks",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "RegisterDate",
                table: "Admins",
                newName: "CreateDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Users",
                newName: "RegisterDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "UserRoles",
                newName: "RegisterDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Teachers",
                newName: "RegisterDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Subjects",
                newName: "RegisterDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Students",
                newName: "RegisterDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Marks",
                newName: "RegisterDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Admins",
                newName: "RegisterDate");
        }
    }
}
