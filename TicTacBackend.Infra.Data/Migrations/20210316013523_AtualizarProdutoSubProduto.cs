using Microsoft.EntityFrameworkCore.Migrations;

namespace TicTacBackend.Infra.Data.Migrations
{
    public partial class AtualizarProdutoSubProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "SubProdutos");

            migrationBuilder.DropColumn(
                name: "SubProdutoId",
                table: "Produtos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProdutoId",
                table: "SubProdutos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SubProdutoId",
                table: "Produtos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
