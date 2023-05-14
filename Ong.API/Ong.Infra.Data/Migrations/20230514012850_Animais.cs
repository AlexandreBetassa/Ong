using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ong.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Animais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pessoas_Authentication_authenticationId",
                table: "pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_pessoas_Contato_ContatoId",
                table: "pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_pessoas_Endereco_EnderecoId",
                table: "pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pessoas",
                table: "pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_parceiros",
                table: "parceiros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_noticias",
                table: "noticias");

            migrationBuilder.RenameTable(
                name: "pessoas",
                newName: "Pessoas");

            migrationBuilder.RenameTable(
                name: "parceiros",
                newName: "Parceiros");

            migrationBuilder.RenameTable(
                name: "noticias",
                newName: "Noticias");

            migrationBuilder.RenameIndex(
                name: "IX_pessoas_EnderecoId",
                table: "Pessoas",
                newName: "IX_Pessoas_EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_pessoas_ContatoId",
                table: "Pessoas",
                newName: "IX_Pessoas_ContatoId");

            migrationBuilder.RenameIndex(
                name: "IX_pessoas_authenticationId",
                table: "Pessoas",
                newName: "IX_Pessoas_authenticationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parceiros",
                table: "Parceiros",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Noticias",
                table: "Noticias",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Informacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    UrlImagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parceiros",
                table: "Parceiros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Noticias",
                table: "Noticias");

            migrationBuilder.RenameTable(
                name: "Pessoas",
                newName: "pessoas");

            migrationBuilder.RenameTable(
                name: "Parceiros",
                newName: "parceiros");

            migrationBuilder.RenameTable(
                name: "Noticias",
                newName: "noticias");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "pessoas",
                newName: "IX_pessoas_EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoas_ContatoId",
                table: "pessoas",
                newName: "IX_pessoas_ContatoId");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoas_authenticationId",
                table: "pessoas",
                newName: "IX_pessoas_authenticationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pessoas",
                table: "pessoas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_parceiros",
                table: "parceiros",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_noticias",
                table: "noticias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoas_Authentication_authenticationId",
                table: "pessoas",
                column: "authenticationId",
                principalTable: "Authentication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pessoas_Contato_ContatoId",
                table: "pessoas",
                column: "ContatoId",
                principalTable: "Contato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pessoas_Endereco_EnderecoId",
                table: "pessoas",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
