﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tamrin13shahrivar.Date;

#nullable disable

namespace Tamrin13shahrivar.Migrations
{
    [DbContext(typeof(WinnerDbContext))]
    partial class WinnerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("LotteryId")
                        .HasColumnType("int");

                    b.Property<string>("MemberFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberMemberShares")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LotteryId");

                    b.ToTable("LotteryMembers");
                });

            modelBuilder.Entity("Tamrin13shahrivar.Model.Winner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("lotteryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("lotteryId");

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
                        .WithMany("LotteryMembers")
                        .HasForeignKey("LotteryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lottery");
                });

            modelBuilder.Entity("Tamrin13shahrivar.Model.Winner", b =>
                {
                    b.HasOne("Tamrin13shahrivar.Model.Lottery", "Lottery")
                        .WithMany()
                        .HasForeignKey("lotteryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lottery");
                });

            modelBuilder.Entity("Tamrin13shahrivar.Model.Lottery", b =>
                {
                    b.Navigation("LotteryMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
