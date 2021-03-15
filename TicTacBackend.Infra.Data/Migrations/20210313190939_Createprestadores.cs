using Microsoft.EntityFrameworkCore.Migrations;

namespace TicTacBackend.Infra.Data.Migrations
{
    public partial class Createprestadores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Clientes_ClienteId",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos");

            migrationBuilder.AlterColumn<long>(
                name: "ClienteId",
                table: "Enderecos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "PrestadorId",
                table: "Enderecos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ClienteId",
                table: "Contatos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "PrestadorId",
                table: "Contatos",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prestadores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestadores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                unique: true,
                filter: "[ClienteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PrestadorId",
                table: "Enderecos",
                column: "PrestadorId",
                unique: true,
                filter: "[PrestadorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_PrestadorId",
                table: "Contatos",
                column: "PrestadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Clientes_ClienteId",
                table: "Contatos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Prestadores_PrestadorId",
                table: "Contatos",
                column: "PrestadorId",
                principalTable: "Prestadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Prestadores_PrestadorId",
                table: "Enderecos",
                column: "PrestadorId",
                principalTable: "Prestadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Clientes_ClienteId",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Prestadores_PrestadorId",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Prestadores_PrestadorId",
                table: "Enderecos");

            migrationBuilder.DropTable(
                name: "Prestadores");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_PrestadorId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Contatos_PrestadorId",
                table: "Contatos");

            migrationBuilder.DropColumn(
                name: "PrestadorId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "PrestadorId",
                table: "Contatos");

            migrationBuilder.AlterColumn<long>(
                name: "ClienteId",
                table: "Enderecos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ClienteId",
                table: "Contatos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Clientes_ClienteId",
                table: "Contatos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
