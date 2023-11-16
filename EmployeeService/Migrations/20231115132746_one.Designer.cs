﻿// <auto-generated />
using System;
using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmployeeService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231115132746_one")]
    partial class one
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EmployeeService.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "коммерческий отдел"
                        },
                        new
                        {
                            Id = 2,
                            Name = "производственный отдел"
                        },
                        new
                        {
                            Id = 3,
                            Name = "конструкторский отдел"
                        });
                });

            modelBuilder.Entity("EmployeeService.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfEmployment")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<int>("JobPostId")
                        .HasColumnType("integer");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.Property<double>("Tariff")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("JobPostId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfEmployment = new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1,
                            JobPostId = 1,
                            PersonId = 1,
                            Tariff = 20000.0
                        },
                        new
                        {
                            Id = 2,
                            DateOfEmployment = new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 2,
                            JobPostId = 2,
                            PersonId = 2,
                            Tariff = 15000.0
                        },
                        new
                        {
                            Id = 3,
                            DateOfEmployment = new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 3,
                            JobPostId = 3,
                            PersonId = 3,
                            Tariff = 10000.0
                        },
                        new
                        {
                            Id = 4,
                            DateOfEmployment = new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1,
                            JobPostId = 4,
                            PersonId = 4,
                            Tariff = 9000.0
                        },
                        new
                        {
                            Id = 5,
                            DateOfEmployment = new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 2,
                            JobPostId = 2,
                            PersonId = 5,
                            Tariff = 5000.0
                        },
                        new
                        {
                            Id = 6,
                            DateOfEmployment = new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 3,
                            JobPostId = 1,
                            PersonId = 6,
                            Tariff = 12000.0
                        });
                });

            modelBuilder.Entity("EmployeeService.Models.JobPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("SalaryIncrement")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("JobPosts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "директор",
                            SalaryIncrement = 2.5
                        },
                        new
                        {
                            Id = 2,
                            Name = "заведующий архивом",
                            SalaryIncrement = 2.1000000000000001
                        },
                        new
                        {
                            Id = 3,
                            Name = "менеджер",
                            SalaryIncrement = 2.0
                        },
                        new
                        {
                            Id = 4,
                            Name = "мастер",
                            SalaryIncrement = 2.0
                        });
                });

            modelBuilder.Entity("EmployeeService.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1993, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Андрей",
                            Patronymic = "Васильевич",
                            Surname = "Иванов"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1983, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Артём",
                            Patronymic = "Дмитриевич",
                            Surname = "Крылов"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1987, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Милана",
                            Patronymic = "Максимовна",
                            Surname = "Крючкова"
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTime(1977, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Мария",
                            Patronymic = "Арсентьевна",
                            Surname = "Кононова"
                        },
                        new
                        {
                            Id = 5,
                            DateOfBirth = new DateTime(2000, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Роман",
                            Patronymic = "Маркович",
                            Surname = "Орлов"
                        },
                        new
                        {
                            Id = 6,
                            DateOfBirth = new DateTime(1991, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Вероника",
                            Patronymic = "Александровна",
                            Surname = "Сорокина"
                        });
                });

            modelBuilder.Entity("EmployeeService.Models.Employee", b =>
                {
                    b.HasOne("EmployeeService.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeService.Models.JobPost", "JobPost")
                        .WithMany("Employees")
                        .HasForeignKey("JobPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeService.Models.Person", "Person")
                        .WithOne("Employee")
                        .HasForeignKey("EmployeeService.Models.Employee", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("JobPost");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("EmployeeService.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EmployeeService.Models.JobPost", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EmployeeService.Models.Person", b =>
                {
                    b.Navigation("Employee")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
