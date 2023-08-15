using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Calc.Models;

public partial class CalculationHistoryDbContext : DbContext
{
    public CalculationHistoryDbContext()
    {
    }

    public CalculationHistoryDbContext(DbContextOptions<CalculationHistoryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CalculationHistory> CalculationHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\OnurDB;Database=CalculationHistoryDB;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalculationHistory>(entity =>
        {
            entity.HasKey(e => e.CalculationId);

            entity.ToTable("CalculationHistory");

            entity.Property(e => e.CalculationId).HasColumnName("CalculationID");
            entity.Property(e => e.A).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.B).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Operation).HasMaxLength(10);
            entity.Property(e => e.Result).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
