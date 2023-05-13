using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ong.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class PessoaContato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContatoId",
                table: "usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoContato = table.Column<int>(type: "int", nullable: false),
                    Ramal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_ContatoId",
                table: "usuarios",
                column: "ContatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoas_Contato_ContatoId",
                table: "usuarios",
                column: "ContatoId",
                principalTable: "Contato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_Contato_ContatoId",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_ContatoId",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "ContatoId",
                table: "usuarios");
        }
    }
}
