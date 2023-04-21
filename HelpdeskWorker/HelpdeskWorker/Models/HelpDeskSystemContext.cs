using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskWorker.Models;

public partial class HelpDeskSystemContext : DbContext
{
    public HelpDeskSystemContext()
    {
    }

    public HelpDeskSystemContext(DbContextOptions<HelpDeskSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<ConfigMail> ConfigMails { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Country> Countrys { get; set; }

    public virtual DbSet<EmailInfo> EmailInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=103.63.109.82;Database=HelpDeskSystem;Port=5432;User Id=postgres;Password=Ab@123465;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Company).HasColumnName("company");
            entity.Property(e => e.Fullname).HasColumnName("fullname");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Workemail).HasColumnName("workemail");
        });

        modelBuilder.Entity<ConfigMail>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Incoming).HasColumnName("incoming");
            entity.Property(e => e.IncomingPort).HasColumnName("incomingPort");
            entity.Property(e => e.Outgoing).HasColumnName("outgoing");
            entity.Property(e => e.OutgoingPort).HasColumnName("outgoingPort");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.YourName).HasColumnName("yourName");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bio).HasColumnName("bio");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.Company).HasColumnName("company");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Facebook).HasColumnName("facebook");
            entity.Property(e => e.Fullname).HasColumnName("fullname");
            entity.Property(e => e.Github).HasColumnName("github");
            entity.Property(e => e.Linkedin).HasColumnName("linkedin");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.Twitter).HasColumnName("twitter");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<EmailInfo>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bcc).HasColumnName("bcc");
            entity.Property(e => e.Cc).HasColumnName("cc");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.From).HasColumnName("from");
            entity.Property(e => e.FromName).HasColumnName("fromName");
            entity.Property(e => e.IdConfigEmail).HasColumnName("idConfigEmail");
            entity.Property(e => e.MessageId)
                .HasDefaultValueSql("''::text")
                .HasColumnName("messageId");
            entity.Property(e => e.Subject).HasColumnName("subject");
            entity.Property(e => e.TextBody).HasColumnName("textBody");
            entity.Property(e => e.To).HasColumnName("to");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
