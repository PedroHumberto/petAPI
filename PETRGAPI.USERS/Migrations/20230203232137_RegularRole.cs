using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersAPI.Migrations
{
    /// <inheritdoc />
    public partial class RegularRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, null, "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea202c36-c1b4-4900-a021-b87ff14eed65", "AQAAAAIAAYagAAAAEBE/FZeKAm5GBD2GvcuFogVTFX9e/eqU3plsksuDiBO8hxAMwDeezRdqJOUr21rJbg==", "068db599-a01f-4be8-a736-322edf03b6ed" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa66c1af-06b3-446f-a4ff-5c0585ada52e", "AQAAAAIAAYagAAAAEJk8Uta+/Th/Fvfj5Er78c4y4DsNh8SsMEctNAOaK/AEuQ9E+lOxY1JQ907FPU4jxA==", "b0d0320d-a8d3-43f2-92d4-b4b813b7aa25" });
        }
    }
}
