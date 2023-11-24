using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BusinessObject.Entities;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Entities.Context
{
    public partial class DrawingOnDemandContext : DbContext
    {
        public DrawingOnDemandContext()
        {
        }

        public DrawingOnDemandContext(DbContextOptions<DrawingOnDemandContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountReview> AccountReviews { get; set; } = null!;
        public virtual DbSet<AccountRole> AccountRoles { get; set; } = null!;
        public virtual DbSet<Art> Arts { get; set; } = null!;
        public virtual DbSet<Artwork> Artworks { get; set; } = null!;
        public virtual DbSet<ArtworkReview> ArtworkReviews { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Certificate> Certificates { get; set; } = null!;
        public virtual DbSet<Discount> Discounts { get; set; } = null!;
        public virtual DbSet<HandOver> HandOvers { get; set; } = null!;
        public virtual DbSet<HandOverItem> HandOverItems { get; set; } = null!;
        public virtual DbSet<Invite> Invites { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Proposal> Proposals { get; set; } = null!;
        public virtual DbSet<Rank> Ranks { get; set; } = null!;
        public virtual DbSet<Requirement> Requirements { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<Step> Steps { get; set; } = null!;
        public virtual DbSet<Surface> Surfaces { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();

                optionsBuilder
                    .UseSqlServer(configuration.GetConnectionString("DrawingOnDemand"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.Bio).HasMaxLength(300);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("FK_Accounts_Ranks");
            });

            modelBuilder.Entity<AccountReview>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasMaxLength(300);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountReviewAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_AccountReviews_Accounts1");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AccountReviewCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_AccountReviews_Accounts");
            });

            modelBuilder.Entity<AccountRole>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AddedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountRoles)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_AccountRoles_Accounts");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AccountRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AccountRoles_Roles");
            });

            modelBuilder.Entity<Art>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Image).IsUnicode(false);

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.Arts)
                    .HasForeignKey(d => d.ArtworkId)
                    .HasConstraintName("FK_Arts_Artworks");
            });

            modelBuilder.Entity<Artwork>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Artworks_Categories");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Artworks_Accounts");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_Artworks_Materials");

                entity.HasOne(d => d.Surface)
                    .WithMany(p => p.Artworks)
                    .HasForeignKey(d => d.SurfaceId)
                    .HasConstraintName("FK_Artworks_Surfaces");
            });

            modelBuilder.Entity<ArtworkReview>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasMaxLength(300);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.ArtworkReviews)
                    .HasForeignKey(d => d.ArtworkId)
                    .HasConstraintName("FK_ArtworkReviews_Artworks");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ArtworkReviews)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_ArtworkReviews_Accounts");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AchievedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Certificates_Accounts");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HandOver>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EstimatedDeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.HandOverDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PickupAddress).HasMaxLength(200);

                entity.Property(e => e.ReceiveAddress).HasMaxLength(200);

                entity.Property(e => e.ShipmentPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.HandOvers)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_HandOvers_Orders");
            });

            modelBuilder.Entity<HandOverItem>(entity =>
            {
                entity.HasIndex(e => e.OrderDetailId, "IX_HandOverItems")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.HandOverId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.HandOver)
                    .WithMany(p => p.HandOverItems)
                    .HasForeignKey(d => d.HandOverId)
                    .HasConstraintName("FK_HandOverItems_HandOvers");

                entity.HasOne(d => d.OrderDetail)
                    .WithOne(p => p.HandOverItem)
                    .HasForeignKey<HandOverItem>(d => d.OrderDetailId)
                    .HasConstraintName("FK_HandOverItems_OrderDetails");
            });

            modelBuilder.Entity<Invite>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MeetingDate).HasColumnType("datetime");

                entity.Property(e => e.MeetingLink).IsUnicode(false);

                entity.Property(e => e.Record).IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ReceivedByNavigation)
                    .WithMany(p => p.Invites)
                    .HasForeignKey(d => d.ReceivedBy)
                    .HasConstraintName("FK_Invites_Accounts");

                entity.HasOne(d => d.Requirement)
                    .WithMany(p => p.Invites)
                    .HasForeignKey(d => d.RequirementId)
                    .HasConstraintName("FK_Invites_Requirements");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CompletedDate).HasColumnType("datetime");

                entity.Property(e => e.DepositDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK_Orders_Discounts");

                entity.HasOne(d => d.OrderedbyNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Orderedby)
                    .HasConstraintName("FK_Orders_Accounts");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ArtworkId)
                    .HasConstraintName("FK_OrderDetails_Artworks");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetails_Orders");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Signature)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TranferContent)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Payments_Orders");
            });

            modelBuilder.Entity<Proposal>(entity =>
            {
                entity.HasIndex(e => e.ArtwordId, "IX_Proposals")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "IX_Proposals_1");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Introduction).HasMaxLength(300);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Artword)
                    .WithOne(p => p.Proposal)
                    .HasForeignKey<Proposal>(d => d.ArtwordId)
                    .HasConstraintName("FK_Proposals_Artworks");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Proposals)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Proposals_Accounts");

                entity.HasOne(d => d.Requirement)
                    .WithMany(p => p.Proposals)
                    .HasForeignKey(d => d.RequirementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proposals_Requirements");
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Income).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Spend).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Requirement>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Budget).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Requirements)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Projects_Categories");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Requirements)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Projects_Accounts");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Requirements)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_Requirements_Materials");

                entity.HasOne(d => d.Surface)
                    .WithMany(p => p.Requirements)
                    .HasForeignKey(d => d.SurfaceId)
                    .HasConstraintName("FK_Requirements_Surfaces");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Artwork)
                    .WithMany(p => p.Sizes)
                    .HasForeignKey(d => d.ArtworkId)
                    .HasConstraintName("FK_Sizes_Artworks");

                entity.HasOne(d => d.Requirement)
                    .WithMany(p => p.Sizes)
                    .HasForeignKey(d => d.RequirementId)
                    .HasConstraintName("FK_Sizes_Requirements");
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CompletedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Detail).HasMaxLength(300);

                entity.Property(e => e.EstimatedEndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Requirement)
                    .WithMany(p => p.Steps)
                    .HasForeignKey(d => d.RequirementId)
                    .HasConstraintName("FK_Steps_Requirements");
            });

            modelBuilder.Entity<Surface>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
