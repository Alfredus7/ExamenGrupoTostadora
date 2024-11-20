using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenGrupoTostadora.Data.Migrations
{
    /// <inheritdoc />
    public partial class Plantas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_TipoPlantas_TipoPlantaId",
                table: "Plantas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoPlantas",
                table: "TipoPlantas");

            migrationBuilder.RenameTable(
                name: "TipoPlantas",
                newName: "TipoPlanta");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TipoPlanta",
                newName: "TipoPlantaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoPlanta",
                table: "TipoPlanta",
                column: "TipoPlantaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_TipoPlanta_TipoPlantaId",
                table: "Plantas",
                column: "TipoPlantaId",
                principalTable: "TipoPlanta",
                principalColumn: "TipoPlantaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_TipoPlanta_TipoPlantaId",
                table: "Plantas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoPlanta",
                table: "TipoPlanta");

            migrationBuilder.RenameTable(
                name: "TipoPlanta",
                newName: "TipoPlantas");

            migrationBuilder.RenameColumn(
                name: "TipoPlantaId",
                table: "TipoPlantas",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoPlantas",
                table: "TipoPlantas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_TipoPlantas_TipoPlantaId",
                table: "Plantas",
                column: "TipoPlantaId",
                principalTable: "TipoPlantas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
