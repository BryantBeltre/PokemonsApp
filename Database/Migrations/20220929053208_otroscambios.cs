using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class otroscambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Type_IdTipo",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_IdTipo",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "Type",
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
                name: "TipoSecundariosId",
                table: "Pokemons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_IdTipoPrimario",
                table: "Pokemons",
                column: "IdTipoPrimario");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_TipoSecundariosId",
                table: "Pokemons",
                column: "TipoSecundariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Type_IdTipoPrimario",
                table: "Pokemons",
                column: "IdTipoPrimario",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Type_TipoSecundariosId",
                table: "Pokemons",
                column: "TipoSecundariosId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Type_IdTipoPrimario",
                table: "Pokemons");

            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Type_TipoSecundariosId",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_IdTipoPrimario",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_TipoSecundariosId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "IdTipoPrimario",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "TipoSecundariosId",
                table: "Pokemons");

            migrationBuilder.RenameColumn(
                name: "IdTipoSecundario",
                table: "Pokemons",
                newName: "IdTipo");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
