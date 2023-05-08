﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VK_Users.Context;

#nullable disable

namespace VK_Users.Context.Migrations.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VK_Users.Context.Entities.User", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("uid");

                    b.Property<DateOnly>("CreatedDate")
                        .HasColumnType("date")
                        .HasColumnName("created_date");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<int>("UserGroupId")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserGroupUid")
                        .HasColumnType("uuid")
                        .HasColumnName("user_group_uid");

                    b.Property<int>("UserStateId")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserStateUid")
                        .HasColumnType("uuid")
                        .HasColumnName("user_state_uid");

                    b.HasKey("Uid");

                    b.HasIndex("UserGroupId");

                    b.HasIndex("UserStateId");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("VK_Users.Context.Entities.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("integer")
                        .HasColumnName("code");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.HasKey("Id");

                    b.ToTable("user_groups", (string)null);
                });

            modelBuilder.Entity("VK_Users.Context.Entities.UserState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("integer")
                        .HasColumnName("code");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.HasKey("Id");

                    b.ToTable("user_states", (string)null);
                });

            modelBuilder.Entity("VK_Users.Context.Entities.User", b =>
                {
                    b.HasOne("VK_Users.Context.Entities.UserGroup", "UserGroup")
                        .WithMany("Users")
                        .HasForeignKey("UserGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VK_Users.Context.Entities.UserState", "UserState")
                        .WithMany("Users")
                        .HasForeignKey("UserStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserGroup");

                    b.Navigation("UserState");
                });

            modelBuilder.Entity("VK_Users.Context.Entities.UserGroup", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("VK_Users.Context.Entities.UserState", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
