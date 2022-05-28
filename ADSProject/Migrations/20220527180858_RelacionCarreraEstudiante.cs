using Microsoft.EntityFrameworkCore.Migrations;

namespace ADSProject.Migrations
{
    public partial class RelacionCarreraEstudiante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idCarrera",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_idCarrera",
                table: "Estudiantes",
                column: "idCarrera");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Carreras_idCarrera",
                table: "Estudiantes",
                column: "idCarrera",
                principalTable: "Carreras",
                principalColumn: "idCarrera",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Carreras_idCarrera",
                table: "Estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_Estudiantes_idCarrera",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "idCarrera",
                table: "Estudiantes");
        }
    }
}
