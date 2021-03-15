using Microsoft.EntityFrameworkCore.Migrations;

namespace TicTacBackend.Infra.Data.Migrations
{
    public partial class updateProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoSubProduto_Produtos_ProdutoId",
                table: "ProdutoSubProduto");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "SubProdutos",
                newName: "ProdutoId");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "ProdutoSubProduto",
                newName: "ProdutosId");

            migrationBuilder.AddColumn<long>(
                name: "SubProdutoId",
                table: "Produtos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoSubProduto_Produtos_ProdutosId",
                table: "ProdutoSubProduto",
                column: "ProdutosId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoSubProduto_Produtos_ProdutosId",
                table: "ProdutoSubProduto");

            migrationBuilder.DropColumn(
                name: "SubProdutoId",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "SubProdutos",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "ProdutosId",
                table: "ProdutoSubProduto",
                newName: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoSubProduto_Produtos_ProdutoId",
                table: "ProdutoSubProduto",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
