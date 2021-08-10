﻿// <auto-generated />
using System;
using FormatChanger.ContextData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FormatChanger.Migrations
{
    [DbContext(typeof(ContextSets))]
    [Migration("20210728235409_AddDelimiterToFormat")]
    partial class AddDelimiterToFormat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("FormatChanger.Model.FieldFormat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DefaultValue")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FatherId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Length")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<char?>("PaddingChar")
                        .HasColumnType("TEXT");

                    b.Property<int>("Position")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StringFormatter")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FatherId");

                    b.ToTable("FieldFormats");
                });

            modelBuilder.Entity("FormatChanger.Model.Format", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<char?>("Delimiter")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Formats");
                });

            modelBuilder.Entity("FormatChanger.Model.FormatMappedField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FatherId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FieldFromId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FieldToId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FatherId");

                    b.HasIndex("FieldFromId");

                    b.HasIndex("FieldToId");

                    b.ToTable("FormatMappedField");
                });

            modelBuilder.Entity("FormatChanger.Model.FormatMapper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FormatMapper");
                });

            modelBuilder.Entity("FormatChanger.Model.SavedExport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FormatId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FormatId");

                    b.ToTable("SavedExports");
                });

            modelBuilder.Entity("FormatChanger.Model.SavedField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FieldFormatId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SavedRowId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FieldFormatId");

                    b.HasIndex("SavedRowId");

                    b.ToTable("SavedFields");
                });

            modelBuilder.Entity("FormatChanger.Model.SavedRow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SavedExportId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SavedExportId");

                    b.ToTable("SavedRow");
                });

            modelBuilder.Entity("FormatChanger.Model.FieldFormat", b =>
                {
                    b.HasOne("FormatChanger.Model.Format", "Father")
                        .WithMany("Fields")
                        .HasForeignKey("FatherId");

                    b.Navigation("Father");
                });

            modelBuilder.Entity("FormatChanger.Model.FormatMappedField", b =>
                {
                    b.HasOne("FormatChanger.Model.FormatMapper", "Father")
                        .WithMany("MappingFields")
                        .HasForeignKey("FatherId");

                    b.HasOne("FormatChanger.Model.FieldFormat", "FieldFrom")
                        .WithMany()
                        .HasForeignKey("FieldFromId");

                    b.HasOne("FormatChanger.Model.FieldFormat", "FieldTo")
                        .WithMany()
                        .HasForeignKey("FieldToId");

                    b.Navigation("Father");

                    b.Navigation("FieldFrom");

                    b.Navigation("FieldTo");
                });

            modelBuilder.Entity("FormatChanger.Model.SavedExport", b =>
                {
                    b.HasOne("FormatChanger.Model.Format", "Format")
                        .WithMany()
                        .HasForeignKey("FormatId");

                    b.Navigation("Format");
                });

            modelBuilder.Entity("FormatChanger.Model.SavedField", b =>
                {
                    b.HasOne("FormatChanger.Model.FieldFormat", "FieldFormat")
                        .WithMany()
                        .HasForeignKey("FieldFormatId");

                    b.HasOne("FormatChanger.Model.SavedRow", null)
                        .WithMany("SavedFields")
                        .HasForeignKey("SavedRowId");

                    b.Navigation("FieldFormat");
                });

            modelBuilder.Entity("FormatChanger.Model.SavedRow", b =>
                {
                    b.HasOne("FormatChanger.Model.SavedExport", null)
                        .WithMany("SavedRows")
                        .HasForeignKey("SavedExportId");
                });

            modelBuilder.Entity("FormatChanger.Model.Format", b =>
                {
                    b.Navigation("Fields");
                });

            modelBuilder.Entity("FormatChanger.Model.FormatMapper", b =>
                {
                    b.Navigation("MappingFields");
                });

            modelBuilder.Entity("FormatChanger.Model.SavedExport", b =>
                {
                    b.Navigation("SavedRows");
                });

            modelBuilder.Entity("FormatChanger.Model.SavedRow", b =>
                {
                    b.Navigation("SavedFields");
                });
#pragma warning restore 612, 618
        }
    }
}
