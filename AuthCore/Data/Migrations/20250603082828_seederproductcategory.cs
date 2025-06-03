using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppyWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class seederproductcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCatagory",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsActive", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("4cd79d1a-2121-4d9a-8fe2-3304f0ecbc35"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "toys" },
                    { new Guid("91e6947c-ad75-4b86-a7fe-fa500ad7e97c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "electronics" },
                    { new Guid("acbf4445-e4e6-4953-9906-feba13f5c0ad"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "snacks" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCatagory",
                keyColumn: "Id",
                keyValue: new Guid("4cd79d1a-2121-4d9a-8fe2-3304f0ecbc35"));

            migrationBuilder.DeleteData(
                table: "ProductCatagory",
                keyColumn: "Id",
                keyValue: new Guid("91e6947c-ad75-4b86-a7fe-fa500ad7e97c"));

            migrationBuilder.DeleteData(
                table: "ProductCatagory",
                keyColumn: "Id",
                keyValue: new Guid("acbf4445-e4e6-4953-9906-feba13f5c0ad"));
        }
    }
}
