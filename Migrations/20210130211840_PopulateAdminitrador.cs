using IMDb.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDb.Migrations
{
    public partial class PopulateAdminitrador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Administrador",
                columns: new[] { "Id", "Ativo", "Usuario" },
                values: new object[] { 1, true, new Usuario { Id = 1 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
