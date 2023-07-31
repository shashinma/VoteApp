﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VoteApp.DAL.Data;

#nullable disable

namespace VoteApp.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230731103204_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("VoteApp.DAL.ExamResults", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Answer")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ExamsId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int>("QnAsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ExamsId");

                    b.HasIndex("QnAsId");

                    b.HasIndex("StudentId");

                    b.ToTable("ExamResults");
                });

            modelBuilder.Entity("VoteApp.DAL.Exams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Time")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("VoteApp.DAL.Groups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("VoteApp.DAL.QnAs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Answer")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExamsId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Option1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Option2")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Option3")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Option4")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExamsId");

                    b.ToTable("QnAs");
                });

            modelBuilder.Entity("VoteApp.DAL.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CVFileName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int?>("GroupsId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureFileName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroupsId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("VoteApp.DAL.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VoteApp.DAL.ExamResults", b =>
                {
                    b.HasOne("VoteApp.DAL.Exams", "Exams")
                        .WithMany("ExamResults")
                        .HasForeignKey("ExamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VoteApp.DAL.QnAs", "QnAs")
                        .WithMany("ExamResults")
                        .HasForeignKey("QnAsId")
                        .IsRequired();

                    b.HasOne("VoteApp.DAL.Students", "Students")
                        .WithMany("ExamResults")
                        .HasForeignKey("StudentId")
                        .IsRequired();

                    b.Navigation("Exams");

                    b.Navigation("QnAs");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("VoteApp.DAL.Exams", b =>
                {
                    b.HasOne("VoteApp.DAL.Groups", "Groups")
                        .WithMany("Exams")
                        .HasForeignKey("GroupId")
                        .IsRequired();

                    b.Navigation("Groups");
                });

            modelBuilder.Entity("VoteApp.DAL.Groups", b =>
                {
                    b.HasOne("VoteApp.DAL.Users", "Users")
                        .WithMany("Groups")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("VoteApp.DAL.QnAs", b =>
                {
                    b.HasOne("VoteApp.DAL.Exams", "Exams")
                        .WithMany("QnAs")
                        .HasForeignKey("ExamsId")
                        .IsRequired();

                    b.Navigation("Exams");
                });

            modelBuilder.Entity("VoteApp.DAL.Students", b =>
                {
                    b.HasOne("VoteApp.DAL.Groups", "Groups")
                        .WithMany("Students")
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Groups");
                });

            modelBuilder.Entity("VoteApp.DAL.Exams", b =>
                {
                    b.Navigation("ExamResults");

                    b.Navigation("QnAs");
                });

            modelBuilder.Entity("VoteApp.DAL.Groups", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("VoteApp.DAL.QnAs", b =>
                {
                    b.Navigation("ExamResults");
                });

            modelBuilder.Entity("VoteApp.DAL.Students", b =>
                {
                    b.Navigation("ExamResults");
                });

            modelBuilder.Entity("VoteApp.DAL.Users", b =>
                {
                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}