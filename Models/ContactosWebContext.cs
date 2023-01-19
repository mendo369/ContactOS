using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppContactos.Models;

public partial class ContactosWebContext : DbContext
{
    public ContactosWebContext()
    {
    }

    public ContactosWebContext(DbContextOptions<ContactosWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ImportantDate> ImportantDates { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<User> Users { get; set; }

   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); DataBase= ContactosWeb; Trusted_Connection= True; TrustServerCertificate= True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_Contacts_Users");
        });

        modelBuilder.Entity<ImportantDate>(entity =>
        {
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Month)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.ImportantDates)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_ImportantDates_Users");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.Property(e => e.NoteContent)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Notes)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_Notes_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USUARIO__3214EC071DEAA580");

            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

       

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
