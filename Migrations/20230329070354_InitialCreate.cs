using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BonjeMetBonten.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Onderwerpen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Omschrijving = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderwerpen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titel = table.Column<string>(type: "TEXT", nullable: false),
                    Link = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Koppels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VideoId = table.Column<int>(type: "INTEGER", nullable: false),
                    OnderwerpId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Koppels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Koppels_Onderwerpen_OnderwerpId",
                        column: x => x.OnderwerpId,
                        principalTable: "Onderwerpen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Koppels_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Onderwerpen",
                columns: new[] { "Id", "Omschrijving" },
                values: new object[,]
                {
                    { -10, "The Hook" },
                    { -9, "The Jab" },
                    { -8, "Uppercut" },
                    { -7, "RoundHouse Kick" },
                    { -6, "Front Kick" },
                    { -5, "Back Kick" },
                    { -4, "Back Fist" },
                    { -3, "Ontwijking van gevaar" },
                    { -2, "Side Kick" },
                    { -1, "Stamina" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "Link", "Titel" },
                values: new object[,]
                {
                    { -17, "https://www.youtube.com/embed/EvJSNf75Ouw", "Headbutt" },
                    { -16, "https://www.youtube.com/embed/SJ6gUtVuMWE", "Zo SCHUIL je voor KOGELS | Man Bijt Hond | KIJK" },
                    { -15, "https://www.youtube.com/embed/Sa3_tBJXSSg", "Jo Bonten - Wat te doen bij een terroristische aanslag" },
                    { -14, "https://www.youtube.com/embed/aRGVRt-i9ww", "Vicious Combinations 4.6" },
                    { -13, "https://www.youtube.com/embed/cRX5-wS4M8s", "Roundhouse kick 4.2" },
                    { -12, "https://www.youtube.com/embed/iygxaot9Vms", "Flying Front Kick 4.8" },
                    { -11, "https://www.youtube.com/embed/vr4Mwf0Ymm8", "Voetenwerk (NL) 1.3" },
                    { -10, "https://www.youtube.com/embed/G5mJKBT4HH4", "Small series of different exercises for combat stamina" },
                    { -9, "https://www.youtube.com/embed/lDMZximoLmk", "Uithoudingsvermogen(NL) 1.4" },
                    { -8, "https://www.youtube.com/embed/1Wzi6j1REWI", "Deadly Combinations 3.4" },
                    { -7, "https://www.youtube.com/embed/QoL2fQDCPas", "The Uppercut 3.3" },
                    { -6, "https://www.youtube.com/embed/uVsfBos88CI", "The Jab 3.1" },
                    { -5, "https://www.youtube.com/embed/ocqFWvSVOLc", "The Hook 3.2" },
                    { -4, "https://www.youtube.com/embed/Nz7mAvVysrI", "Slipping and Evading 3.6" },
                    { -3, "https://www.youtube.com/embed/Mgb8wujuit0", "Side Kick 4.3" },
                    { -2, "https://www.youtube.com/embed/NMGFwBM7Uo4", "Shooting" },
                    { -1, "https://www.youtube.com/embed/gNd5c2C8Doc", "Spinning Back Fist" }
                });

            migrationBuilder.InsertData(
                table: "Koppels",
                columns: new[] { "Id", "OnderwerpId", "VideoId" },
                values: new object[,]
                {
                    { -25, -3, -17 },
                    { -24, -3, -16 },
                    { -23, -3, -15 },
                    { -22, -7, -14 },
                    { -21, -6, -14 },
                    { -20, -5, -14 },
                    { -19, -2, -14 },
                    { -18, -7, -13 },
                    { -17, -6, -12 },
                    { -16, -6, -11 },
                    { -15, -3, -11 },
                    { -14, -1, -10 },
                    { -13, -1, -9 },
                    { -12, -10, -8 },
                    { -11, -9, -8 },
                    { -10, -8, -8 },
                    { -9, -8, -7 },
                    { -8, -9, -6 },
                    { -7, -8, -6 },
                    { -6, -10, -5 },
                    { -5, -3, -4 },
                    { -4, -7, -3 },
                    { -3, -2, -3 },
                    { -2, -3, -2 },
                    { -1, -4, -1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Koppels_OnderwerpId",
                table: "Koppels",
                column: "OnderwerpId");

            migrationBuilder.CreateIndex(
                name: "IX_Koppels_VideoId",
                table: "Koppels",
                column: "VideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Koppels");

            migrationBuilder.DropTable(
                name: "Onderwerpen");

            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
