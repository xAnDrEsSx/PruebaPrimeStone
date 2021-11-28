using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Domain.Administration.Migrations
{
    public partial class UpdateEntityEnroll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enroll_Students_IdCourse",
                table: "Enroll");

            migrationBuilder.CreateIndex(
                name: "IX_Enroll_IdStudent",
                table: "Enroll",
                column: "IdStudent");

            migrationBuilder.AddForeignKey(
                name: "FK_Enroll_Students_IdStudent",
                table: "Enroll",
                column: "IdStudent",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enroll_Students_IdStudent",
                table: "Enroll");

            migrationBuilder.DropIndex(
                name: "IX_Enroll_IdStudent",
                table: "Enroll");

            migrationBuilder.AddForeignKey(
                name: "FK_Enroll_Students_IdCourse",
                table: "Enroll",
                column: "IdCourse",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
