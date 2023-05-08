﻿
using Microsoft.EntityFrameworkCore;
using VK_Users.Context.Entities;

namespace VK_Users.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { 
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<User>().HasKey(e => e.Uid);
        modelBuilder.Entity<User>().Property(e => e.Uid).HasColumnName("uid");
        modelBuilder.Entity<User>().Property(e => e.Login).HasColumnName("login");
        modelBuilder.Entity<User>().Property(e => e.PasswordHash).HasColumnName("password_hash");
        modelBuilder.Entity<User>().Property(e => e.CreatedDate).HasColumnName("created_date");
        modelBuilder.Entity<User>().Property(e => e.UserGroupUid).HasColumnName("user_group_uid");
        modelBuilder.Entity<User>().Property(e => e.UserStateUid).HasColumnName("user_state_uid");
        modelBuilder.Entity<User>().HasOne(e => e.UserGroup).WithMany(e => e.Users);
        modelBuilder.Entity<User>().HasOne(e => e.UserState).WithMany(e => e.Users);

        modelBuilder.Entity<UserGroup>().ToTable("user_groups");
        modelBuilder.Entity<UserGroup>().Property(e => e.Id).HasColumnName("id");
        modelBuilder.Entity<UserGroup>().Property(e => e.Code).HasColumnName("code");
        modelBuilder.Entity<UserGroup>().Property(e => e.Description).HasColumnName("description");

        modelBuilder.Entity<UserState>().ToTable("user_states");
        modelBuilder.Entity<UserState>().Property(e => e.Id).HasColumnName("id");
        modelBuilder.Entity<UserState>().Property(e => e.Code).HasColumnName("code");
        modelBuilder.Entity<UserState>().Property(e => e.Description).HasColumnName("description");
    }
}
