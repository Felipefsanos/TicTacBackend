using Microsoft.EntityFrameworkCore.Migrations;

namespace TicTacBackend.Infra.Data.Migrations
{
    public partial class SubProdutoAdicionandoQuantidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Quantidade",
                table: "SubProdutos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "SubProdutos");
        }
    }
}
