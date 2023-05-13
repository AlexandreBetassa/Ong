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
                table: "pessoas",
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
                name: "IX_pessoas_ContatoId",
                table: "pessoas",
                column: "ContatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoas_Contato_ContatoId",
                table: "pessoas",
                column: "ContatoId",
                principalTable: "Contato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pessoas_Contato_ContatoId",
                table: "pessoas");

            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropIndex(
                name: "IX_pessoas_ContatoId",
                table: "pessoas");

            migrationBuilder.DropColumn(
                name: "ContatoId",
                table: "pessoas");
        }
    }
}
