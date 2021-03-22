using Microsoft.EntityFrameworkCore.Migrations;

namespace TicTacBackend.Infra.Data.Migrations
{
    public partial class AlteracaoTabelaServicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gas",
                table: "Servicos");

            migrationBuilder.AddColumn<int>(
                name: "TipoAlimentacao",
                table: "Servicos",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoAlimentacao",
                table: "Servicos");

            migrationBuilder.AddColumn<bool>(
                name: "Gas",
                table: "Servicos",
                type: "bit",
                nullable: true);
        }
    }
}
