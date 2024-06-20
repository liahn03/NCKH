using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DocumentSharing.Models;

public partial class DocumentSharingContext : DbContext {
    public DocumentSharingContext() {

    }

    public DocumentSharingContext(DbContextOptions<DocumentSharingContext> options) : base(options) {

    }

    public virtual DbSet<AppRole> AppRoles { get; set; }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Credit> Credits { get; set; }

    public virtual DbSet<Curriculum> Curricula { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__AppRole__8AFACE1A58C9EED4");

            entity.ToTable("AppRole");

            entity.Property(e => e.RoleId).HasMaxLength(10);
            entity.Property(e => e.RoleName).HasMaxLength(15);
        });

        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__AppUser__1788CC4CD35EDBD8");

            entity.ToTable("AppUser");

            entity.Property(e => e.UserId).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasMaxLength(10);
            entity.Property(e => e.UserPassword).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(20);

            entity.HasOne(d => d.Role).WithMany(p => p.AppUsers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__AppUser__RoleId__398D8EEE");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comment__C3B4DFCAEC9487B5");

            entity.ToTable("Comment");

            entity.Property(e => e.CommentId).HasMaxLength(10);
            entity.Property(e => e.CommentContent).HasColumnType("text");
            entity.Property(e => e.CreatedDate).HasColumnType("date");
            entity.Property(e => e.ParentCommentId).HasMaxLength(10);
            entity.Property(e => e.PostId).HasMaxLength(10);
            entity.Property(e => e.UserId).HasMaxLength(20);

            entity.HasOne(d => d.ParentComment).WithMany(p => p.InverseParentComment)
                .HasForeignKey(d => d.ParentCommentId)
                .HasConstraintName("FK__Comment__ParentC__5535A963");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__Comment__PostId__5441852A");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Comment__UserId__534D60F1");
        });

        modelBuilder.Entity<Credit>(entity =>
        {
            entity.HasKey(e => new { e.SubjectId, e.CurriId }).HasName("PK__Credit__821DD117EC118AED");

            entity.ToTable("Credit");

            entity.Property(e => e.SubjectId).HasMaxLength(10);
            entity.Property(e => e.CurriId).HasMaxLength(10);

            entity.HasOne(d => d.Curri).WithMany(p => p.Credits)
                .HasForeignKey(d => d.CurriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Credit__CurriId__440B1D61");

            entity.HasOne(d => d.Subject).WithMany(p => p.Credits)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Credit__SubjectI__4316F928");
        });

        modelBuilder.Entity<Curriculum>(entity =>
        {
            entity.HasKey(e => e.CurriId).HasName("PK__Curricul__E0672BF329AC6305");

            entity.ToTable("Curriculum");

            entity.Property(e => e.CurriId).HasMaxLength(10);
            entity.Property(e => e.CurriYear).HasMaxLength(15);
            entity.Property(e => e.DepartId).HasMaxLength(10);

            entity.HasOne(d => d.Depart).WithMany(p => p.Curricula)
                .HasForeignKey(d => d.DepartId)
                .HasConstraintName("FK__Curriculu__Depar__3E52440B");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartId).HasName("PK__Departme__0E53E1F59B024401");

            entity.ToTable("Department");

            entity.Property(e => e.DepartId).HasMaxLength(10);
            entity.Property(e => e.DepartName).HasMaxLength(30);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocId).HasName("PK__Document__3EF188AD68556391");

            entity.ToTable("Document");

            entity.Property(e => e.DocId).HasMaxLength(10);
            entity.Property(e => e.DocCategory).HasMaxLength(30);
            entity.Property(e => e.DocName).HasMaxLength(200);
            entity.Property(e => e.DocUrl).HasMaxLength(300);
            entity.Property(e => e.SubjectId).HasMaxLength(10);
            entity.Property(e => e.UserId).HasMaxLength(20);

            entity.HasOne(d => d.Subject).WithMany(p => p.Documents)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Document__Subjec__46E78A0C");

            entity.HasOne(d => d.User).WithMany(p => p.Documents)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Document__UserId__47DBAE45");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Post__AA126018CE76F3BC");

            entity.ToTable("Post");

            entity.Property(e => e.PostId).HasMaxLength(10);
            entity.Property(e => e.CreatedDate).HasColumnType("date");
            entity.Property(e => e.PostContent).HasColumnType("text");
            entity.Property(e => e.PublishedDate).HasColumnType("date");
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.UserId).HasMaxLength(20);

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Post__UserId__4CA06362");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subject__AC1BA3A8CF35802F");

            entity.ToTable("Subject");

            entity.Property(e => e.SubjectId).HasMaxLength(10);
            entity.Property(e => e.SubCategory).HasMaxLength(50);
            entity.Property(e => e.SubjectName).HasMaxLength(50);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__Tag__657CF9ACD1708D67");

            entity.ToTable("Tag");

            entity.Property(e => e.TagId).HasMaxLength(10);
            entity.Property(e => e.TagName).HasMaxLength(10);

            entity.HasMany(d => d.Posts).WithMany(p => p.Tags)
                .UsingEntity<Dictionary<string, object>>(
                    "PostTag",
                    r => r.HasOne<Post>().WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PostTags__PostId__5070F446"),
                    l => l.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PostTags__TagId__4F7CD00D"),
                    j =>
                    {
                        j.HasKey("TagId", "PostId").HasName("PK__PostTags__FFDDDFADC857A716");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
