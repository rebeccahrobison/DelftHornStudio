﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DelftHornStudio.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Repertoires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repertoires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    IdentityUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    ParentName = table.Column<string>(type: "text", nullable: false),
                    ParentEmail = table.Column<string>(type: "text", nullable: false),
                    ParentPhone = table.Column<string>(type: "text", nullable: false),
                    ParentAddress = table.Column<string>(type: "text", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    DateScheduled = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    isCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    isPaid = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonRepertoires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonId = table.Column<int>(type: "integer", nullable: false),
                    RepertoireId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonRepertoires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonRepertoires_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonRepertoires_Repertoires_RepertoireId",
                        column: x => x.RepertoireId,
                        principalTable: "Repertoires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dca85891-ffa3-4105-a7e0-abb0b4534835", "Admin", "admin" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b36", "f07b7e63-21c6-4c1f-969b-c96bf3acb59c", "Student", "student" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "252608b0-3967-4296-b99e-bf93e7ee13dc", "admina@strator.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEHL9lDZxZOKrqWQEdgf+aPPtyb4cWqNBD6I0WUPfSGQ/OJal+YhGg0/QYkPQcI1nlQ==", null, false, "97c62f00-a7f9-4e94-818b-b2dec844a2e9", false, "Administrator" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a6f", 0, "69026514-badb-493a-91de-8d12b927f309", "abby@cooper.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEP6JYbQsztx4J4yyPBfkkOPcim7MkNhkdHJlIkdopgL6ALEop6JCkhHce7FgZwMAkQ==", null, false, "42fbc90b-5767-4898-b605-6c942c83b48a", false, "abbycooper" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a7f", 0, "a3c53866-f089-45d5-84ac-c9bd9a552bb4", "brandon@drake.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEHjfqnBS3keJkXAQzJeoVaJSh7EUCXLMM6AV5rOKTyHG/rLzESAhdBHGAKxY2k7Tqw==", null, false, "c8953c28-79c2-4d74-9e1a-e68990051556", false, "brandondrake" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a8f", 0, "a7001be7-52b6-4d7c-8a7e-33b58f11f49d", "tim@epps.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAECyCqTSB/rO4oQDGjm8qGVwYQJma32n234Lugzc+wwR/y9WNpZ4+XwUOIG2l7ZfuVw==", null, false, "6c9ace81-1c37-4a25-bd3c-e70cfa7e2f4b", false, "timepps" }
                });

            migrationBuilder.InsertData(
                table: "Repertoires",
                columns: new[] { "Id", "Author", "Image", "Title" },
                values: new object[,]
                {
                    { 1, "J. E. Skornicka", "https://halleonard-coverimages.s3.amazonaws.com/wl/04470070-wl.jpg", "Rubank Elementary Method: French Horn" },
                    { 2, "Mozart", "https://m.media-amazon.com/images/I/51diWNOVxPL._AC_UF1000,1000_QL80_.jpg", "Concertos for Horn" },
                    { 3, "Carl Kopprasch", "https://www.ficksmusic.com/cdn/shop/files/O2791_1200x.jpg?v=1699226606", "Sixty Selected Studies for French Horn" },
                    { 4, "Jean Marie Maximin, François Alphonse", "https://www.ficksmusic.com/cdn/shop/products/AL16857_vqkwpo_4f9a0c1d-dbd5-492d-bfbb-d800627a8ea9_1200x.jpg?v=1650813744", "Maxime-Alphonse: 200 New Etudes - Volume 1" },
                    { 5, "Gabriel Parès", "https://www.ficksmusic.com/cdn/shop/products/04470550-wl_1200x.jpg?v=1677095340", "Pares Scales for French Horn" },
                    { 6, "Mason Jones", "https://www.ficksmusic.com/cdn/shop/files/50490438FCz_1200x.jpg?v=1682432322", "Solos for the Horn Player" },
                    { 7, "Philip Farkas", "https://static.alfred.com/cache/6d/ad/6dad2e08f20b03fd3f6cb03e713b8b24.jpg", "The Art of French Horn Playing" },
                    { 8, "Max P. Pottag", "https://m.media-amazon.com/images/I/51Xoe86pAHL._AC_UF1000,1000_QL80_.jpg", "335 Selected Melodious Progressive and Technical Studies for French Horn" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "FirstName", "IdentityUserId", "LastName" },
                values: new object[,]
                {
                    { 1, "101 Main Street", "Delft", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Admin" },
                    { 2, "4511 Fair Way", "Abby", "dbc40bc6-0829-4ac5-a3ed-180f5e916a6f", "Cooper" },
                    { 3, "653 Turning Point", "Brandon", "dbc40bc6-0829-4ac5-a3ed-180f5e916a7f", "Drake" },
                    { 4, "1034 Reprise Circle", "Tim", "dbc40bc6-0829-4ac5-a3ed-180f5e916a8f", "Epps" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Grade", "ParentAddress", "ParentEmail", "ParentName", "ParentPhone", "Phone", "UserProfileId", "isActive" },
                values: new object[,]
                {
                    { 1, 7, "4511 Fair Way", "fCooper@gmail.comx", "Frank Cooper", "615-888-8888", "615-888-8888", 2, true },
                    { 2, 7, "4437 Presto Terrace", "tBrooks@gmail.comx", "Thad Brooks", "615-797-7979", "615-777-7777", 3, true },
                    { 3, 8, "1034 Reprise Circle", "lEpps@gmail.comx", "Letitia Epps", "615-555-5555", "615-555-5555", 4, false }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "DateScheduled", "Price", "StudentId", "isCompleted", "isPaid" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), 20.00m, 1, true, false },
                    { 2, new DateTime(2024, 1, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), 20.00m, 1, false, false },
                    { 3, new DateTime(2024, 2, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), 20.00m, 1, false, false },
                    { 4, new DateTime(2024, 1, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), 20.00m, 2, true, true },
                    { 5, new DateTime(2024, 1, 23, 11, 0, 0, 0, DateTimeKind.Unspecified), 20.00m, 2, false, false },
                    { 6, new DateTime(2024, 1, 17, 13, 0, 0, 0, DateTimeKind.Unspecified), 40.00m, 3, true, false },
                    { 7, new DateTime(2024, 2, 14, 13, 0, 0, 0, DateTimeKind.Unspecified), 40.00m, 3, false, false }
                });

            migrationBuilder.InsertData(
                table: "LessonRepertoires",
                columns: new[] { "Id", "LessonId", "RepertoireId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 5 },
                    { 3, 2, 1 },
                    { 4, 2, 7 },
                    { 5, 4, 5 },
                    { 6, 4, 8 },
                    { 7, 4, 2 },
                    { 8, 5, 4 },
                    { 9, 5, 6 },
                    { 10, 6, 1 },
                    { 11, 6, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonRepertoires_LessonId",
                table: "LessonRepertoires",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonRepertoires_RepertoireId",
                table: "LessonRepertoires",
                column: "RepertoireId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_StudentId",
                table: "Lessons",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserProfileId",
                table: "Students",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LessonRepertoires");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Repertoires");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
