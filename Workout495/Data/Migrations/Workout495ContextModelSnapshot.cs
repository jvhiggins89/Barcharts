﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workout495.Data;

namespace Workout495.Migrations
{
    [DbContext(typeof(Workout495Context))]
    partial class Workout495ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(50000);

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes");
                });

            modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(50000);

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Key");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.ToTable("PersistedGrants");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Workout495.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Workout495.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfCompletions")
                        .HasColumnType("int");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.Property<int?>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("Exercise");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Air Squat of Death",
                            NumberOfCompletions = 65,
                            Reps = 9,
                            Sets = 2,
                            Weight = 20f,
                            WorkoutId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Incline Dumbell Press With Swim Fins on",
                            NumberOfCompletions = 49,
                            Reps = 6,
                            Sets = 1,
                            Weight = 11f,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Super Set for Super Abs",
                            NumberOfCompletions = 40,
                            Reps = 2,
                            Sets = 4,
                            Weight = 53f,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Workout 4",
                            NumberOfCompletions = 17,
                            Reps = 5,
                            Sets = 5,
                            Weight = 79f,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Workout 5",
                            NumberOfCompletions = 77,
                            Reps = 8,
                            Sets = 1,
                            Weight = 98f,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 6,
                            Name = "Workout 6",
                            NumberOfCompletions = 82,
                            Reps = 6,
                            Sets = 3,
                            Weight = 28f,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 7,
                            Name = "Workout 7",
                            NumberOfCompletions = 72,
                            Reps = 3,
                            Sets = 3,
                            Weight = 3f,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 8,
                            Name = "Workout 8",
                            NumberOfCompletions = 3,
                            Reps = 11,
                            Sets = 6,
                            Weight = 38f,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 9,
                            Name = "Workout 9",
                            NumberOfCompletions = 21,
                            Reps = 1,
                            Sets = 4,
                            Weight = 85f,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 10,
                            Name = "Workout 10",
                            NumberOfCompletions = 73,
                            Reps = 10,
                            Sets = 2,
                            Weight = 3f,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 11,
                            Name = "Workout 11",
                            NumberOfCompletions = 83,
                            Reps = 2,
                            Sets = 5,
                            Weight = 31f,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 12,
                            Name = "Workout 12",
                            NumberOfCompletions = 53,
                            Reps = 4,
                            Sets = 4,
                            Weight = 79f,
                            WorkoutId = 2
                        },
                        new
                        {
                            Id = 13,
                            Name = "Workout 13",
                            NumberOfCompletions = 31,
                            Reps = 10,
                            Sets = 4,
                            Weight = 54f,
                            WorkoutId = 2
                        });
                });

            modelBuilder.Entity("Workout495.Models.Goals", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BMI")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Changed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GoalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Goals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BMI = 25.0,
                            Changed = new DateTime(2019, 12, 11, 21, 0, 43, 883, DateTimeKind.Local).AddTicks(131),
                            Created = new DateTime(2019, 12, 11, 21, 0, 43, 883, DateTimeKind.Local).AddTicks(613),
                            Description = "Goal 1 Description.",
                            GoalDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Goal 1",
                            Weight = 129.0
                        },
                        new
                        {
                            Id = 2,
                            BMI = 12.0,
                            Changed = new DateTime(2019, 12, 11, 21, 0, 43, 883, DateTimeKind.Local).AddTicks(1108),
                            Created = new DateTime(2019, 12, 11, 21, 0, 43, 883, DateTimeKind.Local).AddTicks(1123),
                            Description = "Goal 2 Description.",
                            GoalDate = new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Goal 2",
                            Weight = 175.0
                        });
                });

            modelBuilder.Entity("Workout495.Models.ProgressPoints", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BMI")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Changed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GoalsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProgressPointDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("GoalsId");

                    b.HasIndex("UserId");

                    b.ToTable("ProgressPoints");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BMI = 28.0,
                            Changed = new DateTime(2019, 12, 11, 21, 0, 43, 883, DateTimeKind.Local).AddTicks(3793),
                            Created = new DateTime(2019, 12, 11, 21, 0, 43, 883, DateTimeKind.Local).AddTicks(4187),
                            Description = "ProgressPoint 1 Description.",
                            ProgressPointDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "ProgressPoint 1",
                            Weight = 149.0
                        },
                        new
                        {
                            Id = 2,
                            BMI = 14.0,
                            Changed = new DateTime(2019, 12, 11, 21, 0, 43, 883, DateTimeKind.Local).AddTicks(4619),
                            Created = new DateTime(2019, 12, 11, 21, 0, 43, 883, DateTimeKind.Local).AddTicks(4633),
                            Description = "ProgressPoint 2 Description.",
                            ProgressPointDate = new DateTime(2019, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "ProgressPoint 2",
                            Weight = 172.0
                        });
                });

            modelBuilder.Entity("Workout495.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ScheduledDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Workout");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Name = "Workout 1",
                            ScheduledDate = new DateTime(2019, 12, 12, 21, 0, 43, 878, DateTimeKind.Local).AddTicks(329)
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Name = "Workout 2",
                            ScheduledDate = new DateTime(2019, 12, 13, 21, 0, 43, 881, DateTimeKind.Local).AddTicks(5223)
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            Name = "Workout 3",
                            ScheduledDate = new DateTime(2019, 12, 14, 21, 0, 43, 881, DateTimeKind.Local).AddTicks(5266)
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Workout495.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Workout495.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Workout495.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Workout495.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Workout495.Models.Exercise", b =>
                {
                    b.HasOne("Workout495.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("Workout495.Models.Workout", "Workout")
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutId");
                });

            modelBuilder.Entity("Workout495.Models.Goals", b =>
                {
                    b.HasOne("Workout495.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Workout495.Models.ProgressPoints", b =>
                {
                    b.HasOne("Workout495.Models.Goals", null)
                        .WithMany("ProgressPoints")
                        .HasForeignKey("GoalsId");

                    b.HasOne("Workout495.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Workout495.Models.Workout", b =>
                {
                    b.HasOne("Workout495.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
