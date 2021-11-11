using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class addInitialModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyTradeLicenseCopy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerCardCopy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReciveSmsAndEmails = table.Column<bool>(type: "bit", nullable: false),
                    MemberSince = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLAges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLAges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLBathooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLBathooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLBedrooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLBedrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLBodyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLBodyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLCapacities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLCapacities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLCareerLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLCareerLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLCommitments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLCommitments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLCompanyIndustries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLCompanyIndustries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLCompanySizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLCompanySizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLCurrentNetworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLCurrentNetworks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLDoors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLDoors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLEducationLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLEducationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLEmirates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLEmirates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLEmploymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLEmploymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLFuelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLFuelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLFurnishings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLFurnishings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLHorsepowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLHorsepowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLJobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLJobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLMechanicalConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLMechanicalConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLMonthlySalaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLMonthlySalaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLMotorLengths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLMotorLengths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLMotorMakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLMotorMakers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLMotorRegionalSpecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLMotorRegionalSpecs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLNationalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLNationalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLNoOfCylinders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLNoOfCylinders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLNoticePeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLNoticePeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLOperators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLOperators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLTransmissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLTransmissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLUsages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLVisaStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLVisaStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLWheels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLWheels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLWorkExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLWorkExperiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    En_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DOB = table.Column<DateTime>(type: "Date", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DefaultLocation = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DefaultLanguage = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CareerLevel = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Education = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CurrentLocation = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CurrentPosition = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CurrentCompany = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverNote = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Industry = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HideInfromation = table.Column<bool>(type: "bit", nullable: false),
                    ExternalLogin = table.Column<bool>(type: "bit", nullable: false),
                    MemberSince = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    BrokerNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowInformation = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agent_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "OTPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OTPs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DLPlateTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmirateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLPlateTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DLPlateTypes_DLEmirates_EmirateId",
                        column: x => x.EmirateId,
                        principalTable: "DLEmirates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DLEngineSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MakerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLEngineSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DLEngineSizes_DLMotorMakers_MakerId",
                        column: x => x.MakerId,
                        principalTable: "DLMotorMakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DLMotorModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MakerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLMotorModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DLMotorModels_DLMotorMakers_MakerId",
                        column: x => x.MakerId,
                        principalTable: "DLMotorMakers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DLMobileNumberCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeatorId = table.Column<int>(type: "int", nullable: false),
                    OperatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLMobileNumberCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DLMobileNumberCodes_DLOperators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "DLOperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    En_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfAds = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    TradeLicenseNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TradeLicenseCopy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Industry = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ProfileStatus = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DLPlateCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLPlateCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DLPlateCodes_DLPlateTypes_PlateTypeId",
                        column: x => x.PlateTypeId,
                        principalTable: "DLPlateTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DLPlateDesigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLPlateDesigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DLPlateDesigns_DLPlateTypes_PlateTypeId",
                        column: x => x.PlateTypeId,
                        principalTable: "DLPlateTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DLMotorTrims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLMotorTrims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DLMotorTrims_DLMotorModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "DLMotorModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ads_Agent_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ads_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ads_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ads_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdOffers_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdOffers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdPictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainPicture = table.Column<bool>(type: "bit", nullable: false),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdPictures_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BussinesAds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtherCategoryName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BussinesAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BussinesAds_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobAds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CV = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CurrentLocation = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EducationLevel = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CurrentCompany = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CurrentPosition = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    WorkExperience = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Commitment = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NoticePeriod = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    VisaStatus = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CareerLevel = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ExpectedMonthlySalary = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmploymentType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MinWorkExperience = table.Column<int>(type: "int", nullable: false),
                    MinEducationLevel = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CVRequired = table.Column<bool>(type: "bit", nullable: false),
                    MonthlySalary = table.Column<double>(type: "float", nullable: false),
                    Benefits = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CompanySize = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CompanyIndustry = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    HideCompanyDetails = table.Column<bool>(type: "bit", nullable: false),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobAds_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefaultLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoverNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkExperience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Commitment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoticePeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisaStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CareerLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplications_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NumberAds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emirate = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PlateType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PlateCode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Design = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CurrentNetwork = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MobileCode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumberAds_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyAds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Furnishing = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BedRooms = table.Column<int>(type: "int", nullable: true),
                    BathRooms = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Balcony = table.Column<bool>(type: "bit", nullable: false),
                    BuiltInKitchenAppliances = table.Column<bool>(type: "bit", nullable: false),
                    BuildInWardrobes = table.Column<bool>(type: "bit", nullable: false),
                    WalkInCloset = table.Column<bool>(type: "bit", nullable: false),
                    CentralACAndHeating = table.Column<bool>(type: "bit", nullable: false),
                    ConceirgeService = table.Column<bool>(type: "bit", nullable: false),
                    CoveredParking = table.Column<bool>(type: "bit", nullable: false),
                    MaidService = table.Column<bool>(type: "bit", nullable: false),
                    MaidsRoom = table.Column<bool>(type: "bit", nullable: false),
                    PetsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    PrivateGarden = table.Column<bool>(type: "bit", nullable: false),
                    PrivateGym = table.Column<bool>(type: "bit", nullable: false),
                    PrivateJacuzzi = table.Column<bool>(type: "bit", nullable: false),
                    PrivatePool = table.Column<bool>(type: "bit", nullable: false),
                    Security = table.Column<bool>(type: "bit", nullable: false),
                    SharedGym = table.Column<bool>(type: "bit", nullable: false),
                    SharedPool = table.Column<bool>(type: "bit", nullable: false),
                    SharedSpa = table.Column<bool>(type: "bit", nullable: false),
                    StudyRoom = table.Column<bool>(type: "bit", nullable: false),
                    ViewOfLandmark = table.Column<bool>(type: "bit", nullable: false),
                    ViewOfWater = table.Column<bool>(type: "bit", nullable: false),
                    AvailableNetworked = table.Column<bool>(type: "bit", nullable: false),
                    ConferenceRoom = table.Column<bool>(type: "bit", nullable: false),
                    DiningInBuilding = table.Column<bool>(type: "bit", nullable: false),
                    RetailInBuilding = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true),
                    AnnualRent = table.Column<double>(type: "float", nullable: true),
                    RentPaidIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Developer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadyBy = table.Column<DateTime>(type: "Date", nullable: true),
                    TotalClosingFee = table.Column<double>(type: "float", nullable: false),
                    AnnualCommunityFee = table.Column<double>(type: "float", nullable: false),
                    PropertyReferenceID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ListedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    RERALandlordName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RERATitleDeedNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RERAPreRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RERABrokerIDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RERAListerCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RERAPermitNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RERAAgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Building = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Neighborhood = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyAds_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAds_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceAds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    OtherSubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceAds_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceAds_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubType_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassifiedAds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    OtherSubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTypeId = table.Column<int>(type: "int", nullable: false),
                    OtherSubType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifiedAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassifiedAds_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassifiedAds_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassifiedAds_SubType_SubTypeId",
                        column: x => x.SubTypeId,
                        principalTable: "SubType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElectronicAds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Usage = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Warranty = table.Column<bool>(type: "bit", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    OtherSubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTypeId = table.Column<int>(type: "int", nullable: false),
                    OtherSubType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectronicAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectronicAds_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectronicAds_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElectronicAds_SubType_SubTypeId",
                        column: x => x.SubTypeId,
                        principalTable: "SubType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotorAds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Maker = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Ar_Maker = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    En_Model = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Ar_Model = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    En_Trim = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Ar_Trim = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    En_Color = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Ar_Color = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Kilometers = table.Column<double>(type: "float", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doors = table.Column<int>(type: "int", nullable: true),
                    Warranty = table.Column<bool>(type: "bit", nullable: false),
                    En_Transmission = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Ar_Transmission = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    En_RegionalSpecs = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Ar_RegionalSpecs = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    En_BodyType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Ar_BodyType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    En_FuelType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Ar_FuelType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NoOfCylinders = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Horsepower = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    En_Condition = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Ar_Condition = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    En_MechanicalCondition = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Ar_MechanicalCondition = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Capacity = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EngineSize = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Age = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    En_Usage = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Ar_Usage = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Length = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Wheels = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    OtherSubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTypeId = table.Column<int>(type: "int", nullable: false),
                    AdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotorAds_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotorAds_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MotorAds_SubType_SubTypeId",
                        column: x => x.SubTypeId,
                        principalTable: "SubType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdOffers_AdId",
                table: "AdOffers",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_AdOffers_UserId",
                table: "AdOffers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdPictures_AdId",
                table: "AdPictures",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_AgentId",
                table: "Ads",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_CategoryId",
                table: "Ads",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_TypeId",
                table: "Ads",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_UserId",
                table: "Ads",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Agent_AgencyId",
                table: "Agent",
                column: "AgencyId");

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BussinesAds_AdId",
                table: "BussinesAds",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TypeId",
                table: "Categories",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedAds_AdId",
                table: "ClassifiedAds",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedAds_SubCategoryId",
                table: "ClassifiedAds",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassifiedAds_SubTypeId",
                table: "ClassifiedAds",
                column: "SubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfiles_UserId",
                table: "CompanyProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DLEngineSizes_MakerId",
                table: "DLEngineSizes",
                column: "MakerId");

            migrationBuilder.CreateIndex(
                name: "IX_DLMobileNumberCodes_OperatorId",
                table: "DLMobileNumberCodes",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DLMotorModels_MakerId",
                table: "DLMotorModels",
                column: "MakerId");

            migrationBuilder.CreateIndex(
                name: "IX_DLMotorTrims_ModelId",
                table: "DLMotorTrims",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DLPlateCodes_PlateTypeId",
                table: "DLPlateCodes",
                column: "PlateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DLPlateDesigns_PlateTypeId",
                table: "DLPlateDesigns",
                column: "PlateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DLPlateTypes_EmirateId",
                table: "DLPlateTypes",
                column: "EmirateId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicAds_AdId",
                table: "ElectronicAds",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicAds_SubCategoryId",
                table: "ElectronicAds",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectronicAds_SubTypeId",
                table: "ElectronicAds",
                column: "SubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_AdId",
                table: "Favorites",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAds_AdId",
                table: "JobAds",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_AdId",
                table: "JobApplications",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_UserId",
                table: "JobApplications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorAds_AdId",
                table: "MotorAds",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorAds_SubCategoryId",
                table: "MotorAds",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorAds_SubTypeId",
                table: "MotorAds",
                column: "SubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NumberAds_AdId",
                table: "NumberAds",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_OTPs_UserId",
                table: "OTPs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAds_AdId",
                table: "PropertyAds",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAds_SubCategoryId",
                table: "PropertyAds",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_AdId",
                table: "Reports",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserId",
                table: "Reports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAds_AdId",
                table: "ServiceAds",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAds_SubCategoryId",
                table: "ServiceAds",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubType_SubCategoryId",
                table: "SubType",
                column: "SubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdOffers");

            migrationBuilder.DropTable(
                name: "AdPictures");

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
                name: "BussinesAds");

            migrationBuilder.DropTable(
                name: "ClassifiedAds");

            migrationBuilder.DropTable(
                name: "CompanyProfiles");

            migrationBuilder.DropTable(
                name: "DLAges");

            migrationBuilder.DropTable(
                name: "DLBathooms");

            migrationBuilder.DropTable(
                name: "DLBedrooms");

            migrationBuilder.DropTable(
                name: "DLBodyTypes");

            migrationBuilder.DropTable(
                name: "DLCapacities");

            migrationBuilder.DropTable(
                name: "DLCareerLevels");

            migrationBuilder.DropTable(
                name: "DLColors");

            migrationBuilder.DropTable(
                name: "DLCommitments");

            migrationBuilder.DropTable(
                name: "DLCompanyIndustries");

            migrationBuilder.DropTable(
                name: "DLCompanySizes");

            migrationBuilder.DropTable(
                name: "DLConditions");

            migrationBuilder.DropTable(
                name: "DLCurrentNetworks");

            migrationBuilder.DropTable(
                name: "DLDoors");

            migrationBuilder.DropTable(
                name: "DLEducationLevels");

            migrationBuilder.DropTable(
                name: "DLEmploymentTypes");

            migrationBuilder.DropTable(
                name: "DLEngineSizes");

            migrationBuilder.DropTable(
                name: "DLFuelTypes");

            migrationBuilder.DropTable(
                name: "DLFurnishings");

            migrationBuilder.DropTable(
                name: "DLHorsepowers");

            migrationBuilder.DropTable(
                name: "DLJobTypes");

            migrationBuilder.DropTable(
                name: "DLLocations");

            migrationBuilder.DropTable(
                name: "DLMechanicalConditions");

            migrationBuilder.DropTable(
                name: "DLMobileNumberCodes");

            migrationBuilder.DropTable(
                name: "DLMonthlySalaries");

            migrationBuilder.DropTable(
                name: "DLMotorLengths");

            migrationBuilder.DropTable(
                name: "DLMotorRegionalSpecs");

            migrationBuilder.DropTable(
                name: "DLMotorTrims");

            migrationBuilder.DropTable(
                name: "DLNationalities");

            migrationBuilder.DropTable(
                name: "DLNoOfCylinders");

            migrationBuilder.DropTable(
                name: "DLNoticePeriods");

            migrationBuilder.DropTable(
                name: "DLPlateCodes");

            migrationBuilder.DropTable(
                name: "DLPlateDesigns");

            migrationBuilder.DropTable(
                name: "DLTransmissions");

            migrationBuilder.DropTable(
                name: "DLUsages");

            migrationBuilder.DropTable(
                name: "DLVisaStatuses");

            migrationBuilder.DropTable(
                name: "DLWheels");

            migrationBuilder.DropTable(
                name: "DLWorkExperiences");

            migrationBuilder.DropTable(
                name: "DLYears");

            migrationBuilder.DropTable(
                name: "ElectronicAds");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "JobAds");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "MotorAds");

            migrationBuilder.DropTable(
                name: "NumberAds");

            migrationBuilder.DropTable(
                name: "OTPs");

            migrationBuilder.DropTable(
                name: "PropertyAds");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "ServiceAds");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DLOperators");

            migrationBuilder.DropTable(
                name: "DLMotorModels");

            migrationBuilder.DropTable(
                name: "DLPlateTypes");

            migrationBuilder.DropTable(
                name: "SubType");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "DLMotorMakers");

            migrationBuilder.DropTable(
                name: "DLEmirates");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Agency");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
