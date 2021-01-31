using System;
using IMDb.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDb.Migrations
{
    public partial class Populate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "NomeUsuario", "Senha", "Sexo", "Ativo", "DataNascimento" },
                values: new object[] { 1, "tony stark", "ironman", "M", true, DateTime.Today.AddYears(-30) });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "NomeUsuario", "Senha", "Sexo", "Ativo", "DataNascimento" },
                values: new object[] { 2, "peter parker", "spiderman", "M", true, DateTime.Today.AddYears(-18) });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "NomeUsuario", "Senha", "Sexo", "Ativo", "DataNascimento" },
                values: new object[] { 3, "natasha romanoff", "viuvanegra", "F", true, DateTime.Today.AddYears(-25) });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "NomeFilme", "Genero", "Duracao", "Diretores", "Atores", "Avaliacao" },
                values: new object[] { 1, "Batman O cavaleiro das trevas", "Ação/Aventura", "2h 32m", "Christopher Nolan", "Christian Bale, Michael Caine, Heath Ledger", 4.9m });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "NomeFilme", "Genero", "Duracao", "Diretores", "Atores", "Avaliacao" },
                values: new object[] { 2, "Esquadrão Suicidas", "Ação/Aventura", "2h 17m", "David Ayer", "Margot Robbie, Will Smith, Jared Leto", 3.9m });


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
