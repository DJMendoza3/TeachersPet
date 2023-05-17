﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeachersPet.Context;

#nullable disable

namespace TeachersPet.Migrations
{
    [DbContext(typeof(SiteContext))]
    [Migration("20230517183154_Update")]
    partial class Update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("TeachersPet.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("TeachersPet.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TestId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("TeachersPet.Entities.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("TeachersPet.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TeachersPet.Entities.Answer", b =>
                {
                    b.HasOne("TeachersPet.Entities.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("TeachersPet.Entities.Question", b =>
                {
                    b.HasOne("TeachersPet.Entities.Test", null)
                        .WithMany("Questions")
                        .HasForeignKey("TestId");
                });

            modelBuilder.Entity("TeachersPet.Entities.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("TeachersPet.Entities.Test", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
