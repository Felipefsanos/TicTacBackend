using Microsoft.EntityFrameworkCore.Migrations;

namespace TicTacBackend.Infra.Data.Migrations
{
    public partial class nxn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Orcamentos_OrcamentoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Orcamentos_OrcamentoId",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_OrcamentoId",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_OrcamentoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "OrcamentoId",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "OrcamentoId",
                table: "Produtos");

            migrationBuilder.CreateTable(
                name: "OrcamentoProduto",
                columns: table => new
                {
                    OrcamentoId = table.Column<long>(type: "bigint", nullable: false),
                    ProdutoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoProduto", x => new { x.OrcamentoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_OrcamentoProduto_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrcamentoProduto_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrcamentoServico",
                columns: table => new
                {
                    OrcamentoId = table.Column<long>(type: "bigint", nullable: false),
                    ServicoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoServico", x => new { x.OrcamentoId, x.ServicoId });
                    table.ForeignKey(
                        name: "FK_OrcamentoServico_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrcamentoServico_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoProduto_ProdutoId",
                table: "OrcamentoProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoServico_ServicoId",
                table: "OrcamentoServico",
                column: "ServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrcamentoProduto");

            migrationBuilder.DropTable(
                name: "OrcamentoServico");

            migrationBuilder.AddColumn<long>(
                name: "OrcamentoId",
                table: "Servicos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrcamentoId",
                table: "Produtos",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_OrcamentoId",
                table: "Servicos",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_OrcamentoId",
                table: "Produtos",
                column: "OrcamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Orcamentos_OrcamentoId",
                table: "Produtos",
                column: "OrcamentoId",
                principalTable: "Orcamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Orcamentos_OrcamentoId",
                table: "Servicos",
                column: "OrcamentoId",
                principalTable: "Orcamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
