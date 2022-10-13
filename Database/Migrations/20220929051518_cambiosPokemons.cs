using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class cambiosPokemons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Type_TipoPrimarioId",
                table: "Pokemons");

            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Type_TipoSecundarioId",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_TipoPrimarioId",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_TipoSecundarioId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "IdTipoPrimario",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "TipoPrimarioId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "TipoSecundarioId",
                table: "Pokemons");

            migrationBuilder.RenameColumn(
                name: "IdTipoSecundario",
                table: "Pokemons",
                newName: "IdTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_IdTipo",
                table: "Pokemons",
                column: "IdTipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Type_IdTipo",
                table: "Pokemons",
                column: "IdTipo",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Type_IdTipo",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_IdTipo",
                table: "Pokemons");

            migrationBuilder.RenameColumn(
                name: "IdTipo",
                table: "Pokemons",
                newName: "IdTipoSecundario");

            migrationBuilder.AddColumn<int>(
                name: "IdTipoPrimario",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoPrimarioId",
                table: "Pokemons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoSecundarioId",
                table: "Pokemons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_TipoPrimarioId",
                table: "Pokemons",
                column: "TipoPrimarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_TipoSecundarioId",
                table: "Pokemons",
                column: "TipoSecundarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Type_TipoPrimarioId",
                table: "Pokemons",
                column: "TipoPrimarioId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Type_TipoSecundarioId",
                table: "Pokemons",
                column: "TipoSecundarioId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
