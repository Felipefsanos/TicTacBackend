using Microsoft.EntityFrameworkCore.Migrations;

namespace TicTacBackend.Infra.Data.Migrations
{
    public partial class CreateComponente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoSubProduto");

            migrationBuilder.DropTable(
                name: "SubProdutos");

            migrationBuilder.CreateTable(
                name: "Componentes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantidade = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponenteProduto",
                columns: table => new
                {
                    ComponentesId = table.Column<long>(type: "bigint", nullable: false),
                    ProdutosId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponenteProduto", x => new { x.ComponentesId, x.ProdutosId });
                    table.ForeignKey(
                        name: "FK_ComponenteProduto_Componentes_ComponentesId",
                        column: x => x.ComponentesId,
                        principalTable: "Componentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponenteProduto_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponenteProduto_ProdutosId",
                table: "ComponenteProduto",
                column: "ProdutosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponenteProduto");

            migrationBuilder.DropTable(
                name: "Componentes");

            migrationBuilder.CreateTable(
                name: "SubProdutos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantidade = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProdutos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoSubProduto",
                columns: table => new
                {
                    ProdutosId = table.Column<long>(type: "bigint", nullable: false),
                    SubProdutosId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoSubProduto", x => new { x.ProdutosId, x.SubProdutosId });
                    table.ForeignKey(
                        name: "FK_ProdutoSubProduto_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
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
    }
}
