using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Geophisics.Models;

public partial class Database : DbContext
{
    public Database()
    {
    }

    public Database(DbContextOptions<Database> options)
        : base(options)
    {
    }

    public virtual DbSet<Администраторы> Администраторыs { get; set; }

    public virtual DbSet<Аномалии> Аномалииs { get; set; }

    public virtual DbSet<Геофизики> Геофизикиs { get; set; }

    public virtual DbSet<Заказчики> Заказчикиs { get; set; }

    public virtual DbSet<Измерения> Измеренияs { get; set; }

    public virtual DbSet<Исследователи> Исследователиs { get; set; }

    public virtual DbSet<КоординатыПлощади> КоординатыПлощадиs { get; set; }

    public virtual DbSet<КоординатыПрофиля> КоординатыПрофиляs { get; set; }

    public virtual DbSet<Оборудования> Оборудованияs { get; set; }

    public virtual DbSet<Площади> Площадиs { get; set; }

    public virtual DbSet<Проекты> Проектыs { get; set; }

    public virtual DbSet<Профили> Профилиs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-NMFVIJJ;Database=geo;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Администраторы>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Администраторы_id_primary");

            entity.ToTable("Администраторы");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Логин)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Пароль)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Почта)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<Аномалии>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Аномалии_id_primary");

            entity.ToTable("Аномалии");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdГеофизика).HasColumnName("id геофизика");
            entity.Property(e => e.Название)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Описание)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdГеофизикаNavigation).WithMany(p => p.Аномалииs)
                .HasForeignKey(d => d.IdГеофизика)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Аномалии_id геофизика_foreign");
        });

        modelBuilder.Entity<Геофизики>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Геофизики_id_primary");

            entity.ToTable("Геофизики");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Логин)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Пароль)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<Заказчики>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Заказчики_id_primary");

            entity.ToTable("Заказчики");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Логин)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Пароль)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Почта)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<Измерения>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Измерения_id_primary");

            entity.ToTable("Измерения");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdИсследователя).HasColumnName("id исследователя");
            entity.Property(e => e.IdОборудования).HasColumnName("id оборудования");
            entity.Property(e => e.IdПрофиля).HasColumnName("id профиля");
            entity.Property(e => e.X)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("x");
            entity.Property(e => e.Y)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("y");

            entity.HasOne(d => d.IdИсследователяNavigation).WithMany(p => p.Измеренияs)
                .HasForeignKey(d => d.IdИсследователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Измерения_id исследователя_foreign");

            entity.HasOne(d => d.IdОборудованияNavigation).WithMany(p => p.Измеренияs)
                .HasForeignKey(d => d.IdОборудования)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Измерения_id оборудования_foreign");

            entity.HasOne(d => d.IdПрофиляNavigation).WithMany(p => p.Измеренияs)
                .HasForeignKey(d => d.IdПрофиля)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Измерения_id профиля_foreign");
        });

        modelBuilder.Entity<Исследователи>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Исследователи_id_primary");

            entity.ToTable("Исследователи");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Логин)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Пароль)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<КоординатыПлощади>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Координаты_площади_id_primary");

            entity.ToTable("Координаты_площади");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdПлощади).HasColumnName("id площади");
            entity.Property(e => e.X)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("x");
            entity.Property(e => e.Y)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("y");

            entity.HasOne(d => d.IdПлощадиNavigation).WithMany(p => p.КоординатыПлощадиs)
                .HasForeignKey(d => d.IdПлощади)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Координаты_площади_id площади_foreign");
        });

        modelBuilder.Entity<КоординатыПрофиля>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Координаты_профиля_id_primary");

            entity.ToTable("Координаты_профиля");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdПрофиля).HasColumnName("id профиля");
            entity.Property(e => e.X)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("x");
            entity.Property(e => e.Y)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("y");

            entity.HasOne(d => d.IdПрофиляNavigation).WithMany(p => p.КоординатыПрофиляs)
                .HasForeignKey(d => d.IdПрофиля)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Координаты_профиля_id профиля_foreign");
        });

        modelBuilder.Entity<Оборудования>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Оборудования_id_primary");

            entity.ToTable("Оборудования");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ДатаКалибровки).HasColumnName("Дата калибровки");
            entity.Property(e => e.Название)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Площади>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Площади_id_primary");

            entity.ToTable("Площади");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdПроекта).HasColumnName("id проекта");

            entity.HasOne(d => d.IdПроектаNavigation).WithMany(p => p.Площадиs)
                .HasForeignKey(d => d.IdПроекта)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Площади_id проекта_foreign");
        });

        modelBuilder.Entity<Проекты>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Проекты_id_primary");

            entity.ToTable("Проекты");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdАдминистратора).HasColumnName("id администратора");
            entity.Property(e => e.IdЗаказчика).HasColumnName("id заказчика");
            entity.Property(e => e.ДатаНачала).HasColumnName("Дата начала");
            entity.Property(e => e.ДатаОкончания).HasColumnName("Дата окончания");
            entity.Property(e => e.Название)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Описание)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdАдминистратораNavigation).WithMany(p => p.Проектыs)
                .HasForeignKey(d => d.IdАдминистратора)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Проекты_id администратора_foreign");

            entity.HasOne(d => d.IdЗаказчикаNavigation).WithMany(p => p.Проектыs)
                .HasForeignKey(d => d.IdЗаказчика)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Проекты_id заказчика_foreign");
        });

        modelBuilder.Entity<Профили>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Профили_id_primary");

            entity.ToTable("Профили");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdПлощади).HasColumnName("id площади");
            entity.Property(e => e.Направление)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdПлощадиNavigation).WithMany(p => p.Профилиs)
                .HasForeignKey(d => d.IdПлощади)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Профили_id площади_foreign");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    private static Database? instance;
    public static Database getInstance()
    {
        if (instance == null)
        {
            instance = new Database();

            instance.Администраторыs.Load();
            instance.Аномалииs.Load();
            instance.Геофизикиs.Load();
            instance.Заказчикиs.Load();
            instance.Измеренияs.Load();
            instance.Исследователиs.Load();
            instance.КоординатыПлощадиs.Load();
            instance.КоординатыПрофиляs.Load();
            instance.Оборудованияs.Load();
            instance.Площадиs.Load();
            instance.Проектыs.Load();
            instance.Профилиs.Load();

        }
        return instance;
    }
}
