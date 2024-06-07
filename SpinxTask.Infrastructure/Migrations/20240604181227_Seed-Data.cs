using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpinxTask.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        string AId          = Guid.NewGuid().ToString();
        string BId          = Guid.NewGuid().ToString();
        string CId          = Guid.NewGuid().ToString();

        string InactiveId   = Guid.NewGuid().ToString();
        string ActiveId     = Guid.NewGuid().ToString();
        string PendingId    = Guid.NewGuid().ToString();
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { AId, "A" },
                    { BId, "B" },
                    { CId, "C" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { InactiveId, "Inactive" },
                    { ActiveId, "Active" },
                    { PendingId, "Pending" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: AId);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: BId);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: CId);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: InactiveId);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: ActiveId);

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: PendingId);
        }
    }
}
