using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ong.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class PedidoAdocao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Authentication_authenticationId",
                table: "Pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Contato_ContatoId",
                table: "Pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Endereco_EnderecoId",
                table: "Pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas");

            migrationBuilder.RenameTable(
                name: "Pessoas",
                newName: "Usuarios");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Usuarios",
                newName: "IX_Usuarios_EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoas_ContatoId",
                table: "Usuarios",
                newName: "IX_Usuarios_ContatoId");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoas_authenticationId",
                table: "Usuarios",
                newName: "IX_Usuarios_authenticationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PedidosAdocao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Obervacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Justificativa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAdocao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosAdocao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidosAdocao_Animais_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidosAdocao_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidosAdocao_AnimalId",
                table: "PedidosAdocao",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosAdocao_UsuarioId",
                table: "PedidosAdocao",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Authentication_authenticationId",
                table: "Usuarios",
                column: "authenticationId",
                principalTable: "Authentication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Contato_ContatoId",
                table: "Usuarios",
                column: "ContatoId",
                principalTable: "Contato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Endereco_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Authentication_authenticationId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Contato_ContatoId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Endereco_EnderecoId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "PedidosAdocao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Pessoas");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_EnderecoId",
                table: "Pessoas",
                newName: "IX_Pessoas_EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_ContatoId",
                table: "Pessoas",
                newName: "IX_Pessoas_ContatoId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_authenticationId",
                table: "Pessoas",
                newName: "IX_Pessoas_authenticationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Authentication_authenticationId",
                table: "Pessoas",
                column: "authenticationId",
                principalTable: "Authentication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Contato_ContatoId",
                table: "Pessoas",
                column: "ContatoId",
                principalTable: "Contato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Endereco_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
