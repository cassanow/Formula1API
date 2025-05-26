using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formula1API.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoEquipes_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipeId",
                table: "Pilotos");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Pilotos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidade",
                table: "Pilotos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Pilotos");

            migrationBuilder.DropColumn(
                name: "Nacionalidade",
                table: "Pilotos");

            migrationBuilder.AddColumn<int>(
                name: "EquipeId",
                table: "Pilotos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
