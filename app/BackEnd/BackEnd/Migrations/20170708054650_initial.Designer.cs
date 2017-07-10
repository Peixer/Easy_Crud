﻿// <auto-generated />
using BackEnd.Data;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BackEnd.Migrations
{
    [DbContext(typeof(CandidatoContext))]
    [Migration("20170708054650_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-preview1-24937")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEnd.Model.Candidato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cidade");

                    b.Property<int>("ConhecimentoEmAndroid");

                    b.Property<int>("ConhecimentoEmAngularJS");

                    b.Property<int>("ConhecimentoEmAspNetMvc");

                    b.Property<int>("ConhecimentoEmBoostrap");

                    b.Property<int>("ConhecimentoEmC");

                    b.Property<int>("ConhecimentoEmCPlusPlus");

                    b.Property<int>("ConhecimentoEmCake");

                    b.Property<int>("ConhecimentoEmCss");

                    b.Property<int>("ConhecimentoEmDJango");

                    b.Property<int>("ConhecimentoEmHtml");

                    b.Property<int>("ConhecimentoEmIOS");

                    b.Property<int>("ConhecimentoEmIllustrator");

                    b.Property<int>("ConhecimentoEmIonic");

                    b.Property<int>("ConhecimentoEmJQuery");

                    b.Property<int>("ConhecimentoEmJava");

                    b.Property<int>("ConhecimentoEmMajento");

                    b.Property<int>("ConhecimentoEmMySql");

                    b.Property<int>("ConhecimentoEmOutroFramework");

                    b.Property<int>("ConhecimentoEmPHP");

                    b.Property<int>("ConhecimentoEmPhotoshop");

                    b.Property<int>("ConhecimentoEmPython");

                    b.Property<int>("ConhecimentoEmRuby");

                    b.Property<int>("ConhecimentoEmSEO");

                    b.Property<int>("ConhecimentoEmSQLServer");

                    b.Property<int>("ConhecimentoEmSalesforce");

                    b.Property<int>("ConhecimentoEmWordpress");

                    b.Property<int>("Disponibilidade");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Estado");

                    b.Property<int>("HorarioDeTrabalho");

                    b.Property<int>("IdContaBancaria");

                    b.Property<string>("InformacoesBanco");

                    b.Property<string>("LinkCrud");

                    b.Property<string>("Linkedin");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Portfolio");

                    b.Property<double>("PretensaoSalarial");

                    b.Property<string>("Skype");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.HasIndex("IdContaBancaria")
                        .IsUnique();

                    b.ToTable("Candidato");
                });

            modelBuilder.Entity("BackEnd.Model.ContaBancaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Agencia");

                    b.Property<string>("Banco");

                    b.Property<string>("Cnpj");

                    b.Property<string>("Nome");

                    b.Property<int>("Numero");

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("ContaBancaria");
                });

            modelBuilder.Entity("BackEnd.Model.Candidato", b =>
                {
                    b.HasOne("BackEnd.Model.ContaBancaria", "ContaBancaria")
                        .WithOne("Candidato")
                        .HasForeignKey("BackEnd.Model.Candidato", "IdContaBancaria")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
