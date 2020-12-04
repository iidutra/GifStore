using Microsoft.EntityFrameworkCore.Migrations;

namespace GifStore.Migrations
{
    public partial class RefatorandoModeloCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Clientes_UsuarioId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_UsuarioId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ProdutoId",
                table: "Clientes",
                column: "ProdutoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Produtos_ProdutoId",
                table: "Clientes",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Produtos_ProdutoId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ProdutoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_UsuarioId",
                table: "Produtos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Clientes_UsuarioId",
                table: "Produtos",
                column: "UsuarioId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
