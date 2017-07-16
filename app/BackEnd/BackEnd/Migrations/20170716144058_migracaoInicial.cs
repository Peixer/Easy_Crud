using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BackEnd.Migrations
{
    public partial class migracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContaBancaria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Agencia = table.Column<string>(nullable: true),
                    Banco = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaBancaria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cidade = table.Column<string>(nullable: false),
                    ConhecimentoEmAndroid = table.Column<int>(nullable: false),
                    ConhecimentoEmAngularJS = table.Column<int>(nullable: false),
                    ConhecimentoEmAspNetMvc = table.Column<int>(nullable: false),
                    ConhecimentoEmBoostrap = table.Column<int>(nullable: false),
                    ConhecimentoEmC = table.Column<int>(nullable: false),
                    ConhecimentoEmCPlusPlus = table.Column<int>(nullable: false),
                    ConhecimentoEmCake = table.Column<int>(nullable: false),
                    ConhecimentoEmCss = table.Column<int>(nullable: false),
                    ConhecimentoEmDJango = table.Column<int>(nullable: false),
                    ConhecimentoEmHtml = table.Column<int>(nullable: false),
                    ConhecimentoEmIOS = table.Column<int>(nullable: false),
                    ConhecimentoEmIllustrator = table.Column<int>(nullable: false),
                    ConhecimentoEmIonic = table.Column<int>(nullable: false),
                    ConhecimentoEmJQuery = table.Column<int>(nullable: false),
                    ConhecimentoEmJava = table.Column<int>(nullable: false),
                    ConhecimentoEmMajento = table.Column<int>(nullable: false),
                    ConhecimentoEmMySql = table.Column<int>(nullable: false),
                    ConhecimentoEmOutroFramework = table.Column<string>(nullable: true),
                    ConhecimentoEmPHP = table.Column<int>(nullable: false),
                    ConhecimentoEmPhotoshop = table.Column<int>(nullable: false),
                    ConhecimentoEmPython = table.Column<int>(nullable: false),
                    ConhecimentoEmRuby = table.Column<int>(nullable: false),
                    ConhecimentoEmSEO = table.Column<int>(nullable: false),
                    ConhecimentoEmSQLServer = table.Column<int>(nullable: false),
                    ConhecimentoEmSalesforce = table.Column<int>(nullable: false),
                    ConhecimentoEmWordpress = table.Column<int>(nullable: false),
                    Disponibilidade = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    HorarioDeTrabalho = table.Column<int>(nullable: false),
                    IdContaBancaria = table.Column<int>(nullable: true),
                    InformacoesBanco = table.Column<string>(nullable: true),
                    LinkCrud = table.Column<string>(nullable: false),
                    Linkedin = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    Portfolio = table.Column<string>(nullable: true),
                    PretensaoSalarial = table.Column<double>(nullable: false),
                    Skype = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidato_ContaBancaria_IdContaBancaria",
                        column: x => x.IdContaBancaria,
                        principalTable: "ContaBancaria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidato_IdContaBancaria",
                table: "Candidato",
                column: "IdContaBancaria",
                unique: true,
                filter: "[IdContaBancaria] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidato");

            migrationBuilder.DropTable(
                name: "ContaBancaria");
        }
    }
}
