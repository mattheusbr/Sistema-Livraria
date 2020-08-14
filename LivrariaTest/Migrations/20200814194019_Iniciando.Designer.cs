﻿// <auto-generated />
using System;
using LivrariaTest.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LivrariaTest.Migrations
{
    [DbContext(typeof(ContextDataBase))]
    [Migration("20200814194019_Iniciando")]
    partial class Iniciando
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LivrariaTest.Models.Autor", b =>
                {
                    b.Property<int>("IdAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("IdAutor");

                    b.ToTable("Mt_Autor");
                });

            modelBuilder.Entity("LivrariaTest.Models.Editora", b =>
                {
                    b.Property<int>("IdEditora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("IdEditora");

                    b.ToTable("Mt_Editora");
                });

            modelBuilder.Entity("LivrariaTest.Models.Livros", b =>
                {
                    b.Property<int>("IdLivro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Autor")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(700)")
                        .HasMaxLength(700);

                    b.Property<int>("IdEditora")
                        .HasColumnType("int");

                    b.Property<int?>("Mt_Autor")
                        .HasColumnType("int");

                    b.Property<int?>("Mt_Editora")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("IdLivro");

                    b.HasIndex("Mt_Autor");

                    b.HasIndex("Mt_Editora");

                    b.ToTable("Mt_Livros");
                });

            modelBuilder.Entity("LivrariaTest.Models.Livros", b =>
                {
                    b.HasOne("LivrariaTest.Models.Autor", "IdAutor")
                        .WithMany("Livros")
                        .HasForeignKey("Mt_Autor");

                    b.HasOne("LivrariaTest.Models.Editora", "Editora")
                        .WithMany("Livros")
                        .HasForeignKey("Mt_Editora");
                });
#pragma warning restore 612, 618
        }
    }
}
