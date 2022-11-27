using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KouArge.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Campus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sms = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OurFormats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurFormats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Redirects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redirects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocaialMediaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocaialMediaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SponsorsAndPartners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SponsorsAndPartners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    OurFormatId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImgBackUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReadCount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_OurFormats_OurFormatId",
                        column: x => x.OurFormatId,
                        principalTable: "OurFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    DepartmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventPictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventPictures_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Speaker_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Template = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificates_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventParticipants_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventParticipants_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralAssemblyApplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    Introducing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Why = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SituationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppStatus = table.Column<int>(type: "int", nullable: false),
                    ApplyTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralAssemblyApplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralAssemblyApplies_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralAssemblyApplies_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralAssemblyApplies_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GeneralAssemblyApplyId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMembers_GeneralAssemblyApplies_GeneralAssemblyApplyId",
                        column: x => x.GeneralAssemblyApplyId,
                        principalTable: "GeneralAssemblyApplies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeamMembers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamMemberId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocaialMediaTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedias_SocaialMediaTypes_SocaialMediaTypeId",
                        column: x => x.SocaialMediaTypeId,
                        principalTable: "SocaialMediaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialMedias_TeamMembers_TeamMemberId",
                        column: x => x.TeamMemberId,
                        principalTable: "TeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Campus", "CreatedAt", "IsActive", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1028), true, "Ali Rıza Veziroğlu Meslek Yüksekokulu", null },
                    { 2, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1029), true, "Asım Kocabıyık Meslek Yüksekokulu", null },
                    { 3, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1030), true, "Değirmendere Ali ÖZBAY Meslek Yüksekokulu", null },
                    { 4, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1031), true, "Teknoloji", null },
                    { 5, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1032), true, "Denizcilik Fakültesi", null },
                    { 6, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1033), true, "Diş Hekimliği Fakültesi", null },
                    { 7, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1034), true, "Diş Hekimliği Fakültesi", null },
                    { 8, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1035), true, "Eğitim Fakültesi", null },
                    { 9, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1036), true, "Fen - Edebiyat Fakültesi", null },
                    { 10, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1037), true, "Ford Otosan İhsaniye Otomotiv Meslek Yüksekokulu", null },
                    { 11, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1038), true, "Gazanfer Bilge Meslek Yüksekokulu", null },
                    { 12, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1039), true, "Gıda ve Tarım Meslek Yüksekokulu", null },
                    { 13, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1039), true, "Gölcük Meslek Yüksekokulu", null },
                    { 14, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1040), true, "Güzel Sanatlar Fakültesi", null },
                    { 15, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1041), true, "Havacılık ve Uzay Bilimleri Fakültesi", null },
                    { 16, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1042), true, "Hereke Asım Kocabıyık Meslek Yüksekokulu", null },
                    { 17, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1043), true, "Hereke Meslek Yüksekokulu", null },
                    { 18, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1044), true, "Hereke Ömer İsmet Uzunyol Meslek Yüksekokulu", null },
                    { 19, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1045), true, "Hukuk Fakültesi", null },
                    { 20, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1046), true, "İktisadi ve İdari Bilimler Fakültesi", null },
                    { 21, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1047), true, "İlahiyat Fakültesi", null },
                    { 22, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1048), true, "İletişim Fakültesi", null },
                    { 23, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1049), true, "İzmit Meslek Yüksekokulu", null },
                    { 24, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1050), true, "Kandıra Meslek Yüksekokulu", null },
                    { 25, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1051), true, "Karamürsel Meslek Yüksekokulu", null },
                    { 26, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1051), true, "Kartepe Atçılık Meslek Yüksekokulu", null },
                    { 27, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1052), true, "Kartepe Turizm Meslek Yüksekokulu", null },
                    { 28, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1053), true, "Kocaeli Meslek Yüksekokulu", null },
                    { 29, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1054), true, "Kocaeli Sağlık Hizmetleri Meslek Yüksekokulu", null },
                    { 30, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1055), true, "Koseköy Meslek Yüksekokulu", null },
                    { 31, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1056), true, "Mimarlık ve Tasarım Fakültesi", null },
                    { 32, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1057), true, "Mühendislik Fakültesi", null },
                    { 33, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1058), true, "Sağlık Bilimleri Fakültesi", null },
                    { 34, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1059), true, "Spor Bilimleri Fakültesi", null },
                    { 35, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1060), true, "Teknoloji Fakültesi", null },
                    { 36, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1061), true, "Tıp Fakültesi", null },
                    { 37, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1062), true, "Turizm Fakültesi", null },
                    { 38, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1063), true, "Turizm İşletmecliliği ve Otelcilik Yüksekokulu", null },
                    { 39, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1063), true, "Uzunçiftlik Nuh Çimento Meslek Yüksekokulu", null },
                    { 40, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1064), true, "Yahya Kaptan Meslek Yüksekokulu", null },
                    { 41, "Kocaeli", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1065), true, "Ziraat Fakültesi", null }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreatedAt", "Email", "IsActive", "Sms", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1320), 1, true, 1, null });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreatedAt", "Email", "IsActive", "Sms", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1321), 1, true, 0, null },
                    { 3, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1322), 0, true, 1, null },
                    { 4, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1323), 0, true, 0, null }
                });

            migrationBuilder.InsertData(
                table: "OurFormats",
                columns: new[] { "Id", "CreatedAt", "Description", "ImgUrl", "IsActive", "Keywords", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1437), "Description1", "Url1", true, "Keywords1", "Format1", null },
                    { 2, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1441), "Description2", "Url2", true, "Keywords2", "Format2", null },
                    { 3, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1443), "Description3", "Url3", true, "Keywords3", "Format3", null },
                    { 4, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1445), "Description4", "Url4", true, "Keywords4", "Format4", null },
                    { 5, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1447), "Description5", "Url5", true, "Keywords5", "Format5", null }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "CreatedAt", "EndDate", "IsActive", "Name", "StartDate", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1563), null, true, "Semester1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1565), null, true, "Semester2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1566), null, true, "Semester3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1567), null, true, "Semester4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1568), null, true, "Semester5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedAt", "Description", "ImgUrl", "IsActive", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1937), "Webino Takımı", "logoUrl", true, "Webino", null },
                    { 2, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1939), "Mobil Takımı", "logoUrl2", true, "Mobil", null }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(2035), true, "Takım Kaptanı", null },
                    { 2, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(2036), true, "Takım Kaptan Yardımcısı", null },
                    { 3, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(2037), true, "Takım Üyesi", null }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "FacultyId", "IsActive", "Name", "UpdatedAt" },
                values: new object[] { "1", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(543), 1, true, "Bil Sis. Müh.", null });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedAt", "Description", "EventDate", "ImgBackUrl", "IsActive", "OurFormatId", "ReadCount", "SemesterId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(895), "Descript1", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(893), "Url1", true, 2, 0, 1, "Title1", null },
                    { 2, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(899), "Descript2", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(898), "Url2", true, 1, 0, 1, "Title2", null },
                    { 3, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(901), "Descript3", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(900), "Url3", true, 2, 0, 1, "Title3", null },
                    { 4, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(928), "Descript4", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(902), "Url4", true, 1, 0, 1, "Title4", null },
                    { 5, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(931), "Descript5", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(929), "Url5", true, 2, 0, 1, "Title5", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DepartmentId", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "NotificationId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpires", "SecurityStamp", "StudentNumber", "Surname", "TwoFactorEnabled", "UpdatedAt", "UserName", "Year" },
                values: new object[,]
                {
                    { "1", 0, "b03b8cd7-9f5d-4a09-8c87-88c09d074ea0", new DateTime(2022, 11, 27, 16, 16, 42, 299, DateTimeKind.Local).AddTicks(8429), "1", "test@gmail.com", false, true, false, null, "test", "TEST@GMAIL.COM", "1", 1, "AQAAAAEAACcQAAAAEGPJRk1vOxjaYUkOxAuU5gvYRB5l/OUutAlJBkhUDltYcL9MjIiOmznus+SinfMsuA==", "5303003030", false, null, null, "87de1be7-c7c2-4c31-ab33-50bc3381233d", "191307000", "test", false, null, "1", 2 },
                    { "2", 0, "4d86f5bb-ff8c-4d5d-8ec2-e6406968150d", new DateTime(2022, 11, 27, 16, 16, 42, 300, DateTimeKind.Local).AddTicks(9521), "1", "test2@gmail.com", false, true, false, null, "test2", "TEST2@GMAIL.COM", "2", 1, null, "5303003031", false, null, null, "f4a78588-2a4d-4d75-b5e5-efa692bc5c03", "191307001", "test2", false, null, "2", 2 }
                });

            migrationBuilder.InsertData(
                table: "EventPictures",
                columns: new[] { "Id", "CreatedAt", "EventId", "ImgUrl", "IsActive", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(774), 1, "Url1", true, null },
                    { 2, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(778), 2, "Url2", true, null },
                    { 3, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(780), 3, "Url3", true, null },
                    { 4, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(781), 4, "Url4", true, null },
                    { 5, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(782), 5, "Url5", true, null }
                });

            migrationBuilder.InsertData(
                table: "Speaker",
                columns: new[] { "Id", "CreatedAt", "EventId", "ImgUrl", "IsActive", "Name", "UpdatedAt", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1692), 2, "Spekare Url 1", true, "Speaker Name 1", null, "spekaer Url 1" },
                    { 2, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1700), 1, "Spekare Url 2", true, "Speaker Name 2", null, "spekaer Url 2" },
                    { 3, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1705), 2, "Spekare Url 3", true, "Speaker Name 3", null, "spekaer Url 3" },
                    { 4, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1732), 1, "Spekare Url 4", true, "Speaker Name 4", null, "spekaer Url 4" },
                    { 6, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1697), 2, "Spekare Url 11", true, "Speaker Name 11", null, "spekaer Url 11" },
                    { 7, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1703), 1, "Spekare Url 21", true, "Speaker Name 21", null, "spekaer Url 21" },
                    { 8, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1708), 2, "Spekare Url 31", true, "Speaker Name 31", null, "spekaer Url 31" },
                    { 9, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1734), 1, "Spekare Url 41", true, "Speaker Name 41", null, "spekaer Url 41" }
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "AppUserId", "CreatedAt", "EventId", "IsActive", "Template", "UpdatedAt" },
                values: new object[,]
                {
                    { "1", "1", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(450), 1, true, 1, null },
                    { "2", "1", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(451), 2, true, 1, null }
                });

            migrationBuilder.InsertData(
                table: "EventParticipants",
                columns: new[] { "Id", "AppUserId", "CreatedAt", "EventId", "IsActive", "UpdatedAt" },
                values: new object[,]
                {
                    { 2, "1", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(643), 1, true, null },
                    { 3, "2", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(648), 1, true, null },
                    { 4, "1", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(649), 2, true, null }
                });

            migrationBuilder.InsertData(
                table: "GeneralAssemblyApplies",
                columns: new[] { "Id", "AppStatus", "AppUserId", "ApplyTime", "CreatedAt", "Introducing", "IsActive", "SituationDescription", "TeamId", "TitleId", "UpdatedAt", "Why" },
                values: new object[,]
                {
                    { 1, 0, "1", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1169), new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1168), "Introducing", true, "SituationDescription", 1, 1, null, "why" },
                    { 2, 1, "1", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1172), new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1171), "Introducing2", true, "SituationDescription2", 1, 2, null, "why2" }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "AppUserId", "CreatedAt", "EndDate", "GeneralAssemblyApplyId", "ImgUrl", "IsActive", "StartDate", "TeamId", "TitleId", "UpdatedAt" },
                values: new object[] { 1, "1", new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1836), new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1838), 2, "ImageUrl", true, new DateTime(2022, 11, 27, 16, 16, 42, 302, DateTimeKind.Local).AddTicks(1837), 1, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NotificationId",
                table: "AspNetUsers",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhoneNumber",
                table: "AspNetUsers",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudentNumber",
                table: "AspNetUsers",
                column: "StudentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_AppUserId",
                table: "Certificates",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_EventId",
                table: "Certificates",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyId",
                table: "Departments",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_AppUserId",
                table: "EventParticipants",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_EventId",
                table: "EventParticipants",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventPictures_EventId",
                table: "EventPictures",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_OurFormatId",
                table: "Events",
                column: "OurFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SemesterId",
                table: "Events",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralAssemblyApplies_AppUserId",
                table: "GeneralAssemblyApplies",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralAssemblyApplies_TeamId",
                table: "GeneralAssemblyApplies",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralAssemblyApplies_TitleId",
                table: "GeneralAssemblyApplies",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_SocaialMediaTypeId",
                table: "SocialMedias",
                column: "SocaialMediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_TeamMemberId",
                table: "SocialMedias",
                column: "TeamMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_EventId",
                table: "Speaker",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_AppUserId",
                table: "TeamMembers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_GeneralAssemblyApplyId",
                table: "TeamMembers",
                column: "GeneralAssemblyApplyId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TitleId",
                table: "TeamMembers",
                column: "TitleId");
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
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "EventParticipants");

            migrationBuilder.DropTable(
                name: "EventPictures");

            migrationBuilder.DropTable(
                name: "Redirects");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "SponsorsAndPartners");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "SocaialMediaTypes");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "GeneralAssemblyApplies");

            migrationBuilder.DropTable(
                name: "OurFormats");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
