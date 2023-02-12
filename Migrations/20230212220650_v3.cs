using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwapMeAngularAuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Games_GameId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_UserId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Platforms_Offers_OfferId",
                table: "Platforms");

            migrationBuilder.DropIndex(
                name: "IX_Platforms_OfferId",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Platforms");

            migrationBuilder.AddColumn<int>(
                name: "PlatformId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageFile",
                table: "Images",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_PlatformId",
                table: "Offers",
                column: "PlatformId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Games_GameId",
                table: "Offers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Platforms_PlatformId",
                table: "Offers",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "PlatformId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_UserId",
                table: "Offers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Games_GameId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Platforms_PlatformId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_UserId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_PlatformId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "Offers");

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Platforms",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageFile",
                table: "Images",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_OfferId",
                table: "Platforms",
                column: "OfferId",
                unique: true,
                filter: "[OfferId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Games_GameId",
                table: "Offers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_UserId",
                table: "Offers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Platforms_Offers_OfferId",
                table: "Platforms",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "OfferId");
        }
    }
}
