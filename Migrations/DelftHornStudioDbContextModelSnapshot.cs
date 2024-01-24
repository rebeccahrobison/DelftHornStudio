﻿// <auto-generated />
using System;
using DelftHornStudio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DelftHornStudio.Migrations
{
    [DbContext(typeof(DelftHornStudioDbContext))]
    partial class DelftHornStudioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DelftHornStudio.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateScheduled")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.Property<bool>("isCompleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("isPaid")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Lessons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateScheduled = new DateTime(2024, 1, 16, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 20.00m,
                            StudentId = 1,
                            isCompleted = true,
                            isPaid = false
                        },
                        new
                        {
                            Id = 2,
                            DateScheduled = new DateTime(2024, 1, 23, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 20.00m,
                            StudentId = 1,
                            isCompleted = false,
                            isPaid = false
                        },
                        new
                        {
                            Id = 3,
                            DateScheduled = new DateTime(2024, 2, 13, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 20.00m,
                            StudentId = 1,
                            isCompleted = false,
                            isPaid = false
                        },
                        new
                        {
                            Id = 4,
                            DateScheduled = new DateTime(2024, 1, 16, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 20.00m,
                            StudentId = 2,
                            isCompleted = true,
                            isPaid = true
                        },
                        new
                        {
                            Id = 5,
                            DateScheduled = new DateTime(2024, 1, 23, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 20.00m,
                            StudentId = 2,
                            isCompleted = false,
                            isPaid = false
                        },
                        new
                        {
                            Id = 6,
                            DateScheduled = new DateTime(2024, 1, 17, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 40.00m,
                            StudentId = 3,
                            isCompleted = true,
                            isPaid = false
                        },
                        new
                        {
                            Id = 7,
                            DateScheduled = new DateTime(2024, 2, 14, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 40.00m,
                            StudentId = 3,
                            isCompleted = false,
                            isPaid = false
                        });
                });

            modelBuilder.Entity("DelftHornStudio.Models.LessonRepertoire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("LessonId")
                        .HasColumnType("integer");

                    b.Property<int>("RepertoireId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("RepertoireId");

                    b.ToTable("LessonRepertoires");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LessonId = 1,
                            RepertoireId = 1
                        },
                        new
                        {
                            Id = 2,
                            LessonId = 1,
                            RepertoireId = 5
                        },
                        new
                        {
                            Id = 3,
                            LessonId = 2,
                            RepertoireId = 1
                        },
                        new
                        {
                            Id = 4,
                            LessonId = 2,
                            RepertoireId = 7
                        },
                        new
                        {
                            Id = 5,
                            LessonId = 4,
                            RepertoireId = 5
                        },
                        new
                        {
                            Id = 6,
                            LessonId = 4,
                            RepertoireId = 8
                        },
                        new
                        {
                            Id = 7,
                            LessonId = 4,
                            RepertoireId = 2
                        },
                        new
                        {
                            Id = 8,
                            LessonId = 5,
                            RepertoireId = 4
                        },
                        new
                        {
                            Id = 9,
                            LessonId = 5,
                            RepertoireId = 6
                        },
                        new
                        {
                            Id = 10,
                            LessonId = 6,
                            RepertoireId = 1
                        },
                        new
                        {
                            Id = 11,
                            LessonId = 6,
                            RepertoireId = 3
                        });
                });

            modelBuilder.Entity("DelftHornStudio.Models.Repertoire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Repertoires");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "J. E. Skornicka",
                            Image = "https://halleonard-coverimages.s3.amazonaws.com/wl/04470070-wl.jpg",
                            Title = "Rubank Elementary Method: French Horn"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Mozart",
                            Image = "https://m.media-amazon.com/images/I/51diWNOVxPL._AC_UF1000,1000_QL80_.jpg",
                            Title = "Concertos for Horn"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Carl Kopprasch",
                            Image = "https://www.ficksmusic.com/cdn/shop/files/O2791_1200x.jpg?v=1699226606",
                            Title = "Sixty Selected Studies for French Horn"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Jean Marie Maximin, François Alphonse",
                            Image = "https://www.ficksmusic.com/cdn/shop/products/AL16857_vqkwpo_4f9a0c1d-dbd5-492d-bfbb-d800627a8ea9_1200x.jpg?v=1650813744",
                            Title = "Maxime-Alphonse: 200 New Etudes - Volume 1"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Gabriel Parès",
                            Image = "https://www.ficksmusic.com/cdn/shop/products/04470550-wl_1200x.jpg?v=1677095340",
                            Title = "Pares Scales for French Horn"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Mason Jones",
                            Image = "https://www.ficksmusic.com/cdn/shop/files/50490438FCz_1200x.jpg?v=1682432322",
                            Title = "Solos for the Horn Player"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Philip Farkas",
                            Image = "https://static.alfred.com/cache/6d/ad/6dad2e08f20b03fd3f6cb03e713b8b24.jpg",
                            Title = "The Art of French Horn Playing"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Max P. Pottag",
                            Image = "https://m.media-amazon.com/images/I/51Xoe86pAHL._AC_UF1000,1000_QL80_.jpg",
                            Title = "335 Selected Melodious Progressive and Technical Studies for French Horn"
                        });
                });

            modelBuilder.Entity("DelftHornStudio.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Grade")
                        .HasColumnType("integer");

                    b.Property<string>("ParentAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ParentEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ParentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ParentPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("integer");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Grade = 7,
                            ParentAddress = "4511 Fair Way",
                            ParentEmail = "fCooper@gmail.comx",
                            ParentName = "Frank Cooper",
                            ParentPhone = "615-888-8888",
                            Phone = "615-888-8888",
                            UserProfileId = 2,
                            isActive = true
                        },
                        new
                        {
                            Id = 2,
                            Grade = 7,
                            ParentAddress = "4437 Presto Terrace",
                            ParentEmail = "tBrooks@gmail.comx",
                            ParentName = "Thad Brooks",
                            ParentPhone = "615-797-7979",
                            Phone = "615-777-7777",
                            UserProfileId = 3,
                            isActive = true
                        },
                        new
                        {
                            Id = 3,
                            Grade = 8,
                            ParentAddress = "1034 Reprise Circle",
                            ParentEmail = "lEpps@gmail.comx",
                            ParentName = "Letitia Epps",
                            ParentPhone = "615-555-5555",
                            Phone = "615-555-5555",
                            UserProfileId = 4,
                            isActive = false
                        });
                });

            modelBuilder.Entity("DelftHornStudio.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdentityUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "101 Main Street",
                            FirstName = "Delft",
                            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            LastName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Address = "4511 Fair Way",
                            FirstName = "Abby",
                            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a6f",
                            LastName = "Cooper"
                        },
                        new
                        {
                            Id = 3,
                            Address = "653 Turning Point",
                            FirstName = "Brandon",
                            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a7f",
                            LastName = "Drake"
                        },
                        new
                        {
                            Id = 4,
                            Address = "1034 Reprise Circle",
                            FirstName = "Tim",
                            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a8f",
                            LastName = "Epps"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                            ConcurrencyStamp = "9615d324-85ff-48c3-b367-131b594fb876",
                            Name = "Admin",
                            NormalizedName = "admin"
                        },
                        new
                        {
                            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b36",
                            ConcurrencyStamp = "1535ac13-0a97-425c-9270-5763fd3b81d0",
                            Name = "Student",
                            NormalizedName = "student"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "42e212d0-20f4-47d2-8093-ab8f833798fb",
                            Email = "admina@strator.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEAoMpI2Wd/LunARs8CqxHfKmzYkotmqo59dV61FrejreBZOw6wvP9n8TGEf6fgzNJA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fa27c249-c661-4f56-83c2-e1b265ec1cbb",
                            TwoFactorEnabled = false,
                            UserName = "Administrator"
                        },
                        new
                        {
                            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a6f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3528db28-b706-4bc3-b5ba-ad9e337b5440",
                            Email = "abby@cooper.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEEZnqORpZxXQxE0QBjhKn5pFNSv71m1CQ6WjwCsqyvB6f8x83i8tS0VBPFEKiEELlg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "91020435-32d5-4b28-a0da-a2d794830574",
                            TwoFactorEnabled = false,
                            UserName = "abbycooper"
                        },
                        new
                        {
                            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a7f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f8dd3d1d-4cd8-49db-8217-117698faea07",
                            Email = "brandon@drake.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAECVM3FuKCEFBOEz+sSrpq+H/12xBiXXQ5eUSCN0iRzLdtGeLAwv3yVzsYsfktd4EIQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cf308678-1084-481e-971b-032817b65991",
                            TwoFactorEnabled = false,
                            UserName = "brandondrake"
                        },
                        new
                        {
                            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a8f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c6116983-3f09-4069-aa89-1cb1794b94aa",
                            Email = "tim@epps.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEEzdhbEWbMdcOgnucF04elZMylr+yNYeWypGMmtHt+CdG0fXeekSo5KSJNmCEbdnKQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "269454f9-57e8-41f4-aced-b0bd0e5bf2b1",
                            TwoFactorEnabled = false,
                            UserName = "timepps"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DelftHornStudio.Models.Lesson", b =>
                {
                    b.HasOne("DelftHornStudio.Models.Student", "Student")
                        .WithMany("Lessons")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DelftHornStudio.Models.LessonRepertoire", b =>
                {
                    b.HasOne("DelftHornStudio.Models.Lesson", null)
                        .WithMany("LessonRepertoires")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DelftHornStudio.Models.Repertoire", "Repertoire")
                        .WithMany()
                        .HasForeignKey("RepertoireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Repertoire");
                });

            modelBuilder.Entity("DelftHornStudio.Models.Student", b =>
                {
                    b.HasOne("DelftHornStudio.Models.UserProfile", "UserProfile")
                        .WithMany()
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("DelftHornStudio.Models.UserProfile", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityUser");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DelftHornStudio.Models.Lesson", b =>
                {
                    b.Navigation("LessonRepertoires");
                });

            modelBuilder.Entity("DelftHornStudio.Models.Student", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
