﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tamrin13shahrivar.Date;

#nullable disable

namespace Tamrin13shahrivar.Migrations
{
    [DbContext(typeof(WinnerDbContext))]
    [Migration("20230917101714_v4")]
    partial class v4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tamrin13shahrivar.Model.InstallMents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateLottery")
                        .HasColumnType("datetime2");

                    b.Property<int>("LotteryMemberId")
                        .HasColumnType("int");

                    b.Property<long>("Mount")
                        .HasColumnType("bigint");

                    b.Property<int>("NumLottery")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LotteryMemberId");

                    b.ToTable("InstallMents");
                });

            modelBuilder.Entity("Tamrin13shahrivar.Model.Lottery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("AmountShares")
                        .HasColumnType("bigint");

                    b.Property<int>("NumberShares")
                        .HasColumnType("int");

                    b.Property<string>("TitleLottery")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lottery");
                });

            modelBuilder.Entity("Tamrin13shahrivar.Model.LotteryMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("CodeMelli")
                        .HasColumnType("bigint");

                    b.Property<string>("MemberFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberMemberShares")
                        .HasColumnType("int");

                    b.Property<int>("lotteryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("lotteryId");

                    b.ToTable("LotteryMembers");
                });

            modelBuilder.Entity("Tamrin13shahrivar.Model.Winner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LotteryMemberid")
                        .HasColumnType("int");

                    b.Property<string>("MemberWinner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MonthWin")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumLottery")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LotteryMemberid");

                    b.ToTable("Winners");
                });

            modelBuilder.Entity("Tamrin13shahrivar.Model.InstallMents", b =>
                {
                    b.HasOne("Tamrin13shahrivar.Model.LotteryMember", "LotteryMember")
                        .WithMany()
                        .HasForeignKey("LotteryMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LotteryMember");
                });

            modelBuilder.Entity("Tamrin13shahrivar.Model.LotteryMember", b =>
                {
                    b.HasOne("Tamrin13shahrivar.Model.Lottery", "Lottery")
                        .WithMany()
                        .HasForeignKey("lotteryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lottery");
                });

            modelBuilder.Entity("Tamrin13shahrivar.Model.Winner", b =>
                {
                    b.HasOne("Tamrin13shahrivar.Model.LotteryMember", "LotteryMember")
                        .WithMany()
                        .HasForeignKey("LotteryMemberid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LotteryMember");
                });
#pragma warning restore 612, 618
        }
    }
}
