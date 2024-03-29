﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherApp.Business.Data;

#nullable disable

namespace WeatherApp.Business.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220704033854_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WeatherApp.Business.Models.Humidity", b =>
                {
                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Measure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TimeStamp");

                    b.HasIndex("TimeStamp")
                        .IsUnique();

                    b.ToTable("Humidity");
                });

            modelBuilder.Entity("WeatherApp.Business.Models.Rainfall", b =>
                {
                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Measure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TimeStamp");

                    b.HasIndex("TimeStamp")
                        .IsUnique();

                    b.ToTable("Rainfall");
                });

            modelBuilder.Entity("WeatherApp.Business.Models.Temperature", b =>
                {
                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Measure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TimeStamp");

                    b.HasIndex("TimeStamp")
                        .IsUnique();

                    b.ToTable("Temperatures");
                });

            modelBuilder.Entity("WeatherApp.Business.Models.Weather", b =>
                {
                    b.Property<string>("Humidity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("humidity");

                    b.Property<string>("Rainfall")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("rainfall");

                    b.Property<string>("Temperature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("temperature");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2")
                        .HasColumnName("timestamp");

                    b.ToView("vw_weather");
                });
#pragma warning restore 612, 618
        }
    }
}
