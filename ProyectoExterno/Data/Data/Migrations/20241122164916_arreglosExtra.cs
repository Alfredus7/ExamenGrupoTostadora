using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenGrupoTostadora.Data.Migrations
{
    /// <inheritdoc />
    public partial class arreglosExtra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_TipoPlanta_TipoPlantaId",
                table: "Plantas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plantas",
                table: "Plantas");

            migrationBuilder.RenameTable(
                name: "Plantas",
                newName: "Planta");

            migrationBuilder.RenameIndex(
                name: "IX_Plantas_TipoPlantaId",
                table: "Planta",
                newName: "IX_Planta_TipoPlantaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planta",
                table: "Planta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Planta_TipoPlanta_TipoPlantaId",
                table: "Planta",
                column: "TipoPlantaId",
                principalTable: "TipoPlanta",
                principalColumn: "TipoPlantaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planta_TipoPlanta_TipoPlantaId",
                table: "Planta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planta",
                table: "Planta");

            migrationBuilder.RenameTable(
                name: "Planta",
                newName: "Plantas");

            migrationBuilder.RenameIndex(
                name: "IX_Planta_TipoPlantaId",
                table: "Plantas",
                newName: "IX_Plantas_TipoPlantaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plantas",
                table: "Plantas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_TipoPlanta_TipoPlantaId",
                table: "Plantas",
                column: "TipoPlantaId",
                principalTable: "TipoPlanta",
                principalColumn: "TipoPlantaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
