using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class fosterCareApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "OrderedNumber");

            migrationBuilder.CreateSequence<int>(
                name: "OrderNumbers");

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
                    DisplayName = table.Column<string>(type: "text", nullable: true),
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
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DefaultCode = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SurName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    KnownAs = table.Column<string>(type: "text", nullable: true),
                    Sex = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    PhotoPath = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateFound = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Religion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    District = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    SequenceNumbers = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"OrderNumbers\"')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    ProCode = table.Column<string>(type: "text", nullable: false),
                    NameOfProfession = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.ProCode);
                });

            migrationBuilder.CreateTable(
                name: "RegionsInGhana",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegionCode = table.Column<string>(type: "text", nullable: false),
                    RegionName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionsInGhana", x => x.RegionId);
                    table.UniqueConstraint("AlternateKey_RegionCode", x => x.RegionCode);
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
                name: "ApplicantAddress",
                columns: table => new
                {
                    AddIn = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nationality = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TownOfResidence = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    PermanentHomeAddress = table.Column<string>(type: "text", nullable: true),
                    LandMark = table.Column<string>(type: "text", nullable: true),
                    District = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Region = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    ApplicantUserName = table.Column<string>(type: "text", nullable: true),
                    AppUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantAddress", x => x.AddIn);
                    table.ForeignKey(
                        name: "FK_ApplicantAddress_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicantContacts",
                columns: table => new
                {
                    ContId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrimaryContactNo = table.Column<string>(type: "text", nullable: true),
                    ApplicantUserName = table.Column<string>(type: "text", nullable: true),
                    SecondaryContactNo = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    PreferenceCorrepondence = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantContacts", x => x.ContId);
                    table.ForeignKey(
                        name: "FK_ApplicantContacts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicantEducations",
                columns: table => new
                {
                    EduId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InstitutionName = table.Column<string>(type: "text", nullable: true),
                    Course = table.Column<string>(type: "text", nullable: true),
                    Qualification = table.Column<string>(type: "text", nullable: true),
                    ApplicantUserName = table.Column<string>(type: "text", nullable: true),
                    YearOfGraduation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantEducations", x => x.EduId);
                    table.ForeignKey(
                        name: "FK_ApplicantEducations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicantEmploymentHistories",
                columns: table => new
                {
                    OccId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Occupation = table.Column<string>(type: "text", nullable: true),
                    NameOfEmployer = table.Column<string>(type: "text", nullable: true),
                    LocationOfEmployer = table.Column<string>(type: "text", nullable: true),
                    DateStarted = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateExited = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Responsibilities = table.Column<string>(type: "text", nullable: true),
                    ApplicantUserName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantEmploymentHistories", x => x.OccId);
                    table.ForeignKey(
                        name: "FK_ApplicantEmploymentHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicantHouseholds",
                columns: table => new
                {
                    FamilyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaritalStatus = table.Column<string>(type: "text", nullable: true),
                    NoOfChildrenMale = table.Column<int>(type: "integer", nullable: false),
                    NoOfChildrenFemale = table.Column<int>(type: "integer", nullable: false),
                    NoOfAdultFemale = table.Column<int>(type: "integer", nullable: false),
                    NoOfAdultMale = table.Column<int>(type: "integer", nullable: false),
                    ApplicantUserName = table.Column<string>(type: "text", nullable: true),
                    AgesAdult = table.Column<string>(type: "text", nullable: true),
                    AgesChildren = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantHouseholds", x => x.FamilyId);
                    table.ForeignKey(
                        name: "FK_ApplicantHouseholds_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicantProfiles",
                columns: table => new
                {
                    ProId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FName = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    MName = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    SName = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    DateofBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    AppUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantProfiles", x => x.ProId);
                    table.ForeignKey(
                        name: "FK_ApplicantProfiles_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicantReferences",
                columns: table => new
                {
                    RefId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameOfReferee = table.Column<string>(type: "text", nullable: false),
                    RelationshipWithReferee = table.Column<string>(type: "text", nullable: false),
                    DateOfRelationship = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RefereePhoneNumber = table.Column<string>(type: "text", nullable: false),
                    RefereeEmail = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantReferences", x => x.RefId);
                    table.ForeignKey(
                        name: "FK_ApplicantReferences_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationIdentification",
                columns: table => new
                {
                    IdentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NationalIdType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    NationalIdNo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    IdentityPicture = table.Column<string>(type: "text", nullable: true),
                    ApplicantUserName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationIdentification", x => x.IdentId);
                    table.ForeignKey(
                        name: "FK_ApplicationIdentification_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                name: "EducationalHistory",
                columns: table => new
                {
                    EduId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InstitutionName = table.Column<string>(type: "text", nullable: true),
                    Course = table.Column<string>(type: "text", nullable: true),
                    Qualification = table.Column<string>(type: "text", nullable: true),
                    ApplicantUserName = table.Column<string>(type: "text", nullable: true),
                    YearOfGraduation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalHistory", x => x.EduId);
                    table.ForeignKey(
                        name: "FK_EducationalHistory_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FosterApplications",
                columns: table => new
                {
                    AppId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DefaultAppCode = table.Column<string>(type: "text", nullable: true),
                    SequenceNumber = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"OrderedNumber\"')"),
                    NatureOfApplication = table.Column<string>(type: "text", nullable: true),
                    TypeOfFosterCare = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    PreferredMinChildAge = table.Column<int>(type: "integer", nullable: false),
                    PreferredMaxChildAge = table.Column<int>(type: "integer", nullable: false),
                    PreferredChildXtics = table.Column<string>(type: "text", nullable: false),
                    NumberOfChildren = table.Column<int>(type: "integer", nullable: false),
                    ReadyToLetGofChild = table.Column<string>(type: "text", nullable: true),
                    AcceptChildWithSpecialNeeds = table.Column<string>(type: "text", nullable: true),
                    SpecifyChildWithSpecialNeeds = table.Column<string>(type: "text", nullable: true),
                    ApplicantUserName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    IsApplocationReviewed = table.Column<string>(type: "text", nullable: true),
                    IsApplicationApproved = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FosterApplications", x => x.AppId);
                    table.ForeignKey(
                        name: "FK_FosterApplications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChildApprovals",
                columns: table => new
                {
                    AppId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    ChildId = table.Column<int>(type: "integer", nullable: false),
                    ApprovedBy = table.Column<string>(type: "text", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildApprovals", x => x.AppId);
                    table.ForeignKey(
                        name: "FK_ChildApprovals_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildFamilyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameOfRelation = table.Column<string>(type: "text", nullable: true),
                    Relationship = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    IsCareGiver = table.Column<bool>(type: "boolean", nullable: false),
                    ChildId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildFamilyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildFamilyDetails_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildMedicalReports",
                columns: table => new
                {
                    StudyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TitleOfDocument = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    FileName = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    MedicalDocPath = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ChildId = table.Column<int>(type: "integer", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildMedicalReports", x => x.StudyId);
                    table.ForeignKey(
                        name: "FK_ChildMedicalReports_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildPhotos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    PhotoPath = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false),
                    ChildId = table.Column<int>(type: "integer", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildPhotos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_ChildPhotos_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildStudyReports",
                columns: table => new
                {
                    StudyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocumentTitle = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    FileName = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    DocumentPath = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ChildId = table.Column<int>(type: "integer", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildStudyReports", x => x.StudyId);
                    table.ForeignKey(
                        name: "FK_ChildStudyReports_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewChildren",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    CanGoIntoFoster = table.Column<bool>(type: "boolean", nullable: false),
                    ChildId = table.Column<int>(type: "integer", nullable: false),
                    ReviewBy = table.Column<string>(type: "text", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewChildren", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_ReviewChildren_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DisId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DistrictCode = table.Column<string>(type: "text", nullable: true),
                    Districtname = table.Column<string>(type: "text", nullable: false),
                    RegionCode = table.Column<string>(type: "text", nullable: false),
                    RegionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DisId);
                    table.ForeignKey(
                        name: "FK_Districts_RegionsInGhana_RegionId",
                        column: x => x.RegionId,
                        principalTable: "RegionsInGhana",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantHomeStudyReports",
                columns: table => new
                {
                    HomeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HomeDocumentTitle = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: true),
                    FileName = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    DocumentPath = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ApplyId = table.Column<int>(type: "integer", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantHomeStudyReports", x => x.HomeId);
                    table.ForeignKey(
                        name: "FK_ApplicantHomeStudyReports_FosterApplications_ApplyId",
                        column: x => x.ApplyId,
                        principalTable: "FosterApplications",
                        principalColumn: "AppId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantPhotos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhotoName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhotoPath = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    AppId = table.Column<int>(type: "integer", nullable: false),
                    FosterApplicationsAppId = table.Column<int>(type: "integer", nullable: true),
                    DateUploded = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantPhotos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_ApplicantPhotos_FosterApplications_FosterApplicationsAppId",
                        column: x => x.FosterApplicationsAppId,
                        principalTable: "FosterApplications",
                        principalColumn: "AppId");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    FosterParentApproved = table.Column<string>(type: "text", nullable: false),
                    ApprovedBy = table.Column<string>(type: "text", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateApprovalWasDone = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ApplyId = table.Column<int>(type: "integer", nullable: false),
                    FosterApplicationsAppId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationApprovals_FosterApplications_FosterApplicationsA~",
                        column: x => x.FosterApplicationsAppId,
                        principalTable: "FosterApplications",
                        principalColumn: "AppId");
                });

            migrationBuilder.CreateTable(
                name: "AssessApplications",
                columns: table => new
                {
                    AssessId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    CanFoster = table.Column<bool>(type: "boolean", nullable: false),
                    Assessedby = table.Column<string>(type: "text", nullable: false),
                    AssesDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateAssesed = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ApplyId = table.Column<int>(type: "integer", nullable: false),
                    FosterApplicationsAppId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessApplications", x => x.AssessId);
                    table.ForeignKey(
                        name: "FK_AssessApplications_FosterApplications_FosterApplicationsApp~",
                        column: x => x.FosterApplicationsAppId,
                        principalTable: "FosterApplications",
                        principalColumn: "AppId");
                });

            migrationBuilder.CreateTable(
                name: "Placements",
                columns: table => new
                {
                    PlaceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comment = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    MatchedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TheApplicationAcepted = table.Column<bool>(type: "boolean", nullable: false),
                    ApplyId = table.Column<int>(type: "integer", nullable: false),
                    Childid = table.Column<int>(type: "integer", nullable: false),
                    PlacementBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placements", x => x.PlaceId);
                    table.ForeignKey(
                        name: "FK_Placements_Children_Childid",
                        column: x => x.Childid,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Placements_FosterApplications_ApplyId",
                        column: x => x.ApplyId,
                        principalTable: "FosterApplications",
                        principalColumn: "AppId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantAddress_AppUserId",
                table: "ApplicantAddress",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantContacts_UserId",
                table: "ApplicantContacts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantEducations_UserId",
                table: "ApplicantEducations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantEmploymentHistories_UserId",
                table: "ApplicantEmploymentHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantHomeStudyReports_ApplyId",
                table: "ApplicantHomeStudyReports",
                column: "ApplyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantHouseholds_UserId",
                table: "ApplicantHouseholds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantPhotos_FosterApplicationsAppId",
                table: "ApplicantPhotos",
                column: "FosterApplicationsAppId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantProfiles_AppUserId",
                table: "ApplicantProfiles",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantReferences_UserId",
                table: "ApplicantReferences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationApprovals_FosterApplicationsAppId",
                table: "ApplicationApprovals",
                column: "FosterApplicationsAppId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationIdentification_UserId",
                table: "ApplicationIdentification",
                column: "UserId",
                unique: true);

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
                name: "IX_AssessApplications_FosterApplicationsAppId",
                table: "AssessApplications",
                column: "FosterApplicationsAppId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildApprovals_ChildId",
                table: "ChildApprovals",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildFamilyDetails_ChildId",
                table: "ChildFamilyDetails",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildMedicalReports_ChildId",
                table: "ChildMedicalReports",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildPhotos_ChildId",
                table: "ChildPhotos",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildStudyReports_ChildId",
                table: "ChildStudyReports",
                column: "ChildId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_RegionId",
                table: "Districts",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalHistory_AppUserId",
                table: "EducationalHistory",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FosterApplications_UserId",
                table: "FosterApplications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Placements_ApplyId",
                table: "Placements",
                column: "ApplyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Placements_Childid",
                table: "Placements",
                column: "Childid");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewChildren_ChildId",
                table: "ReviewChildren",
                column: "ChildId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantAddress");

            migrationBuilder.DropTable(
                name: "ApplicantContacts");

            migrationBuilder.DropTable(
                name: "ApplicantEducations");

            migrationBuilder.DropTable(
                name: "ApplicantEmploymentHistories");

            migrationBuilder.DropTable(
                name: "ApplicantHomeStudyReports");

            migrationBuilder.DropTable(
                name: "ApplicantHouseholds");

            migrationBuilder.DropTable(
                name: "ApplicantPhotos");

            migrationBuilder.DropTable(
                name: "ApplicantProfiles");

            migrationBuilder.DropTable(
                name: "ApplicantReferences");

            migrationBuilder.DropTable(
                name: "ApplicationApprovals");

            migrationBuilder.DropTable(
                name: "ApplicationIdentification");

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
                name: "AssessApplications");

            migrationBuilder.DropTable(
                name: "ChildApprovals");

            migrationBuilder.DropTable(
                name: "ChildFamilyDetails");

            migrationBuilder.DropTable(
                name: "ChildMedicalReports");

            migrationBuilder.DropTable(
                name: "ChildPhotos");

            migrationBuilder.DropTable(
                name: "ChildStudyReports");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "EducationalHistory");

            migrationBuilder.DropTable(
                name: "Placements");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "ReviewChildren");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "RegionsInGhana");

            migrationBuilder.DropTable(
                name: "FosterApplications");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropSequence(
                name: "OrderedNumber");

            migrationBuilder.DropSequence(
                name: "OrderNumbers");
        }
    }
}
