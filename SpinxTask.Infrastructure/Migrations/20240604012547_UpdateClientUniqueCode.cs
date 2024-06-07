using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinxTask.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClientUniqueCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clients_Code",
                table: "Clients",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clients_Code",
                table: "Clients");
        }
    }
}
