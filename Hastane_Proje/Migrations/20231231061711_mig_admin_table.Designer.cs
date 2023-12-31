﻿// <auto-generated />
using System;
using Hastane_Proje.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hastane_Proje.Migrations
{
    [DbContext(typeof(HastaneContext))]
    [Migration("20231231061711_mig_admin_table")]
    partial class mig_admin_table
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hastane_Proje.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

                    b.Property<string>("AdmiUserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AdminRole")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Hastane_Proje.Models.Doktor", b =>
                {
                    b.Property<int>("DoktorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoktorID"));

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("DogumYeri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PoliklinikID")
                        .HasColumnType("int");

                    b.HasKey("DoktorID");

                    b.HasIndex("PoliklinikID");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("Hastane_Proje.Models.Poliklinik", b =>
                {
                    b.Property<int>("PoliklinikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PoliklinikID"));

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoliklinikAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TedaviAlani")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PoliklinikID");

                    b.ToTable("Poliklinikler");
                });

            modelBuilder.Entity("Hastane_Proje.Models.Randevu", b =>
                {
                    b.Property<int>("RandevuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RandevuID"));

                    b.Property<int>("DoktorID")
                        .HasColumnType("int");

                    b.Property<int>("hastaUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("randevuTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("RandevuID");

                    b.HasIndex("DoktorID");

                    b.HasIndex("hastaUserID");

                    b.ToTable("Randevu");
                });

            modelBuilder.Entity("Hastane_Proje.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("eposta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("isim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kullaniciSifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("soyisim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tcNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Kullanıcılar");
                });

            modelBuilder.Entity("Hastane_Proje.Models.Doktor", b =>
                {
                    b.HasOne("Hastane_Proje.Models.Poliklinik", "Poliklinik")
                        .WithMany("Doktorlar")
                        .HasForeignKey("PoliklinikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poliklinik");
                });

            modelBuilder.Entity("Hastane_Proje.Models.Randevu", b =>
                {
                    b.HasOne("Hastane_Proje.Models.Doktor", "doktor")
                        .WithMany("randevular")
                        .HasForeignKey("DoktorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hastane_Proje.Models.User", "hasta")
                        .WithMany("randevular")
                        .HasForeignKey("hastaUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("doktor");

                    b.Navigation("hasta");
                });

            modelBuilder.Entity("Hastane_Proje.Models.Doktor", b =>
                {
                    b.Navigation("randevular");
                });

            modelBuilder.Entity("Hastane_Proje.Models.Poliklinik", b =>
                {
                    b.Navigation("Doktorlar");
                });

            modelBuilder.Entity("Hastane_Proje.Models.User", b =>
                {
                    b.Navigation("randevular");
                });
#pragma warning restore 612, 618
        }
    }
}
