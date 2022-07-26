﻿using LojaSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaSystem.DB
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {}
        
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<NivelResponsavel> NivelResponsaveis { get; set; }
        public DbSet<Responsavel> Responsaveis{ get; set; }
        public DbSet<Servico>? Servico { get; set; }

    }
}
