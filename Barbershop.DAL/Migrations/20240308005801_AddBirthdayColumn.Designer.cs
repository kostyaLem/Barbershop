﻿// <auto-generated />
using System;
using Barbershop.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Barbershop.DAL.Migrations
{
    [DbContext(typeof(BarbershopContext))]
    [Migration("20240308005801_AddBirthdayColumn")]
    partial class AddBirthdayColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Barbershop.Domain.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("Barbershop.Domain.Models.Barber", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SkillLevel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Barber", (string)null);
                });

            modelBuilder.Entity("Barbershop.Domain.Models.BarbershopParameterRow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("JuniorServiceSalePercent")
                        .HasColumnType("integer");

                    b.Property<int>("MiddleServiceSalePercent")
                        .HasColumnType("integer");

                    b.Property<int>("PercentFromProductSelling")
                        .HasColumnType("integer");

                    b.Property<int>("SeniorServiceSalePercent")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("WorkDayEndsOn")
                        .HasColumnType("integer");

                    b.Property<int>("WorkDayStartsOn")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("BarbershopParameterRows");
                });

            modelBuilder.Entity("Barbershop.Domain.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("Barbershop.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BarberId")
                        .HasColumnType("integer");

                    b.Property<int>("BarbersGain")
                        .HasColumnType("integer");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CompletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BarberId");

                    b.HasIndex("ClientId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Barbershop.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Barbershop.Domain.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Service", (string)null);
                });

            modelBuilder.Entity("Barbershop.Domain.Models.ServiceSkillLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<int>("MinutesDuration")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<string>("SkillLevel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceSkillLevel", (string)null);
                });

            modelBuilder.Entity("Barbershop.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("bytea");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductsId")
                        .HasColumnType("integer");

                    b.HasKey("OrdersId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("OrderServiceSkillLevel", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceSkillLevelsId")
                        .HasColumnType("integer");

                    b.HasKey("OrdersId", "ServiceSkillLevelsId");

                    b.HasIndex("ServiceSkillLevelsId");

                    b.ToTable("OrderServiceSkillLevel");
                });

            modelBuilder.Entity("Barbershop.Domain.Models.Admin", b =>
                {
                    b.HasOne("Barbershop.Domain.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("Barbershop.Domain.Models.Admin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Barbershop.Domain.Models.Barber", b =>
                {
                    b.HasOne("Barbershop.Domain.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("Barbershop.Domain.Models.Barber", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Barbershop.Domain.Models.Client", b =>
                {
                    b.HasOne("Barbershop.Domain.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("Barbershop.Domain.Models.Client", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Barbershop.Domain.Models.Order", b =>
                {
                    b.HasOne("Barbershop.Domain.Models.Barber", "Barber")
                        .WithMany("Orders")
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Barbershop.Domain.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Barber");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Barbershop.Domain.Models.ServiceSkillLevel", b =>
                {
                    b.HasOne("Barbershop.Domain.Models.Service", "Service")
                        .WithMany("ServiceSkillLevels")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("Barbershop.Domain.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Barbershop.Domain.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderServiceSkillLevel", b =>
                {
                    b.HasOne("Barbershop.Domain.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Barbershop.Domain.Models.ServiceSkillLevel", null)
                        .WithMany()
                        .HasForeignKey("ServiceSkillLevelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Barbershop.Domain.Models.Barber", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Barbershop.Domain.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Barbershop.Domain.Models.Service", b =>
                {
                    b.Navigation("ServiceSkillLevels");
                });
#pragma warning restore 612, 618
        }
    }
}
