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
                columns: new[] { "NomeUsuario", "Senha", "Sexo", "Ativo", "DataNascimento" },
                values: new object[] { "nick fury", "shield", "M", true, DateTime.Today.AddYears(-45) });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "NomeUsuario", "Senha", "Sexo", "Ativo", "DataNascimento" },
                values: new object[] { "tony stark", "ironman", "M", true, DateTime.Today.AddYears(-30) });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "NomeUsuario", "Senha", "Sexo", "Ativo", "DataNascimento" },
                values: new object[] { "peter parker", "spiderman", "M", true, DateTime.Today.AddYears(-18) });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "NomeUsuario", "Senha", "Sexo", "Ativo", "DataNascimento" },
                values: new object[] { "natasha romanoff", "viuvanegra", "F", true, DateTime.Today.AddYears(-25) });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "NomeFilme", "Genero", "Duracao", "Diretores", "Atores", "Avaliacao" },
                values: new object[] { "Batman O cavaleiro das trevas", "Ação/Aventura", "2h 32m", "Christopher Nolan", "Christian Bale, Michael Caine, Heath Ledger", 4.9m });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "NomeFilme", "Genero", "Duracao", "Diretores", "Atores", "Avaliacao" },
                values: new object[] { "Esquadrão Suicidas", "Ação/Aventura", "2h 17m", "David Ayer", "Margot Robbie, Will Smith, Jared Leto", 3.9m });

            migrationBuilder.InsertData(
            table: "Sistema",
            columns: new[] { "SecretKeyJwt" },
            values: new object[] { "d41d8cd98f00b204e9800998ecf8427e" });

            migrationBuilder.InsertData(
            table: "Administrador",
            columns: new[] { "Ativo", "UserId" },
            values: new object[] { true, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
