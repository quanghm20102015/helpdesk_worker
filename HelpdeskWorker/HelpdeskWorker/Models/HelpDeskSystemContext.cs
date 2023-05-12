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

    public virtual DbSet<Company> Companys { get; set; }

    public virtual DbSet<ConfigMail> ConfigMails { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactLabel> ContactLabels { get; set; }

    public virtual DbSet<ContactNote> ContactNotes { get; set; }

    public virtual DbSet<Country> Countrys { get; set; }

    public virtual DbSet<Csat> Csats { get; set; }

    public virtual DbSet<EmailInfo> EmailInfos { get; set; }

    public virtual DbSet<EmailInfoAssign> EmailInfoAssigns { get; set; }

    public virtual DbSet<EmailInfoFollow> EmailInfoFollows { get; set; }

    public virtual DbSet<EmailInfoLabel> EmailInfoLabels { get; set; }

    public virtual DbSet<History> Historys { get; set; }

    public virtual DbSet<Label> Labels { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamAgent> TeamAgents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=103.63.109.82;Database=HelpDeskSystem;Port=5432;User Id=postgres;Password=Ab@123465;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Company).HasColumnName("company");
            entity.Property(e => e.Confirm).HasColumnName("confirm");
            entity.Property(e => e.Fullname).HasColumnName("fullname");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdGuId).HasColumnName("idGuId");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("1")
                .HasColumnName("status");
            entity.Property(e => e.Workemail).HasColumnName("workemail");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyName).HasColumnName("companyName");
        });

        modelBuilder.Entity<ConfigMail>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
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
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdLabel).HasColumnName("idLabel");
            entity.Property(e => e.Linkedin).HasColumnName("linkedin");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.Twitter).HasColumnName("twitter");
        });

        modelBuilder.Entity<ContactLabel>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdContact).HasColumnName("idContact");
            entity.Property(e => e.IdLabel).HasColumnName("idLabel");
        });

        modelBuilder.Entity<ContactNote>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdContact).HasColumnName("idContact");
            entity.Property(e => e.Note).HasColumnName("note");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Csat>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DescriptionFeedBack).HasColumnName("descriptionFeedBack");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdFeedBack).HasColumnName("idFeedBack");
            entity.Property(e => e.IdGuIdEmailInfo)
                .HasDefaultValueSql("''::text")
                .HasColumnName("idGuIdEmailInfo");
        });

        modelBuilder.Entity<EmailInfo>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Assign).HasColumnName("assign");
            entity.Property(e => e.Bcc).HasColumnName("bcc");
            entity.Property(e => e.Cc).HasColumnName("cc");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.From).HasColumnName("from");
            entity.Property(e => e.FromName).HasColumnName("fromName");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdConfigEmail).HasColumnName("idConfigEmail");
            entity.Property(e => e.IdGuId).HasColumnName("idGuId");
            entity.Property(e => e.IdLabel).HasColumnName("idLabel");
            entity.Property(e => e.MessageId).HasColumnName("messageId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Subject).HasColumnName("subject");
            entity.Property(e => e.TextBody).HasColumnName("textBody");
            entity.Property(e => e.To).HasColumnName("to");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<EmailInfoAssign>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEmailInfo).HasColumnName("idEmailInfo");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
        });

        modelBuilder.Entity<EmailInfoFollow>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEmailInfo).HasColumnName("idEmailInfo");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
        });

        modelBuilder.Entity<EmailInfoLabel>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdEmailInfo).HasColumnName("idEmailInfo");
            entity.Property(e => e.IdLabel).HasColumnName("idLabel");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.FullName).HasColumnName("fullName");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.IdDetail).HasColumnName("idDetail");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<Label>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Color).HasColumnName("color");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName).HasColumnName("statusName");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdCompany).HasColumnName("idCompany");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<TeamAgent>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdAgent).HasColumnName("idAgent");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
