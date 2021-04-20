using Microsoft.EntityFrameworkCore.Migrations;

namespace TicTacBackend.Infra.Data.Migrations
{
    public partial class servicoOrcamentoDescricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicoOrcamentoDescricao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicoId = table.Column<long>(type: "bigint", nullable: false),
                    OrcamentoId = table.Column<long>(type: "bigint", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoOrcamentoDescricao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicoOrcamentoDescricao_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicoOrcamentoDescricao_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicoOrcamentoDescricao_OrcamentoId",
                table: "ServicoOrcamentoDescricao",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoOrcamentoDescricao_ServicoId",
                table: "ServicoOrcamentoDescricao",
                column: "ServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicoOrcamentoDescricao");
        }
    }
}
