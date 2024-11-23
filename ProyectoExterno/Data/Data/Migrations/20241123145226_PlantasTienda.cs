using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class PlantasTienda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Caracteristicas",
                table: "TipoPlanta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClimaIdeal",
                table: "TipoPlanta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "EsComestible",
                table: "TipoPlanta",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Habitat",
                table: "TipoPlanta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Planta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Disponible",
                table: "Planta",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Planta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Planta",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Planta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tamaño",
                table: "Planta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caracteristicas",
                table: "TipoPlanta");

            migrationBuilder.DropColumn(
                name: "ClimaIdeal",
                table: "TipoPlanta");

            migrationBuilder.DropColumn(
                name: "EsComestible",
                table: "TipoPlanta");

            migrationBuilder.DropColumn(
                name: "Habitat",
                table: "TipoPlanta");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Planta");

            migrationBuilder.DropColumn(
                name: "Disponible",
                table: "Planta");

            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Planta");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Planta");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Planta");

            migrationBuilder.DropColumn(
                name: "Tamaño",
                table: "Planta");
        }
    }
}
