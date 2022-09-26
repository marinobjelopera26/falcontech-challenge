using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FalconTech.Challenge.DataLayer.Migrations
{
    public partial class CreateInitialEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SYSUSER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SYSDATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    SYSUSER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SYSDATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SYSUSER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SYSDATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.GenresId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    SYSUSER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SYSDATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    WasAccepted = table.Column<bool>(type: "bit", nullable: false),
                    SYSUSER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SYSDATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => new { x.UserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_Invitations_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invitations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieUser",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieUser", x => new { x.MoviesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_MovieUser_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name", "SYSDATE", "SYSUSER" },
                values: new object[,]
                {
                    { 1, "Action movie", "Action", new DateTime(2022, 9, 26, 19, 36, 56, 983, DateTimeKind.Local).AddTicks(5073), "Init" },
                    { 2, "Adventure movie", "Adventure", new DateTime(2022, 9, 26, 19, 36, 56, 983, DateTimeKind.Local).AddTicks(5076), "Init" },
                    { 3, "Comedy movie", "Comedy", new DateTime(2022, 9, 26, 19, 36, 56, 983, DateTimeKind.Local).AddTicks(5078), "Init" },
                    { 4, "Crime movie", "Crime", new DateTime(2022, 9, 26, 19, 36, 56, 983, DateTimeKind.Local).AddTicks(5080), "Init" },
                    { 5, "Drama movie", "Drama", new DateTime(2022, 9, 26, 19, 36, 56, 983, DateTimeKind.Local).AddTicks(5082), "Init" },
                    { 6, "Fantasy movie", "Fantasy", new DateTime(2022, 9, 26, 19, 36, 56, 983, DateTimeKind.Local).AddTicks(5083), "Init" },
                    { 7, "Historical movie", "Historical", new DateTime(2022, 9, 26, 19, 36, 56, 983, DateTimeKind.Local).AddTicks(5085), "Init" },
                    { 8, "Horror movie", "Horror", new DateTime(2022, 9, 26, 19, 36, 56, 983, DateTimeKind.Local).AddTicks(5087), "Init" },
                    { 9, "Romantic movie", "Romance", new DateTime(2022, 9, 26, 19, 36, 56, 983, DateTimeKind.Local).AddTicks(5089), "Init" },
                    { 10, "Satire movie", "Satire", new DateTime(2022, 9, 26, 19, 36, 56, 983, DateTimeKind.Local).AddTicks(5091), "Init" },
                    { 11, "Science fiction movie", "Sci-Fi", new DateTime(2022, 9, 26, 19, 36, 56, 983, DateTimeKind.Local).AddTicks(5093), "Init" },
                    { 12, "Action movie", "Thriller", new DateTime(2022, 9, 26, 19, 36, 56, 983, DateTimeKind.Local).AddTicks(5095), "Init" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "SYSDATE", "SYSUSER" },
                values: new object[,]
                {
                    { 1, "SuperAdmin", new DateTime(2022, 9, 26, 19, 36, 56, 983, DateTimeKind.Local).AddTicks(4928), "Init" },
                    { 2, "Director", new DateTime(2022, 9, 26, 19, 36, 56, 983, DateTimeKind.Local).AddTicks(4958), "Init" },
                    { 3, "Actor", new DateTime(2022, 9, 26, 19, 36, 56, 983, DateTimeKind.Local).AddTicks(4960), "Init" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_MoviesId",
                table: "GenreMovie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_MovieId",
                table: "Invitations",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieUser_UsersId",
                table: "MovieUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.DropTable(
                name: "Invitations");

            migrationBuilder.DropTable(
                name: "MovieUser");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
