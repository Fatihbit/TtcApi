using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TtcApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Products",
                columns: table => new
                {
                    ProductName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UNNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gevaren = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verpakkingsgroep = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductName);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    ShipName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniekEuropeesScheepsidentificatienummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.ShipName);
                });

            migrationBuilder.CreateTable(
                name: "Terminals",
                columns: table => new
                {
                    TerminalName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminals", x => x.TerminalName);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "Ladings",
                columns: table => new
                {
                    LadingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TerminalName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tijd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hoeveelheid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ladings", x => x.LadingId);
                    table.ForeignKey(
                        name: "FK_Ladings_Products_ProductName",
                        column: x => x.ProductName,
                        principalTable: "Products",
                        principalColumn: "ProductName");
                    table.ForeignKey(
                        name: "FK_Ladings_Ships_ShipName",
                        column: x => x.ShipName,
                        principalTable: "Ships",
                        principalColumn: "ShipName");
                    table.ForeignKey(
                        name: "FK_Ladings_Terminals_TerminalName",
                        column: x => x.TerminalName,
                        principalTable: "Terminals",
                        principalColumn: "TerminalName");
                });

            migrationBuilder.CreateTable(
                name: "StatusLadings",
                columns: table => new
                {
                    StatusLadingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LadingId = table.Column<int>(type: "int", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusLadings", x => x.StatusLadingId);
                    table.ForeignKey(
                        name: "FK_StatusLadings_Ladings_LadingId",
                        column: x => x.LadingId,
                        principalTable: "Ladings",
                        principalColumn: "LadingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VeiligheidsChecklists",
                columns: table => new
                {
                    VeiligheidsChecklistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LadingId = table.Column<int>(type: "int", nullable: false),
                    ShipName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TerminalName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsSchipGoedGemeerd = table.Column<bool>(type: "bit", nullable: false),
                    IsDoeltreffendeVerlichtingVerzekerd = table.Column<bool>(type: "bit", nullable: false),
                    IsNooduitgangVrij = table.Column<bool>(type: "bit", nullable: false),
                    IsSchipWalVerbindingVeilig = table.Column<bool>(type: "bit", nullable: false),
                    ZijnLaadarmenVrijBeweegbaar = table.Column<bool>(type: "bit", nullable: false),
                    ZijnAansluitingenAfgeblind = table.Column<bool>(type: "bit", nullable: false),
                    ZijnLeidingenInGoedeStaat = table.Column<bool>(type: "bit", nullable: false),
                    ZijnAlleKleppenGecontroleerd = table.Column<bool>(type: "bit", nullable: false),
                    IsAlarmNoodstopBekend = table.Column<bool>(type: "bit", nullable: false),
                    ZijnBrandblusApparatenBedrijfsklaar = table.Column<bool>(type: "bit", nullable: false),
                    ZijnVerwarmingsapparatenUitgeschakeld = table.Column<bool>(type: "bit", nullable: false),
                    IsRookverbodAfgekondigd = table.Column<bool>(type: "bit", nullable: false),
                    ZijnRadarEnAndereElektrischeApparatenUit = table.Column<bool>(type: "bit", nullable: false),
                    ZijnDeurenEnRamenGesloten = table.Column<bool>(type: "bit", nullable: false),
                    IsOvervulbeveiligingBeproefd = table.Column<bool>(type: "bit", nullable: false),
                    IsUitschakelingPompVanafWalMogelijk = table.Column<bool>(type: "bit", nullable: false),
                    IsGasafvoerleidingCorrectAangesloten = table.Column<bool>(type: "bit", nullable: false),
                    IsDrukGasterugvoerleidingVeilig = table.Column<bool>(type: "bit", nullable: false),
                    IsVlamkerendeInrichtingAanwezig = table.Column<bool>(type: "bit", nullable: false),
                    IsVerblijftijdVastgesteldEnGedocumenteerd = table.Column<bool>(type: "bit", nullable: false),
                    IsLaadtemperatuurBinnenToegestaneBandbreedte = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiligheidsChecklists", x => x.VeiligheidsChecklistId);
                    table.ForeignKey(
                        name: "FK_VeiligheidsChecklists_Ladings_LadingId",
                        column: x => x.LadingId,
                        principalTable: "Ladings",
                        principalColumn: "LadingId");
                    table.ForeignKey(
                        name: "FK_VeiligheidsChecklists_Ships_ShipName",
                        column: x => x.ShipName,
                        principalTable: "Ships",
                        principalColumn: "ShipName");
                    table.ForeignKey(
                        name: "FK_VeiligheidsChecklists_Terminals_TerminalName",
                        column: x => x.TerminalName,
                        principalTable: "Terminals",
                        principalColumn: "TerminalName");
                });

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
                name: "IX_Ladings_ProductName",
                table: "Ladings",
                column: "ProductName");

            migrationBuilder.CreateIndex(
                name: "IX_Ladings_ShipName",
                table: "Ladings",
                column: "ShipName");

            migrationBuilder.CreateIndex(
                name: "IX_Ladings_TerminalName",
                table: "Ladings",
                column: "TerminalName");

            migrationBuilder.CreateIndex(
                name: "IX_StatusLadings_LadingId",
                table: "StatusLadings",
                column: "LadingId");

            migrationBuilder.CreateIndex(
                name: "IX_VeiligheidsChecklists_LadingId",
                table: "VeiligheidsChecklists",
                column: "LadingId");

            migrationBuilder.CreateIndex(
                name: "IX_VeiligheidsChecklists_ShipName",
                table: "VeiligheidsChecklists",
                column: "ShipName");

            migrationBuilder.CreateIndex(
                name: "IX_VeiligheidsChecklists_TerminalName",
                table: "VeiligheidsChecklists",
                column: "TerminalName");
        }

        /// <inheritdoc />
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
                name: "StatusLadings");

            migrationBuilder.DropTable(
                name: "VeiligheidsChecklists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Ladings");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "Terminals");
        }
    }
}
