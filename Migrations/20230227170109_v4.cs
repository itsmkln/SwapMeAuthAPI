using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwapMeAngularAuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Offers_OfferTypeId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_PlatformId",
                table: "Offers");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_OfferTypeId",
                table: "Offers",
                column: "OfferTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_PlatformId",
                table: "Offers",
                column: "PlatformId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Offers_OfferTypeId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_PlatformId",
                table: "Offers");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_OfferTypeId",
                table: "Offers",
                column: "OfferTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_PlatformId",
                table: "Offers",
                column: "PlatformId",
                unique: true);
        }
    }
}
