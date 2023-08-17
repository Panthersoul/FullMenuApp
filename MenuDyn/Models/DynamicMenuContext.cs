using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MenuDyn.Models;

public partial class DynamicMenuContext : DbContext
{
    public DynamicMenuContext()
    {
    }

    public DynamicMenuContext(DbContextOptions<DynamicMenuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Submenu> Submenus { get; set; }

    public virtual DbSet<Suscription> Suscriptions { get; set; }

    public virtual DbSet<SuscriptionsType> SuscriptionsType { get; set; }

    public virtual DbSet<UserMenu> UserMenus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DynamicMenu;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__category__D54EE9B4C114FBA8");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryActive).HasColumnName("category_active");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__menu__4CA0FADC38F12E2A");

            entity.ToTable("menu");

            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.FkMenuUser).HasColumnName("FK_menu_user");
            entity.Property(e => e.MenuActive).HasColumnName("menu_active");
            entity.Property(e => e.MenuAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("menu_address");
            entity.Property(e => e.MenuBarName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("menu_barName");
            entity.Property(e => e.MenuEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("menu_email");
            entity.Property(e => e.MenuLogo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("menu_logo");
            entity.Property(e => e.MenuObs)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("menu_obs");
            entity.Property(e => e.MenuSocial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("menu_social");
            entity.Property(e => e.MenuTelephone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("menu_telephone");

            entity.HasOne(d => d.FkMenuUserNavigation).WithMany(p => p.Menus)
                .HasForeignKey(d => d.FkMenuUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__menu__FK_menu_us__1DB06A4F");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__product__47027DF5383EBD05");

            entity.ToTable("product");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductActive).HasColumnName("product_active");
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("product_description");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductOffers)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product_offers");
            entity.Property(e => e.ProductPicture)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product_picture");
            entity.Property(e => e.ProductPrice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product_price");

            entity.HasMany(d => d.Categories).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "RelProductCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_category_prod"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_product_cat"),
                    j =>
                    {
                        j.HasKey("ProductId", "CategoryId").HasName("PK__rel_Prod__1A56936E2F01E5FB");
                        j.ToTable("rel_Product_Category");
                        j.IndexerProperty<int>("ProductId").HasColumnName("product_id");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("category_id");
                    });
        });

        modelBuilder.Entity<Submenu>(entity =>
        {
            entity.HasKey(e => e.SubmenuId).HasName("PK__submenu__C8A8BB925CE652F8");

            entity.ToTable("submenu");

            entity.Property(e => e.SubmenuId).HasColumnName("submenu_id");
            entity.Property(e => e.FkMenuId).HasColumnName("FK_menu_id");
            entity.Property(e => e.SubmenuActive).HasColumnName("submenu_active");
            entity.Property(e => e.SubmenuName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("submenu_name");

            entity.HasOne(d => d.FkMenu).WithMany(p => p.Submenus)
                .HasForeignKey(d => d.FkMenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__submenu__FK_menu__208CD6FA");

            entity.HasMany(d => d.Categories).WithMany(p => p.Submenus)
                .UsingEntity<Dictionary<string, object>>(
                    "RelSubmenuCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_category_sub"),
                    l => l.HasOne<Submenu>().WithMany()
                        .HasForeignKey("SubmenuId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_submenu_cat"),
                    j =>
                    {
                        j.HasKey("SubmenuId", "CategoryId").HasName("PK__rel_Subm__95FC55095CE26E61");
                        j.ToTable("rel_Submenu_Category");
                        j.IndexerProperty<int>("SubmenuId").HasColumnName("submenu_id");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("category_id");
                    });
        });

        modelBuilder.Entity<Suscription>(entity =>
        {
            entity.HasKey(e => e.SuscriptionId).HasName("PK__suscript__68365239593DE963");

            entity.ToTable("suscription");

            entity.Property(e => e.SuscriptionId).HasColumnName("suscription_id");
            entity.Property(e => e.SuscriptionActive).HasColumnName("suscription_active");
            entity.Property(e => e.SuscriptionDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("suscription_description");
            entity.Property(e => e.SuscriptionEndDate)
                .HasColumnType("datetime")
                .HasColumnName("suscription_end_date");
            entity.Property(e => e.SuscriptionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("suscription_name");
            entity.Property(e => e.SuscriptionPrice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("suscription_price");
            entity.Property(e => e.SuscriptionStartDate)
                .HasColumnType("datetime")
                .HasColumnName("suscription_start_date");
            entity.Property(e => e.SuscriptionType).HasColumnName("suscription_type");

            entity.HasOne(d => d.SuscriptionTypeNavigation).WithMany(p => p.Suscriptions)
                .HasForeignKey(d => d.SuscriptionType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__suscripti__suscr__17F790F9");
        });

        modelBuilder.Entity<SuscriptionsType>(entity =>
        {
            entity.HasKey(e => e.SuscriptionId).HasName("PK__suscript__68365239587C260A");

            entity.ToTable("suscriptions_types");

            entity.Property(e => e.SuscriptionId).HasColumnName("suscription_id");
            entity.Property(e => e.SuscriptionActive).HasColumnName("suscription_active");
            entity.Property(e => e.SuscriptionDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("suscription_description");
            entity.Property(e => e.SuscriptionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("suscription_name");
            entity.Property(e => e.SuscriptionPrice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("suscription_price");
            entity.Property(e => e.SuscriptionType).HasColumnName("suscription_type");
        });

        modelBuilder.Entity<UserMenu>(entity =>
        {
            entity.HasKey(e => e.UsrId).HasName("PK__userMenu__60621ABC923AD11B");

            entity.ToTable("userMenu");

            entity.Property(e => e.UsrId).HasColumnName("usr_id");
            entity.Property(e => e.UsrActive).HasColumnName("usr_active");
            entity.Property(e => e.UsrAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usr_address");
            entity.Property(e => e.UsrBirthdate)
                .HasColumnType("datetime")
                .HasColumnName("usr_birthdate");
            entity.Property(e => e.UsrEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usr_email");
            entity.Property(e => e.UsrEnterpriseName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usr_enterpriseName");
            entity.Property(e => e.UsrFairyName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usr_fairyName");
            entity.Property(e => e.UsrName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usr_name");
            entity.Property(e => e.UsrProfilePic)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usr_profilePic");
            entity.Property(e => e.UsrRut)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usr_rut");
            entity.Property(e => e.UsrSurname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usr_surname");
            entity.Property(e => e.UsrSuscription).HasColumnName("usr_suscription");
            entity.Property(e => e.UsrTelephone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usr_telephone");
            entity.Property(e => e.UsrToken)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usr_token");

            entity.HasOne(d => d.UsrSuscriptionNavigation).WithMany(p => p.UserMenus)
                .HasForeignKey(d => d.UsrSuscription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usr_suscrip");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
