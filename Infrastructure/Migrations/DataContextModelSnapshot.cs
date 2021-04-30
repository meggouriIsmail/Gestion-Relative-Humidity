﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Bassin", b =>
                {
                    b.Property<int>("BassinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomBassin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BassinId");

                    b.ToTable("Bassins");
                });

            modelBuilder.Entity("Core.Entities.Observateur", b =>
                {
                    b.Property<int>("ObservateurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomPrenomObservateur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StationId")
                        .HasColumnType("int");

                    b.HasKey("ObservateurId");

                    b.HasIndex("StationId");

                    b.ToTable("Observateurs");
                });

            modelBuilder.Entity("Core.Entities.RelativeHumidity", b =>
                {
                    b.Property<int>("RelativeHumidityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateObservation")
                        .HasColumnType("datetime2");

                    b.Property<int>("Heur")
                        .HasColumnType("int");

                    b.Property<float>("Hum")
                        .HasColumnType("real");

                    b.Property<float>("Mou")
                        .HasColumnType("real");

                    b.Property<int?>("ObservateurId")
                        .HasColumnType("int");

                    b.Property<float>("Sec")
                        .HasColumnType("real");

                    b.Property<int?>("StationId")
                        .HasColumnType("int");

                    b.Property<float>("ThermometreMA")
                        .HasColumnType("real");

                    b.Property<float>("ThermometreMI")
                        .HasColumnType("real");

                    b.Property<float>("ThermometreMax")
                        .HasColumnType("real");

                    b.Property<float>("ThermometreMin")
                        .HasColumnType("real");

                    b.Property<float>("ThermometreMoyMaxMin")
                        .HasColumnType("real");

                    b.HasKey("RelativeHumidityId");

                    b.HasIndex("ObservateurId");

                    b.HasIndex("StationId");

                    b.ToTable("RelativeHumiditys");
                });

            modelBuilder.Entity("Core.Entities.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BassinId")
                        .HasColumnType("int");

                    b.Property<string>("NomStation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StationId");

                    b.HasIndex("BassinId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Entities.Observateur", b =>
                {
                    b.HasOne("Core.Entities.Station", "Station")
                        .WithMany()
                        .HasForeignKey("StationId");

                    b.Navigation("Station");
                });

            modelBuilder.Entity("Core.Entities.RelativeHumidity", b =>
                {
                    b.HasOne("Core.Entities.Observateur", "Observateur")
                        .WithMany()
                        .HasForeignKey("ObservateurId");

                    b.HasOne("Core.Entities.Station", "Station")
                        .WithMany()
                        .HasForeignKey("StationId");

                    b.Navigation("Observateur");

                    b.Navigation("Station");
                });

            modelBuilder.Entity("Core.Entities.Station", b =>
                {
                    b.HasOne("Core.Entities.Bassin", "Bassin")
                        .WithMany()
                        .HasForeignKey("BassinId");

                    b.Navigation("Bassin");
                });
#pragma warning restore 612, 618
        }
    }
}
