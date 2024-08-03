using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairdressingSalons.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "HairdressingSalons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HairdressingSalons_CreatedById",
                table: "HairdressingSalons",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_HairdressingSalons_AspNetUsers_CreatedById",
                table: "HairdressingSalons",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HairdressingSalons_AspNetUsers_CreatedById",
                table: "HairdressingSalons");

            migrationBuilder.DropIndex(
                name: "IX_HairdressingSalons_CreatedById",
                table: "HairdressingSalons");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "HairdressingSalons");
        }
    }
}
