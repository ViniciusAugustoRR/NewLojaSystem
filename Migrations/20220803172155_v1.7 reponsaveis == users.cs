using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaSystem.Migrations
{
    public partial class v17reponsaveisusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Responsaveis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Responsaveis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Responsaveis",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Responsaveis");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Responsaveis");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Responsaveis");
        }
    }
}
