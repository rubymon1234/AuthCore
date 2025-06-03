using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppyWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class createcolumcatagoryid2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CatagoryId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("4CD79D1A-2121-4D9A-8FE2-3304F0ECBC35"));

            migrationBuilder.CreateIndex(
                name: "IX_Product_CatagoryId",
                table: "Product",
                column: "CatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCatagory_CatagoryId",
                table: "Product",
                column: "CatagoryId",
                principalTable: "ProductCatagory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCatagory_CatagoryId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CatagoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CatagoryId",
                table: "Product");
        }
    }
}
