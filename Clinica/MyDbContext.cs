using System;
using System.Collections.Generic;
using Clinica.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinica;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public DbSet<tPaciente> tPaciente { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.56.101;user id=web;password=CXtz4ff#;database=DADOS_CLINICA", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<Clinica.Models.tFuncionarios> tFuncionarios { get; set; } = default!;

    public DbSet<Clinica.Models.tEspecialidade> tEspecialidade { get; set; } = default!;
}
