using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaSystem.Migrations
{
    public partial class ModelsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeMarca = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.IdMarca);
                });

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    IdResponsavel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.IdResponsavel);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    IdEquipamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroSerie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarcaEquipamentoIdMarca = table.Column<int>(type: "int", nullable: true),
                    Acessorios = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.IdEquipamento);
                    table.ForeignKey(
                        name: "FK_Equipamentos_Marcas_MarcaEquipamentoIdMarca",
                        column: x => x.MarcaEquipamentoIdMarca,
                        principalTable: "Marcas",
                        principalColumn: "IdMarca");
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    IdServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteServicoId = table.Column<int>(type: "int", nullable: true),
                    ResponsavelServicoIdResponsavel = table.Column<int>(type: "int", nullable: true),
                    EquipamentoServiceIdEquipamento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.IdServico);
                    table.ForeignKey(
                        name: "FK_Servicos_Clientes_ClienteServicoId",
                        column: x => x.ClienteServicoId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Servicos_Equipamentos_EquipamentoServiceIdEquipamento",
                        column: x => x.EquipamentoServiceIdEquipamento,
                        principalTable: "Equipamentos",
                        principalColumn: "IdEquipamento");
                    table.ForeignKey(
                        name: "FK_Servicos_Responsaveis_ResponsavelServicoIdResponsavel",
                        column: x => x.ResponsavelServicoIdResponsavel,
                        principalTable: "Responsaveis",
                        principalColumn: "IdResponsavel");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_MarcaEquipamentoIdMarca",
                table: "Equipamentos",
                column: "MarcaEquipamentoIdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_ClienteServicoId",
                table: "Servicos",
                column: "ClienteServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_EquipamentoServiceIdEquipamento",
                table: "Servicos",
                column: "EquipamentoServiceIdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_ResponsavelServicoIdResponsavel",
                table: "Servicos",
                column: "ResponsavelServicoIdResponsavel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Responsaveis");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
