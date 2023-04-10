﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrnaVirtual.UrnaVirtualContext;

#nullable disable

namespace UrnaVirtual.Migrations
{
    [DbContext(typeof(UVContext))]
    partial class UVContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UrnaVirtual.Modelos.Aspirant", b =>
                {
                    b.Property<Guid>("AspirantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<int>("Departments")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpeditionDateID")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullNameAspirant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ID")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PoliticParty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AspirantId");

                    b.ToTable("Aspirants");
                });

            modelBuilder.Entity("UrnaVirtual.Modelos.Vote", b =>
                {
                    b.Property<Guid>("VoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AspirantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("VoteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VoterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VoteId");

                    b.HasIndex("AspirantId");

                    b.HasIndex("VoterId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("UrnaVirtual.Modelos.Voter", b =>
                {
                    b.Property<Guid>("VoterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<int>("Departments")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpeditionDateID")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullNameVoter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VoterId");

                    b.ToTable("Voters");
                });

            modelBuilder.Entity("UrnaVirtual.Modelos.Vote", b =>
                {
                    b.HasOne("UrnaVirtual.Modelos.Aspirant", "Aspirant")
                        .WithMany("Votes")
                        .HasForeignKey("AspirantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UrnaVirtual.Modelos.Voter", "Voter")
                        .WithMany()
                        .HasForeignKey("VoterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aspirant");

                    b.Navigation("Voter");
                });

            modelBuilder.Entity("UrnaVirtual.Modelos.Aspirant", b =>
                {
                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
