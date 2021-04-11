using Microsoft.EntityFrameworkCore.Migrations;

namespace TicTacBackend.Infra.Data.Migrations
{
    public partial class AjustesOrcamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<decimal>(
                name: "ValorFrete",
                table: "Orcamentos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ValorFrete",
                table: "Orcamentos");
        }
    }
}
