using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomUserIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "BirthDate", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "37dbbce3-f024-42c4-bfcd-e77e602ad8e6", "AQAAAAIAAYagAAAAEIXFFfIgLlrUnpYyGgVBpSldELwFNi9AZc9L8vX9cRkXf14ci3gEqElWJ5SprIF46g==", "b2ec54c5-d803-4859-9413-d632341fc25d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea202c36-c1b4-4900-a021-b87ff14eed65", "AQAAAAIAAYagAAAAEBE/FZeKAm5GBD2GvcuFogVTFX9e/eqU3plsksuDiBO8hxAMwDeezRdqJOUr21rJbg==", "068db599-a01f-4be8-a736-322edf03b6ed" });
        }
    }
}
