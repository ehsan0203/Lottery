﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tamrin13shahrivar.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LotteryName",
                table: "InstallMents");

            migrationBuilder.AlterColumn<int>(
                name: "NumLottery",
                table: "InstallMents",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumLottery",
                table: "InstallMents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "LotteryName",
                table: "InstallMents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}