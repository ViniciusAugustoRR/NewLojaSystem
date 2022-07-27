using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaSystem.Migrations
{
    public partial class alteracoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Responsaveis");

            migrationBuilder.AlterColumn<string>(
                name: "NomeMarca",
                table: "Marcas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MarcaFK",
                table: "Equipamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarcaFK",
                table: "Equipamentos");

            migrationBuilder.AlterColumn<string>(
                name: "NomeMarca",
                table: "Marcas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    IdResponsavel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.IdResponsavel);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    IdServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteServicoId = table.Column<int>(type: "int", nullable: false),
                    EquipamentoServiceIdEquipamento = table.Column<int>(type: "int", nullable: false),
                    ResponsavelServicoIdResponsavel = table.Column<int>(type: "int", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.IdServico);
                    table.ForeignKey(
                        name: "FK_Servicos_Clientes_ClienteServicoId",
                        column: x => x.ClienteServicoId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicos_Equipamentos_EquipamentoServiceIdEquipamento",
                        column: x => x.EquipamentoServiceIdEquipamento,
                        principalTable: "Equipamentos",
                        principalColumn: "IdEquipamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicos_Responsaveis_ResponsavelServicoIdResponsavel",
                        column: x => x.ResponsavelServicoIdResponsavel,
                        principalTable: "Responsaveis",
                        principalColumn: "IdResponsavel",
                        onDelete: ReferentialAction.Cascade);
                });

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
    }
}
