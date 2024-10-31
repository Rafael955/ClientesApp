using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientesApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConcertoColunaATIVO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ATVIO",
                table: "CLIENTE",
                newName: "ATIVO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ATIVO",
                table: "CLIENTE",
                newName: "ATVIO");
        }
    }
}
