﻿// <auto-generated />
using System;
using LojaSystem.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LojaSystem.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LojaSystem.Models.ClienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

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

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroSerie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEquipamento");

                    b.HasIndex("MarcaEquipamentoIdMarca");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("LojaSystem.Models.MarcaModel", b =>
                {
                    b.Property<int>("IdMarca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMarca"), 1L, 1);

                    b.Property<string>("NomeMarca")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMarca");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("LojaSystem.Models.ResponsavelModel", b =>
                {
                    b.Property<int>("IdResponsavel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdResponsavel"), 1L, 1);

                    b.Property<string>("CategoriaResponsavel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameResponsavel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdResponsavel");

                    b.ToTable("Responsaveis");
                });

            modelBuilder.Entity("LojaSystem.Models.ServicoModel", b =>
                {
                    b.Property<int>("IdServico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServico"), 1L, 1);

                    b.Property<int?>("ClienteServicoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EquipamentoServiceIdEquipamento")
                        .HasColumnType("int");

                    b.Property<int?>("ResponsavelServicoIdResponsavel")
                        .HasColumnType("int");

                    b.HasKey("IdServico");

                    b.HasIndex("ClienteServicoId");

                    b.HasIndex("EquipamentoServiceIdEquipamento");

                    b.HasIndex("ResponsavelServicoIdResponsavel");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("LojaSystem.Models.Equipamento", b =>
                {
                    b.HasOne("LojaSystem.Models.MarcaModel", "MarcaEquipamento")
                        .WithMany()
                        .HasForeignKey("MarcaEquipamentoIdMarca");

                    b.Navigation("MarcaEquipamento");
                });

            modelBuilder.Entity("LojaSystem.Models.ServicoModel", b =>
                {
                    b.HasOne("LojaSystem.Models.ClienteModel", "ClienteServico")
                        .WithMany()
                        .HasForeignKey("ClienteServicoId");

                    b.HasOne("LojaSystem.Models.Equipamento", "EquipamentoService")
                        .WithMany()
                        .HasForeignKey("EquipamentoServiceIdEquipamento");

                    b.HasOne("LojaSystem.Models.ResponsavelModel", "ResponsavelServico")
                        .WithMany()
                        .HasForeignKey("ResponsavelServicoIdResponsavel");

                    b.Navigation("ClienteServico");

                    b.Navigation("EquipamentoService");

                    b.Navigation("ResponsavelServico");
                });
#pragma warning restore 612, 618
        }
    }
}
