using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaSystem.Migrations
{
    public partial class NEWVERSION10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Marcas_MarcaEquipamentoIdMarca",
                table: "Equipamentos");

            migrationBuilder.DropIndex(
                name: "IX_Equipamentos_MarcaEquipamentoIdMarca",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "MarcaEquipamentoIdMarca",
                table: "Equipamentos");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_MarcaFK",
                table: "Equipamentos",
                column: "MarcaFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Marcas_MarcaFK",
                table: "Equipamentos",
                column: "MarcaFK",
                principalTable: "Marcas",
                principalColumn: "IdMarca",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Marcas_MarcaFK",
                table: "Equipamentos");

            migrationBuilder.DropIndex(
                name: "IX_Equipamentos_MarcaFK",
                table: "Equipamentos");

            migrationBuilder.AddColumn<int>(
                name: "MarcaEquipamentoIdMarca",
                table: "Equipamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_MarcaEquipamentoIdMarca",
                table: "Equipamentos",
                column: "MarcaEquipamentoIdMarca");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Marcas_MarcaEquipamentoIdMarca",
                table: "Equipamentos",
                column: "MarcaEquipamentoIdMarca",
                principalTable: "Marcas",
                principalColumn: "IdMarca");
        }
    }
}
