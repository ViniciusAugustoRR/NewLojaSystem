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

            modelBuilder.Entity("LojaSystem.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"), 1L, 1);

                    b.Property<string>("Apelido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("LojaSystem.Models.Equipamento", b =>
                {
                    b.Property<int>("IdEquipamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEquipamento"), 1L, 1);

                    b.Property<string>("Acessorios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarcaFK")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroSerie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEquipamento");

                    b.HasIndex("MarcaFK");

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

            modelBuilder.Entity("LojaSystem.Models.NivelResponsavel", b =>
                {
                    b.Property<int>("IdNivel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNivel"), 1L, 1);

                    b.Property<string>("Nivel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdNivel");

                    b.ToTable("NivelResponsaveis");
                });

            modelBuilder.Entity("LojaSystem.Models.Responsavel", b =>
                {
                    b.Property<int>("IdResponsavel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdResponsavel"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NivelResponsavelId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdResponsavel");

                    b.HasIndex("NivelResponsavelId");

                    b.ToTable("Responsaveis");
                });

            modelBuilder.Entity("LojaSystem.Models.Servico", b =>
                {
                    b.Property<int>("IdServico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServico"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipamentoServicoId")
                        .HasColumnType("int");

                    b.Property<int>("ResponsavelServicoId")
                        .HasColumnType("int");

                    b.HasKey("IdServico");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EquipamentoServicoId");

                    b.HasIndex("ResponsavelServicoId");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("LojaSystem.Models.Equipamento", b =>
                {
                    b.HasOne("LojaSystem.Models.Marca", "MarcaEquipamento")
                        .WithMany("Equipamentos")
                        .HasForeignKey("MarcaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MarcaEquipamento");
                });

            modelBuilder.Entity("LojaSystem.Models.Responsavel", b =>
                {
                    b.HasOne("LojaSystem.Models.NivelResponsavel", "NivelResponsavel")
                        .WithMany("Responsaveis")
                        .HasForeignKey("NivelResponsavelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NivelResponsavel");
                });

            modelBuilder.Entity("LojaSystem.Models.Servico", b =>
                {
                    b.HasOne("LojaSystem.Models.Cliente", "ClienteServico")
                        .WithMany("Servicos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LojaSystem.Models.Equipamento", "EquipamentoServico")
                        .WithMany("Servicos")
                        .HasForeignKey("EquipamentoServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LojaSystem.Models.Responsavel", "ResponsavelServico")
                        .WithMany("Servicos")
                        .HasForeignKey("ResponsavelServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClienteServico");

                    b.Navigation("EquipamentoServico");

                    b.Navigation("ResponsavelServico");
                });

            modelBuilder.Entity("LojaSystem.Models.Cliente", b =>
                {
                    b.Navigation("Servicos");
                });

            modelBuilder.Entity("LojaSystem.Models.Equipamento", b =>
                {
                    b.Navigation("Servicos");
                });

            modelBuilder.Entity("LojaSystem.Models.Marca", b =>
                {
                    b.Navigation("Equipamentos");
                });

            modelBuilder.Entity("LojaSystem.Models.NivelResponsavel", b =>
                {
                    b.Navigation("Responsaveis");
                });

            modelBuilder.Entity("LojaSystem.Models.Responsavel", b =>
                {
                    b.Navigation("Servicos");
                });
#pragma warning restore 612, 618
        }
    }
}
