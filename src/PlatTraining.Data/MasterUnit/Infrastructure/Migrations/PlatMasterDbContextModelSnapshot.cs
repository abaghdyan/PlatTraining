﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlatTraining.Data.DbContexts;

#nullable disable

namespace PlatTraining.Data.MasterUnit.Infrastructure.Migrations
{
    [DbContext(typeof(PlatMasterDbContext))]
    partial class PlatMasterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PlatTraining.Data.Entities.Master.Tenant", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Tenant");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("PlatTraining.Data.MasterUnit.Entities.TenantConnectionInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DataSource")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Encrypt")
                        .HasColumnType("bit");

                    b.Property<string>("InitialCatalog")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("TrustServerCertificate")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_TenantConnectionInfo");

                    b.HasIndex("TenantId")
                        .IsUnique();

                    b.ToTable("TenantConnectionInfo");
                });

            modelBuilder.Entity("PlatTraining.Data.MasterUnit.Entities.TenantConnectionInfo", b =>
                {
                    b.HasOne("PlatTraining.Data.Entities.Master.Tenant", "Tenant")
                        .WithOne("TenantConnectionInfo")
                        .HasForeignKey("PlatTraining.Data.MasterUnit.Entities.TenantConnectionInfo", "TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("PlatTraining.Data.Entities.Master.Tenant", b =>
                {
                    b.Navigation("TenantConnectionInfo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
