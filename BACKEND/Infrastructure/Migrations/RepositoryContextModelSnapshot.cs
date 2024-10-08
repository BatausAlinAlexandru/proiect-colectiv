﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.User.UserAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User.UserAccount", b =>
                {
                    b.OwnsOne("Domain.Entities.UserAggregate.UserAccountCredentials", "UserAccountCredentials", b1 =>
                        {
                            b1.Property<Guid>("UserAccountId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Role")
                                .HasColumnType("int");

                            b1.HasKey("UserAccountId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserAccountId");
                        });

                    b.OwnsOne("Domain.Entities.UserAggregate.UserAccountSettings", "UserAccountSettings", b1 =>
                        {
                            b1.Property<Guid>("UserAccountId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Test")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserAccountId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserAccountId");
                        });

                    b.Navigation("UserAccountCredentials")
                        .IsRequired();

                    b.Navigation("UserAccountSettings")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
