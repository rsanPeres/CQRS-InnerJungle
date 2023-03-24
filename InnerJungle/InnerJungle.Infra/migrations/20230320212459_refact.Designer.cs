﻿// <auto-generated />
using System;
using InnerJungle.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InnerJungle.Infra.migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230320212459_refact")]
    partial class refact
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InnerJungle.Domain.Entities.ElectrochemicalExperiment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("ResearchId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResearchId");

                    b.ToTable("Electrochemical_Experiment", (string)null);
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.Eletrode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid?>("ExperimentBaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ExperimentBaseId");

                    b.ToTable("Eletrode", (string)null);
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.ExperimentBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MicroorganismId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ResearchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("MicroorganismId");

                    b.HasIndex("ResearchId");

                    b.ToTable("Experiment", (string)null);
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.Institution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Institution", (string)null);
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.MicroorganismBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Phatogenicity")
                        .HasColumnType("int");

                    b.Property<Guid?>("ResearchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("StrainId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Virulence")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResearchId");

                    b.HasIndex("StrainId");

                    b.ToTable("Microorganism", (string)null);
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.Nanomaterial", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ExperimentBaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nanomaterials")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Polimer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResearchId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ExperimentBaseId");

                    b.HasIndex("ResearchId");

                    b.ToTable("Nanomaterial", (string)null);
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.Research", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CalibrationCurveId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<Guid>("EletrodeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InstitutionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CalibrationCurveId");

                    b.HasIndex("EletrodeId");

                    b.HasIndex("InstitutionId");

                    b.HasIndex("UserId");

                    b.ToTable("Research", (string)null);
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.Strain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("datetime2");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Dilution")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GrowthMedium")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("GrowthTemperature")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StorageTemperature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Strain");
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.CalibrationCurve", b =>
                {
                    b.HasBaseType("InnerJungle.Domain.Entities.ElectrochemicalExperiment");

                    b.ToTable("Calibration_Curve", (string)null);
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.ElectrochemicalExperiment", b =>
                {
                    b.HasOne("InnerJungle.Domain.Entities.Research", null)
                        .WithMany("ElectrochemicalExperiments")
                        .HasForeignKey("ResearchId");
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.Eletrode", b =>
                {
                    b.HasOne("InnerJungle.Domain.Entities.ExperimentBase", null)
                        .WithMany("Eletrodes")
                        .HasForeignKey("ExperimentBaseId");
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.ExperimentBase", b =>
                {
                    b.HasOne("InnerJungle.Domain.Entities.MicroorganismBase", "Microorganism")
                        .WithMany()
                        .HasForeignKey("MicroorganismId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InnerJungle.Domain.Entities.Research", null)
                        .WithMany("Experiments")
                        .HasForeignKey("ResearchId");

                    b.Navigation("Microorganism");
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.MicroorganismBase", b =>
                {
                    b.HasOne("InnerJungle.Domain.Entities.Research", null)
                        .WithMany("Microorganism")
                        .HasForeignKey("ResearchId");

                    b.HasOne("InnerJungle.Domain.Entities.Strain", "Strain")
                        .WithMany()
                        .HasForeignKey("StrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Strain");
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.Nanomaterial", b =>
                {
                    b.HasOne("InnerJungle.Domain.Entities.ExperimentBase", null)
                        .WithMany("Nanomaterials")
                        .HasForeignKey("ExperimentBaseId");

                    b.HasOne("InnerJungle.Domain.Entities.Research", null)
                        .WithMany("Nanomaterials")
                        .HasForeignKey("ResearchId");
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.Research", b =>
                {
                    b.HasOne("InnerJungle.Domain.Entities.CalibrationCurve", "CalibrationCurve")
                        .WithMany()
                        .HasForeignKey("CalibrationCurveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InnerJungle.Domain.Entities.Eletrode", "Eletrode")
                        .WithMany()
                        .HasForeignKey("EletrodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InnerJungle.Domain.Entities.Institution", "Institution")
                        .WithMany("Researches")
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InnerJungle.Domain.Entities.User", "User")
                        .WithMany("Researches")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CalibrationCurve");

                    b.Navigation("Eletrode");

                    b.Navigation("Institution");

                    b.Navigation("User");
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.CalibrationCurve", b =>
                {
                    b.HasOne("InnerJungle.Domain.Entities.ElectrochemicalExperiment", null)
                        .WithOne()
                        .HasForeignKey("InnerJungle.Domain.Entities.CalibrationCurve", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.ExperimentBase", b =>
                {
                    b.Navigation("Eletrodes");

                    b.Navigation("Nanomaterials");
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.Institution", b =>
                {
                    b.Navigation("Researches");
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.Research", b =>
                {
                    b.Navigation("ElectrochemicalExperiments");

                    b.Navigation("Experiments");

                    b.Navigation("Microorganism");

                    b.Navigation("Nanomaterials");
                });

            modelBuilder.Entity("InnerJungle.Domain.Entities.User", b =>
                {
                    b.Navigation("Researches");
                });
#pragma warning restore 612, 618
        }
    }
}