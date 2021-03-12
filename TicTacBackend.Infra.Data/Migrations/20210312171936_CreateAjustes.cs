using Microsoft.EntityFrameworkCore.Migrations;

namespace TicTacBackend.Infra.Data.Migrations
{
    public partial class CreateAjustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubProdutos_Produtos_ProdutoId",
                table: "SubProdutos");

            migrationBuilder.DropIndex(
                name: "IX_SubProdutos_ProdutoId",
                table: "SubProdutos");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "SubProdutos");

            migrationBuilder.RenameColumn(
                name: "QuantidadeDisponivel",
                table: "Produtos",
                newName: "Quantidade");

            migrationBuilder.AddColumn<long>(
                name: "Quantidade",
                table: "SubProdutos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ProdutoSubProduto",
                columns: table => new
                {
                    ProdutoId = table.Column<long>(type: "bigint", nullable: false),
                    SubProdutosId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoSubProduto", x => new { x.ProdutoId, x.SubProdutosId });
                    table.ForeignKey(
                        name: "FK_ProdutoSubProduto_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoSubProduto_SubProdutos_SubProdutosId",
                        column: x => x.SubProdutosId,
                        principalTable: "SubProdutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoSubProduto_SubProdutosId",
                table: "ProdutoSubProduto",
                column: "SubProdutosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoSubProduto");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "SubProdutos");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Produtos",
                newName: "QuantidadeDisponivel");

            migrationBuilder.AddColumn<long>(
                name: "ProdutoId",
                table: "SubProdutos",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubProdutos_ProdutoId",
                table: "SubProdutos",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubProdutos_Produtos_ProdutoId",
                table: "SubProdutos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
