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

    public virtual DbSet<UserContact> UserContacts { get; set; }

    public virtual DbSet<UserDate> UserDates { get; set; }

    public virtual DbSet<UserNote> UserNotes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ImportantDate>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Month)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NoteContent)
                .HasMaxLength(200)
                .IsUnicode(false);
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

        modelBuilder.Entity<UserContact>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdContactNavigation).WithMany(p => p.UserContacts)
                .HasForeignKey(d => d.IdContact)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserContacts_Contacts");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserContacts)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserContacts_Users");
        });

        modelBuilder.Entity<UserDate>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdDateNavigation).WithMany(p => p.UserDates)
                .HasForeignKey(d => d.IdDate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserDates_ImportantDates");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserDates)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserDates_Users");
        });

        modelBuilder.Entity<UserNote>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNoteNavigation).WithMany(p => p.UserNotes)
                .HasForeignKey(d => d.IdNote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserNotes_Notes");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserNotes)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserNotes_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
