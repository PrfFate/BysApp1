﻿
using System;
using BysApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BysApp1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BysApp1.Models.Advisors", b =>
                {
                    b.Property<int>("AdvisorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdvisorID"));

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdvisorID");

                    b.ToTable("Advisors");
                });

            modelBuilder.Entity("BysApp1.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseID"));

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Credit")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMandatory")
                        .HasColumnType("bit");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("BysApp1.Models.CourseQuotas", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Quota")
                        .HasColumnType("int");

                    b.Property<int>("RemainingQuota")
                        .HasColumnType("int");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("CourseQuotas");
                });

            modelBuilder.Entity("BysApp1.Models.CourseSelectionHistory", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("SelectionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("StudentID");

                    b.ToTable("CourseSelectionHistory");
                });

            modelBuilder.Entity("BysApp1.Models.NonConfirmedSelections", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SelectedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("NonConfirmedSelections");
                });

            modelBuilder.Entity("BysApp1.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

                    b.Property<int?>("AdvisorID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.HasIndex("AdvisorID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("BysApp1.Models.StudentCourseSelections", b =>
                {
                    b.Property<int>("SelectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SelectionID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SelectionDate")
                        .HasColumnType("date");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("SelectionID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("StudentCourseSelections");
                });

            modelBuilder.Entity("BysApp1.Models.Transcripts", b =>
                {
                    b.Property<int>("TranscriptID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TranscriptID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Semester")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("TranscriptID");

                    b.ToTable("Transcripts");
                });

            modelBuilder.Entity("BysApp1.Models.Users", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RelatedID")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BysApp1.Models.CourseQuotas", b =>
                {
                    b.HasOne("BysApp1.Models.Course", "Course")
                        .WithOne()
                        .HasForeignKey("BysApp1.Models.CourseQuotas", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("BysApp1.Models.CourseSelectionHistory", b =>
                {
                    b.HasOne("BysApp1.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("BysApp1.Models.NonConfirmedSelections", b =>
                {
                    b.HasOne("BysApp1.Models.Course", "Course")
                        .WithMany("NonConfirmedSelections")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BysApp1.Models.Student", "Student")
                        .WithMany("NonConfirmedSelections")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("BysApp1.Models.Student", b =>
                {
                    b.HasOne("BysApp1.Models.Advisors", "Advisors")
                        .WithMany("Students")
                        .HasForeignKey("AdvisorID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Advisors");
                });

            modelBuilder.Entity("BysApp1.Models.StudentCourseSelections", b =>
                {
                    b.HasOne("BysApp1.Models.Course", "Course")
                        .WithMany("StudentCourseSelections")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BysApp1.Models.Student", "Student")
                        .WithMany("StudentCourseSelections")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("BysApp1.Models.Advisors", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("BysApp1.Models.Course", b =>
                {
                    b.Navigation("NonConfirmedSelections");

                    b.Navigation("StudentCourseSelections");
                });

            modelBuilder.Entity("BysApp1.Models.Student", b =>
                {
                    b.Navigation("NonConfirmedSelections");

                    b.Navigation("StudentCourseSelections");
                });
#pragma warning restore 612, 618
        }
    }
}
