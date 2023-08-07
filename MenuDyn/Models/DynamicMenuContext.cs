using System;
using System.Collections.Generic;
using MenuDyn.Helpers;
using Microsoft.Data.SqlClient;
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


    //Connection String Helper
   

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Submenu> Submenus { get; set; }

    public virtual DbSet<UserMenu> UserMenus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        DBHelper cnn = new();
        optionsBuilder.UseSqlServer(cnn.getDBConn());
    }
    //("Data Source=localhost;Initial Catalog=DynamicMenu;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__category__D54EE9B46543688E");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__menu__4CA0FADCACC28C35");

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
                .HasConstraintName("FK__menu__FK_menu_us__398D8EEE");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__product__47027DF54A57FA95");

            entity.ToTable("product");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
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
                        j.HasKey("ProductId", "CategoryId").HasName("PK__rel_Prod__1A56936EB9BB0FAB");
                        j.ToTable("rel_Product_Category");
                        j.IndexerProperty<int>("ProductId").HasColumnName("product_id");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("category_id");
                    });
        });

        modelBuilder.Entity<Submenu>(entity =>
        {
            entity.HasKey(e => e.SubmenuId).HasName("PK__submenu__C8A8BB92196DB8D6");

            entity.ToTable("submenu");

            entity.Property(e => e.SubmenuId).HasColumnName("submenu_id");
            entity.Property(e => e.FkMenuId).HasColumnName("FK_menu_id");
            entity.Property(e => e.SubmenuName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("submenu_name");

            entity.HasOne(d => d.FkMenu).WithMany(p => p.Submenus)
                .HasForeignKey(d => d.FkMenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__submenu__FK_menu__3C69FB99");

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
                        j.HasKey("SubmenuId", "CategoryId").HasName("PK__rel_Subm__95FC550993EBCD43");
                        j.ToTable("rel_Submenu_Category");
                        j.IndexerProperty<int>("SubmenuId").HasColumnName("submenu_id");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("category_id");
                    });
        });

        modelBuilder.Entity<UserMenu>(entity =>
        {
            entity.HasKey(e => e.UsrId).HasName("PK__userMenu__60621ABC673B29AE");

            entity.ToTable("userMenu");

            entity.Property(e => e.UsrId).HasColumnName("usr_id");
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
            entity.Property(e => e.UsrSuscription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usr_suscription");
            entity.Property(e => e.UsrTelephone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usr_telephone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
