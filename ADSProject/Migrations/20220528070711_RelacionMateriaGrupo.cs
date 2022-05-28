using Microsoft.EntityFrameworkCore.Migrations;

namespace ADSProject.Migrations
{
    public partial class RelacionMateriaGrupo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Grupos_idMateria",
                table: "Grupos",
                column: "idMateria");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_Materias_idMateria",
                table: "Grupos",
                column: "idMateria",
                principalTable: "Materias",
                principalColumn: "idMateria",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Materias_idMateria",
                table: "Grupos");

            migrationBuilder.DropIndex(
                name: "IX_Grupos_idMateria",
                table: "Grupos");
        }
    }
}
