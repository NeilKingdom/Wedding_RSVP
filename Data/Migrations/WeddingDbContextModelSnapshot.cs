﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Wedding_RSVP.Data;

#nullable disable

namespace Wedding_RSVP.Data.Migrations
{
    [DbContext(typeof(WeddingDbContext))]
    partial class WeddingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Wedding_RSVP.Models.Attendee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("AttendeeID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<int?>("UserID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Attendee", (string)null);
                });

            modelBuilder.Entity("Wedding_RSVP.Models.Gift", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("GiftID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<string>("Desc")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<decimal>("EstPrice")
                        .HasColumnType("money");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("text");

                    b.Property<string>("SiteUrl")
                        .HasColumnType("text");

                    b.Property<int?>("UserID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Gift", (string)null);
                });

            modelBuilder.Entity("Wedding_RSVP.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("UserID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsRsvpd")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumAttendees")
                        .HasColumnType("integer");

                    b.Property<string>("OtherInfo")
                        .HasColumnType("text");

                    b.Property<string>("SongRequest")
                        .HasColumnType("text");

                    b.Property<int>("UserCodeID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("UserCodeID")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Wedding_RSVP.Models.UserCode", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("character varying(9)");

                    b.HasKey("ID");

                    b.ToTable("UserCode", (string)null);
                });

            modelBuilder.Entity("Wedding_RSVP.Models.Attendee", b =>
                {
                    b.HasOne("Wedding_RSVP.Models.User", "User")
                        .WithMany("Attendees")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wedding_RSVP.Models.Gift", b =>
                {
                    b.HasOne("Wedding_RSVP.Models.User", "User")
                        .WithMany("Gifts")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wedding_RSVP.Models.User", b =>
                {
                    b.HasOne("Wedding_RSVP.Models.UserCode", "UserCode")
                        .WithOne("User")
                        .HasForeignKey("Wedding_RSVP.Models.User", "UserCodeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCode");
                });

            modelBuilder.Entity("Wedding_RSVP.Models.User", b =>
                {
                    b.Navigation("Attendees");

                    b.Navigation("Gifts");
                });

            modelBuilder.Entity("Wedding_RSVP.Models.UserCode", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
