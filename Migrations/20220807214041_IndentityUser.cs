using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RevenueApp.Migrations
{
    public partial class IndentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Assembly",
                schema: "dbo",
                columns: table => new
                {
                    AssemblyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssemblyName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assembly", x => x.AssemblyID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCategory",
                schema: "dbo",
                columns: table => new
                {
                    BusCatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusCatName = table.Column<string>(type: "varchar(65)", unicode: false, maxLength: 65, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCategory", x => x.BusCatID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                schema: "dbo",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "HouseCategory",
                schema: "dbo",
                columns: table => new
                {
                    HseCatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HseCatName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseCategory", x => x.HseCatID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                schema: "dbo",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "OfficeRank",
                schema: "dbo",
                columns: table => new
                {
                    RankID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeRank", x => x.RankID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Relation",
                schema: "dbo",
                columns: table => new
                {
                    RelationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relation", x => x.RelationID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                schema: "dbo",
                columns: table => new
                {
                    TitleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleName = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.TitleID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "BusinessRate",
                schema: "dbo",
                columns: table => new
                {
                    BusRateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusCatID = table.Column<int>(type: "int", nullable: false),
                    BusRate = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessRate", x => x.BusRateID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_BusinessCategory_BusinessRate",
                        column: x => x.BusCatID,
                        principalSchema: "dbo",
                        principalTable: "BusinessCategory",
                        principalColumn: "BusCatID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    Hometown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Residence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePic = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_Users", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Users_Gender_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "dbo",
                        principalTable: "Gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseRate",
                schema: "dbo",
                columns: table => new
                {
                    HseRateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HseRate = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    HseCatID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseRate", x => x.HseRateID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_HouseCategory_HouseRate",
                        column: x => x.HseCatID,
                        principalSchema: "dbo",
                        principalTable: "HouseCategory",
                        principalColumn: "HseCatID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "dbo",
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
                    table.PrimaryKey("PK_RoleClaims", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "dbo",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    RelationID = table.Column<int>(type: "int", nullable: false),
                    CustomerFName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    CustomerLName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    CustomerDoB = table.Column<DateTime>(type: "date", nullable: false),
                    CustomerTinNumber = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    GhanaCardNumber = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    CustomerResidentialAddress = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CustomerDigitalAddress = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CustomerEmail = table.Column<string>(type: "varchar(65)", unicode: false, maxLength: 65, nullable: false),
                    CustomerNationality = table.Column<string>(type: "varchar(65)", unicode: false, maxLength: 65, nullable: false),
                    CustomerSSN = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CustomerNextOfKinContact = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    CustomerContact = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    CustomerNextOfKin = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: false),
                    TitleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Gender_Customer",
                        column: x => x.GenderID,
                        principalSchema: "dbo",
                        principalTable: "Gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_Customer",
                        column: x => x.ImageId,
                        principalSchema: "dbo",
                        principalTable: "Image",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relation_Customer",
                        column: x => x.RelationID,
                        principalSchema: "dbo",
                        principalTable: "Relation",
                        principalColumn: "RelationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Title_Customer",
                        column: x => x.TitleID,
                        principalSchema: "dbo",
                        principalTable: "Title",
                        principalColumn: "TitleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfficerAdmin",
                schema: "dbo",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: false),
                    OfficerEmail = table.Column<string>(type: "varchar(65)", unicode: false, maxLength: 65, nullable: false),
                    RankID = table.Column<int>(type: "int", nullable: false),
                    OfficerFName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    OfficerLName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    OfficerDoB = table.Column<DateTime>(type: "date", nullable: false),
                    OfficerResidentialAddress = table.Column<string>(type: "varchar(65)", unicode: false, maxLength: 65, nullable: false),
                    OfficerDigitalAddress = table.Column<string>(type: "varchar(65)", unicode: false, maxLength: 65, nullable: false),
                    OfficerContact = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    OfficerNextOfKin = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    OfficerNextOfKinContact = table.Column<string>(type: "char(20)", unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    RelationID = table.Column<int>(type: "int", nullable: false),
                    TitleID = table.Column<int>(type: "int", nullable: false),
                    AssemblyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficerAdmin", x => x.StaffID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Assembly_OfficerAdmin",
                        column: x => x.AssemblyID,
                        principalSchema: "dbo",
                        principalTable: "Assembly",
                        principalColumn: "AssemblyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gender_OfficerAdmin",
                        column: x => x.GenderID,
                        principalSchema: "dbo",
                        principalTable: "Gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_OfficerAdmin",
                        column: x => x.ImageId,
                        principalSchema: "dbo",
                        principalTable: "Image",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficeRank_OfficerAdmin",
                        column: x => x.RankID,
                        principalSchema: "dbo",
                        principalTable: "OfficeRank",
                        principalColumn: "RankID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relation_OfficerAdmin",
                        column: x => x.RelationID,
                        principalSchema: "dbo",
                        principalTable: "Relation",
                        principalColumn: "RelationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Title_OfficerAdmin",
                        column: x => x.TitleID,
                        principalSchema: "dbo",
                        principalTable: "Title",
                        principalColumn: "TitleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "dbo",
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
                    table.PrimaryKey("PK_UserClaims", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.LoginProvider)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.LoginProvider)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                schema: "dbo",
                columns: table => new
                {
                    BusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    BusCatID = table.Column<int>(type: "int", nullable: false),
                    BusName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BusLocation = table.Column<string>(type: "varchar(65)", unicode: false, maxLength: 65, nullable: false),
                    BusBlockNumber = table.Column<string>(type: "varchar(65)", unicode: false, maxLength: 65, nullable: false),
                    BusDigitalAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    BusTelNumber = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    BusRegDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.BusID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_BusinessCategory_Business",
                        column: x => x.BusCatID,
                        principalSchema: "dbo",
                        principalTable: "BusinessCategory",
                        principalColumn: "BusCatID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_Business",
                        column: x => x.CustomerID,
                        principalSchema: "dbo",
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "House",
                schema: "dbo",
                columns: table => new
                {
                    HseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    HseNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    HseLocation = table.Column<string>(type: "varchar(65)", unicode: false, maxLength: 65, nullable: false),
                    HseBlockNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    HseCatID = table.Column<int>(type: "int", nullable: false),
                    HseDigitalAddress = table.Column<string>(type: "varchar(65)", unicode: false, maxLength: 65, nullable: false),
                    HseTelNumber = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false),
                    HseRegDate = table.Column<DateTime>(type: "date", nullable: false),
                    HseName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.HseID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Customer_House",
                        column: x => x.CustomerID,
                        principalSchema: "dbo",
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HouseCategory_House",
                        column: x => x.HseCatID,
                        principalSchema: "dbo",
                        principalTable: "HouseCategory",
                        principalColumn: "HseCatID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessBill",
                schema: "dbo",
                columns: table => new
                {
                    BusBillNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusBillDate = table.Column<DateTime>(type: "date", nullable: false),
                    BusID = table.Column<int>(type: "int", nullable: false),
                    YearBill = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    BusCurrentBill = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    BusPrevPayment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    BusArrears = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    BusTotalAmtDue = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    BusRateID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessBill", x => x.BusBillNumber)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Business_BusinessBill",
                        column: x => x.BusID,
                        principalSchema: "dbo",
                        principalTable: "Business",
                        principalColumn: "BusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessRate_BusinessBill",
                        column: x => x.BusRateID,
                        principalSchema: "dbo",
                        principalTable: "BusinessRate",
                        principalColumn: "BusRateID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_BusinessBill",
                        column: x => x.CustomerID,
                        principalSchema: "dbo",
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HouseBill",
                schema: "dbo",
                columns: table => new
                {
                    HseBillNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HseBillDate = table.Column<DateTime>(type: "date", nullable: false),
                    HseID = table.Column<int>(type: "int", nullable: false),
                    HseCurrentBill = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    HsePrevPayment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    HseArrears = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    HseTotalAmtDue = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    HseRateID = table.Column<int>(type: "int", nullable: false),
                    YearBill = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseBill", x => x.HseBillNumber)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Customer_HouseBill",
                        column: x => x.CustomerID,
                        principalSchema: "dbo",
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_House_HouseBill",
                        column: x => x.HseID,
                        principalSchema: "dbo",
                        principalTable: "House",
                        principalColumn: "HseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HouseRate_HouseBill",
                        column: x => x.HseRateID,
                        principalSchema: "dbo",
                        principalTable: "HouseRate",
                        principalColumn: "HseRateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HouseDailyPayment",
                schema: "dbo",
                columns: table => new
                {
                    HsePaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HseID = table.Column<int>(type: "int", nullable: false),
                    HseAmount = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    HsePaymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseDailyPayment", x => x.HsePaymentID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Customer_HouseDailyPayment",
                        column: x => x.CustomerID,
                        principalSchema: "dbo",
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_House_HouseDailyPayment",
                        column: x => x.HseID,
                        principalSchema: "dbo",
                        principalTable: "House",
                        principalColumn: "HseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessDailyPayment",
                schema: "dbo",
                columns: table => new
                {
                    BusPaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusID = table.Column<int>(type: "int", nullable: false),
                    BusAmount = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    BusPaymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    BusBillNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDailyPayment", x => x.BusPaymentID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Business_BusinessDailyPayment",
                        column: x => x.BusID,
                        principalSchema: "dbo",
                        principalTable: "Business",
                        principalColumn: "BusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessDailyPayment_BusinessBill",
                        column: x => x.BusBillNumber,
                        principalSchema: "dbo",
                        principalTable: "BusinessBill",
                        principalColumn: "BusBillNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_BusinessDailyPayment",
                        column: x => x.CustomerID,
                        principalSchema: "dbo",
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business_BusCatID",
                schema: "dbo",
                table: "Business",
                column: "BusCatID");

            migrationBuilder.CreateIndex(
                name: "IX_Business_CustomerID",
                schema: "dbo",
                table: "Business",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessBill_BusID",
                schema: "dbo",
                table: "BusinessBill",
                column: "BusID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessBill_BusRateID",
                schema: "dbo",
                table: "BusinessBill",
                column: "BusRateID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessBill_CustomerID",
                schema: "dbo",
                table: "BusinessBill",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDailyPayment_BusBillNumber",
                schema: "dbo",
                table: "BusinessDailyPayment",
                column: "BusBillNumber");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDailyPayment_BusID",
                schema: "dbo",
                table: "BusinessDailyPayment",
                column: "BusID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDailyPayment_CustomerID",
                schema: "dbo",
                table: "BusinessDailyPayment",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessRate_BusCatID",
                schema: "dbo",
                table: "BusinessRate",
                column: "BusCatID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_GenderID",
                schema: "dbo",
                table: "Customer",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ImageId",
                schema: "dbo",
                table: "Customer",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_RelationID",
                schema: "dbo",
                table: "Customer",
                column: "RelationID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_TitleID",
                schema: "dbo",
                table: "Customer",
                column: "TitleID");

            migrationBuilder.CreateIndex(
                name: "IX_House_CustomerID",
                schema: "dbo",
                table: "House",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_House_HseCatID",
                schema: "dbo",
                table: "House",
                column: "HseCatID");

            migrationBuilder.CreateIndex(
                name: "IX_HouseBill_CustomerID",
                schema: "dbo",
                table: "HouseBill",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_HouseBill_HseID",
                schema: "dbo",
                table: "HouseBill",
                column: "HseID");

            migrationBuilder.CreateIndex(
                name: "IX_HouseBill_HseRateID",
                schema: "dbo",
                table: "HouseBill",
                column: "HseRateID");

            migrationBuilder.CreateIndex(
                name: "IX_HouseDailyPayment_CustomerID",
                schema: "dbo",
                table: "HouseDailyPayment",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_HouseDailyPayment_HseID",
                schema: "dbo",
                table: "HouseDailyPayment",
                column: "HseID");

            migrationBuilder.CreateIndex(
                name: "IX_HouseRate_HseCatID",
                schema: "dbo",
                table: "HouseRate",
                column: "HseCatID");

            migrationBuilder.CreateIndex(
                name: "IX_OfficerAdmin_AssemblyID",
                schema: "dbo",
                table: "OfficerAdmin",
                column: "AssemblyID");

            migrationBuilder.CreateIndex(
                name: "IX_OfficerAdmin_GenderID",
                schema: "dbo",
                table: "OfficerAdmin",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_OfficerAdmin_ImageId",
                schema: "dbo",
                table: "OfficerAdmin",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficerAdmin_RankID",
                schema: "dbo",
                table: "OfficerAdmin",
                column: "RankID");

            migrationBuilder.CreateIndex(
                name: "IX_OfficerAdmin_RelationID",
                schema: "dbo",
                table: "OfficerAdmin",
                column: "RelationID");

            migrationBuilder.CreateIndex(
                name: "IX_OfficerAdmin_TitleID",
                schema: "dbo",
                table: "OfficerAdmin",
                column: "TitleID");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "dbo",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "dbo",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "dbo",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                schema: "dbo",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                schema: "dbo",
                table: "Users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                schema: "dbo",
                table: "UserTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessDailyPayment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HouseBill",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HouseDailyPayment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OfficerAdmin",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BusinessBill",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HouseRate",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "House",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Assembly",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OfficeRank",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Business",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BusinessRate",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HouseCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BusinessCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Gender",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Image",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Relation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Title",
                schema: "dbo");
        }
    }
}
