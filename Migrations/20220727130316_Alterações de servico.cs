using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaSystem.Migrations
{
    public partial class Alteraçõesdeservico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Clientes_ClienteServicoId",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Equipamentos_EquipamentoServiceIdEquipamento",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Responsaveis_ResponsavelServicoIdResponsavel",
                table: "Servicos");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsavelServicoIdResponsavel",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipamentoServiceIdEquipamento",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteServicoId",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Clientes_ClienteServicoId",
                table: "Servicos",
                column: "ClienteServicoId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Equipamentos_EquipamentoServiceIdEquipamento",
                table: "Servicos",
                column: "EquipamentoServiceIdEquipamento",
                principalTable: "Equipamentos",
                principalColumn: "IdEquipamento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Responsaveis_ResponsavelServicoIdResponsavel",
                table: "Servicos",
                column: "ResponsavelServicoIdResponsavel",
                principalTable: "Responsaveis",
                principalColumn: "IdResponsavel",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Clientes_ClienteServicoId",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Equipamentos_EquipamentoServiceIdEquipamento",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Responsaveis_ResponsavelServicoIdResponsavel",
                table: "Servicos");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsavelServicoIdResponsavel",
                table: "Servicos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EquipamentoServiceIdEquipamento",
                table: "Servicos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteServicoId",
                table: "Servicos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Clientes_ClienteServicoId",
                table: "Servicos",
                column: "ClienteServicoId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Equipamentos_EquipamentoServiceIdEquipamento",
                table: "Servicos",
                column: "EquipamentoServiceIdEquipamento",
                principalTable: "Equipamentos",
                principalColumn: "IdEquipamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Responsaveis_ResponsavelServicoIdResponsavel",
                table: "Servicos",
                column: "ResponsavelServicoIdResponsavel",
                principalTable: "Responsaveis",
                principalColumn: "IdResponsavel");
        }
    }
}
