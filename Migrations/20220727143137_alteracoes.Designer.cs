﻿// <auto-generated />
using System;
using LojaSystem.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LojaSystem.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20220727143137_alteracoes")]
    partial class alteracoes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LojaSystem.Models.Equipamento", b =>
                {
                    b.Property<int>("IdEquipamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEquipamento"), 1L, 1);

                    b.Property<string>("Acessorios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MarcaEquipamentoIdMarca")
                        .HasColumnType("int");

                    b.Property<int>("MarcaFK")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroSerie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEquipamento");

                    b.HasIndex("MarcaEquipamentoIdMarca");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("LojaSystem.Models.Marca", b =>
                {
                    b.Property<int>("IdMarca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMarca"), 1L, 1);

                    b.Property<string>("NomeMarca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMarca");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("LojaSystem.Models.Equipamento", b =>
                {
                    b.HasOne("LojaSystem.Models.Marca", "MarcaEquipamento")
                        .WithMany("Equipamentos")
                        .HasForeignKey("MarcaEquipamentoIdMarca");

                    b.Navigation("MarcaEquipamento");
                });

            modelBuilder.Entity("LojaSystem.Models.Marca", b =>
                {
                    b.Navigation("Equipamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
