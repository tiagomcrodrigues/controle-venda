using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleVenda.Infra.Data.Migrations
{
    public partial class Cliente_Pedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoPessoa = table.Column<string>(type: "char(1)", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Documento = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoLogradouro = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logradouro = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Uf = table.Column<string>(type: "char(20)", unicode: false, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(254)", unicode: false, maxLength: 254, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Cancelado = table.Column<ulong>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PedidoItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Nome",
                table: "Cliente",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "UK_Cliente_Documento",
                table: "Cliente",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_PedidoId",
                table: "PedidoItem",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_ProdutoId",
                table: "PedidoItem",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoItem");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
