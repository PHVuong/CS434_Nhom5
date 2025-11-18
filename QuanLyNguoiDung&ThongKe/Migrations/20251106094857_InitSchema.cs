using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMotoRental.Migrations
{
    /// <inheritdoc />
    public partial class InitSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motorbikes",
                columns: table => new
                {
                    BikeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Brand = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Year = table.Column<int>(type: "INTEGER", nullable: true),
                    PlateNumber = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Condition = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    PricePerDay = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    Location = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorbikes", x => x.BikeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "BikeImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BikeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeImages", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_BikeImages_Motorbikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Motorbikes",
                        principalColumn: "BikeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatLogs",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Sender = table.Column<int>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: true),
                    Response = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatLogs", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_ChatLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BikeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => new { x.UserId, x.BikeId });
                    table.ForeignKey(
                        name: "FK_Favorites_Motorbikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Motorbikes",
                        principalColumn: "BikeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    IsRead = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BikeId = table.Column<int>(type: "INTEGER", nullable: false),
                    PickupTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReturnTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    PaymentMethod = table.Column<int>(type: "INTEGER", nullable: true),
                    PaymentPaidAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_Rentals_Motorbikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Motorbikes",
                        principalColumn: "BikeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewsRatings",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BikeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<byte>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Body = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewsRatings", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_ReviewsRatings_Motorbikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Motorbikes",
                        principalColumn: "BikeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewsRatings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suggestions",
                columns: table => new
                {
                    SuggestionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BikeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestions", x => x.SuggestionId);
                    table.ForeignKey(
                        name: "FK_Suggestions_Motorbikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Motorbikes",
                        principalColumn: "BikeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suggestions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BikeImages_BikeId",
                table: "BikeImages",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatLogs_UserId",
                table: "ChatLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_BikeId",
                table: "Favorites",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Motorbikes_PlateNumber",
                table: "Motorbikes",
                column: "PlateNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_BikeId",
                table: "Rentals",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsRatings_BikeId",
                table: "ReviewsRatings",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsRatings_UserId",
                table: "ReviewsRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_BikeId",
                table: "Suggestions",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_UserId",
                table: "Suggestions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BikeImages");

            migrationBuilder.DropTable(
                name: "ChatLogs");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "ReviewsRatings");

            migrationBuilder.DropTable(
                name: "Suggestions");

            migrationBuilder.DropTable(
                name: "Motorbikes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
