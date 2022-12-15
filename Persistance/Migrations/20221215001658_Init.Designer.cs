﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221215001658_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Persistance.CarComplectation", b =>
                {
                    b.Property<long>("CarComplectationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CarComplectationId"));

                    b.Property<long>("BodyId")
                        .HasColumnType("bigint");

                    b.Property<string>("CarCompectationCode")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("CarId")
                        .HasColumnType("bigint");

                    b.Property<int>("ComplectationNumber")
                        .HasColumnType("int");

                    b.Property<long>("Destination1DestinationId")
                        .HasColumnType("bigint");

                    b.Property<long?>("Destination2DestinationId")
                        .HasColumnType("bigint");

                    b.Property<long>("DriversPositionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("Engine1EngineId")
                        .HasColumnType("bigint");

                    b.Property<long>("GearShiftTypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("GradeId")
                        .HasColumnType("bigint");

                    b.Property<long>("NoOfDoorsId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("TransmissionId")
                        .HasColumnType("bigint");

                    b.HasKey("CarComplectationId");

                    b.HasIndex("BodyId");

                    b.HasIndex("CarCompectationCode")
                        .IsUnique();

                    b.HasIndex("CarId");

                    b.HasIndex("Destination1DestinationId");

                    b.HasIndex("Destination2DestinationId");

                    b.HasIndex("DriversPositionId");

                    b.HasIndex("Engine1EngineId");

                    b.HasIndex("GearShiftTypeId");

                    b.HasIndex("GradeId");

                    b.HasIndex("NoOfDoorsId");

                    b.HasIndex("TransmissionId");

                    b.ToTable("CarComplectations");
                });

            modelBuilder.Entity("Persistance.Entities.Car", b =>
                {
                    b.Property<long>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CarId"));

                    b.Property<string>("CarComplectationsCodes")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModelCode")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CarId");

                    b.HasIndex("ModelName", "ModelCode")
                        .IsUnique();

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Persistance.Entities.CarDetail", b =>
                {
                    b.Property<long>("CarDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CarDetailId"));

                    b.Property<string>("CarDetailCode")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(30)");

                    b.Property<long>("CarDetailSubGroupId")
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageGUID")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReplacmentCode")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TreeCode")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TreeName")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("CarDetailId");

                    b.HasIndex("CarDetailSubGroupId");

                    b.ToTable("CarDetails");
                });

            modelBuilder.Entity("Persistance.Entities.CarDetailGroup", b =>
                {
                    b.Property<long>("CarDetailGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CarDetailGroupId"));

                    b.Property<long>("CarComplectationId")
                        .HasColumnType("bigint");

                    b.Property<int>("Group")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CarDetailGroupId");

                    b.HasIndex("CarComplectationId");

                    b.ToTable("CarDetailGroups");
                });

            modelBuilder.Entity("Persistance.Entities.CarDetailSubGroup", b =>
                {
                    b.Property<long>("CarDetailSubGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CarDetailSubGroupId"));

                    b.Property<long>("CarDetailGroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("SubGroup")
                        .HasColumnType("int");

                    b.HasKey("CarDetailSubGroupId");

                    b.HasIndex("CarDetailGroupId");

                    b.ToTable("CarDetailSubGroups");
                });

            modelBuilder.Entity("Persistance.Entities.CarOptions.Body", b =>
                {
                    b.Property<long>("BodyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("BodyId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("BodyId");

                    b.ToTable("Bodies");
                });

            modelBuilder.Entity("Persistance.Entities.CarOptions.Destination", b =>
                {
                    b.Property<long>("DestinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DestinationId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DestinationId");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("Persistance.Entities.CarOptions.DriversPosition", b =>
                {
                    b.Property<long>("DriversPositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DriversPositionId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DriversPositionId");

                    b.ToTable("DriversPositions");
                });

            modelBuilder.Entity("Persistance.Entities.CarOptions.Engine", b =>
                {
                    b.Property<long>("EngineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EngineId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EngineId");

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("Persistance.Entities.CarOptions.GearShiftType", b =>
                {
                    b.Property<long>("GearShiftTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("GearShiftTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("GearShiftTypeId");

                    b.ToTable("GearShiftTypes");
                });

            modelBuilder.Entity("Persistance.Entities.CarOptions.Grade", b =>
                {
                    b.Property<long>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("GradeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("GradeId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("Persistance.Entities.CarOptions.NoOfDoors", b =>
                {
                    b.Property<long>("NoOfDoorsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("NoOfDoorsId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("NoOfDoorsId");

                    b.ToTable("NoOfDoors");
                });

            modelBuilder.Entity("Persistance.Entities.CarOptions.Transmission", b =>
                {
                    b.Property<long>("TransmissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TransmissionId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TransmissionId");

                    b.ToTable("Transmissions");
                });

            modelBuilder.Entity("Persistance.CarComplectation", b =>
                {
                    b.HasOne("Persistance.Entities.CarOptions.Body", "Body")
                        .WithMany("CarComplectations")
                        .HasForeignKey("BodyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistance.Entities.Car", "Car")
                        .WithMany("CarComplectations")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistance.Entities.CarOptions.Destination", "Destination1")
                        .WithMany("CarComplectations1")
                        .HasForeignKey("Destination1DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistance.Entities.CarOptions.Destination", "Destination2")
                        .WithMany("CarComplectations2")
                        .HasForeignKey("Destination2DestinationId");

                    b.HasOne("Persistance.Entities.CarOptions.DriversPosition", "DriversPosition")
                        .WithMany("CarComplectations")
                        .HasForeignKey("DriversPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistance.Entities.CarOptions.Engine", "Engine1")
                        .WithMany("CarComplectations")
                        .HasForeignKey("Engine1EngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistance.Entities.CarOptions.GearShiftType", "GearShiftType")
                        .WithMany("CarComplectations")
                        .HasForeignKey("GearShiftTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistance.Entities.CarOptions.Grade", "Grade")
                        .WithMany("CarComplectations")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistance.Entities.CarOptions.NoOfDoors", "NoOfDoors")
                        .WithMany("CarComplectations")
                        .HasForeignKey("NoOfDoorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistance.Entities.CarOptions.Transmission", "Transmission")
                        .WithMany("CarComplectations")
                        .HasForeignKey("TransmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Body");

                    b.Navigation("Car");

                    b.Navigation("Destination1");

                    b.Navigation("Destination2");

                    b.Navigation("DriversPosition");

                    b.Navigation("Engine1");

                    b.Navigation("GearShiftType");

                    b.Navigation("Grade");

                    b.Navigation("NoOfDoors");

                    b.Navigation("Transmission");
                });

            modelBuilder.Entity("Persistance.Entities.CarDetail", b =>
                {
                    b.HasOne("Persistance.Entities.CarDetailSubGroup", "CarDetailSubGroup")
                        .WithMany("CarDetails")
                        .HasForeignKey("CarDetailSubGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarDetailSubGroup");
                });

            modelBuilder.Entity("Persistance.Entities.CarDetailGroup", b =>
                {
                    b.HasOne("Persistance.CarComplectation", "CarComplectation")
                        .WithMany("CarDetailGroups")
                        .HasForeignKey("CarComplectationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarComplectation");
                });

            modelBuilder.Entity("Persistance.Entities.CarDetailSubGroup", b =>
                {
                    b.HasOne("Persistance.Entities.CarDetailGroup", "CarDetailGroup")
                        .WithMany("CarDetailSubGroups")
                        .HasForeignKey("CarDetailGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarDetailGroup");
                });

            modelBuilder.Entity("Persistance.CarComplectation", b =>
                {
                    b.Navigation("CarDetailGroups");
                });

            modelBuilder.Entity("Persistance.Entities.Car", b =>
                {
                    b.Navigation("CarComplectations");
                });

            modelBuilder.Entity("Persistance.Entities.CarDetailGroup", b =>
                {
                    b.Navigation("CarDetailSubGroups");
                });

            modelBuilder.Entity("Persistance.Entities.CarDetailSubGroup", b =>
                {
                    b.Navigation("CarDetails");
                });

            modelBuilder.Entity("Persistance.Entities.CarOptions.Body", b =>
                {
                    b.Navigation("CarComplectations");
                });

            modelBuilder.Entity("Persistance.Entities.CarOptions.Destination", b =>
                {
                    b.Navigation("CarComplectations1");

                    b.Navigation("CarComplectations2");
                });

            modelBuilder.Entity("Persistance.Entities.CarOptions.DriversPosition", b =>
                {
                    b.Navigation("CarComplectations");
                });

            modelBuilder.Entity("Persistance.Entities.CarOptions.Engine", b =>
                {
                    b.Navigation("CarComplectations");
                });

            modelBuilder.Entity("Persistance.Entities.CarOptions.GearShiftType", b =>
                {
                    b.Navigation("CarComplectations");
                });

            modelBuilder.Entity("Persistance.Entities.CarOptions.Grade", b =>
                {
                    b.Navigation("CarComplectations");
                });

            modelBuilder.Entity("Persistance.Entities.CarOptions.NoOfDoors", b =>
                {
                    b.Navigation("CarComplectations");
                });

            modelBuilder.Entity("Persistance.Entities.CarOptions.Transmission", b =>
                {
                    b.Navigation("CarComplectations");
                });
#pragma warning restore 612, 618
        }
    }
}
