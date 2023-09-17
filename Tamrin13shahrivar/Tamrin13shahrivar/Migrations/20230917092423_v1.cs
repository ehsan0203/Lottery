using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tamrin13shahrivar.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lottery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleLottery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberShares = table.Column<int>(type: "int", nullable: false),
                    AmountShares = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lottery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LotteryMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberMemberShares = table.Column<int>(type: "int", nullable: false),
                    CodeMelli = table.Column<long>(type: "bigint", nullable: false),
                    lotteryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotteryMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LotteryMembers_Lottery_lotteryId",
                        column: x => x.lotteryId,
                        principalTable: "Lottery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstallMents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateLottery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LotteryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumLottery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LotteryMemberId = table.Column<int>(type: "int", nullable: false),
                    Mount = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallMents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstallMents_LotteryMembers_LotteryMemberId",
                        column: x => x.LotteryMemberId,
                        principalTable: "LotteryMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Winners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthWin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberWinner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LotteryMemberid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Winners_LotteryMembers_LotteryMemberid",
                        column: x => x.LotteryMemberid,
                        principalTable: "LotteryMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstallMents_LotteryMemberId",
                table: "InstallMents",
                column: "LotteryMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_LotteryMembers_lotteryId",
                table: "LotteryMembers",
                column: "lotteryId");

            migrationBuilder.CreateIndex(
                name: "IX_Winners_LotteryMemberid",
                table: "Winners",
                column: "LotteryMemberid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstallMents");

            migrationBuilder.DropTable(
                name: "Winners");

            migrationBuilder.DropTable(
                name: "LotteryMembers");

            migrationBuilder.DropTable(
                name: "Lottery");
        }
    }
}
