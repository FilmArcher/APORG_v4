﻿// <auto-generated />
using APORG_v4.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace APORG_v4.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180602175417_addOrganizerSocialMediaToDb")]
    partial class addOrganizerSocialMediaToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APORG_v4.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("APORG_v4.Model.Event", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Descryption")
                        .IsRequired();

                    b.Property<string>("Image");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PlaceId");

                    b.Property<string>("Tickets");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("id");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("APORG_v4.Model.Musician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Biography");

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<DateTime>("Creation_date");

                    b.Property<string>("Description");

                    b.Property<bool>("Discography");

                    b.Property<string>("First_name_manager")
                        .IsRequired();

                    b.Property<string>("Genre")
                        .IsRequired();

                    b.Property<string>("Image");

                    b.Property<string>("Last_name_manager")
                        .IsRequired();

                    b.Property<string>("Manager_contact")
                        .IsRequired();

                    b.Property<bool>("Merch");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Region")
                        .IsRequired();

                    b.Property<string>("Town")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Musicians");
                });

            modelBuilder.Entity("APORG_v4.Model.MusicianMerchType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Availability");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<int>("MusicianId");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.HasIndex("MusicianId");

                    b.ToTable("MusicianMerchTypes");
                });

            modelBuilder.Entity("APORG_v4.Model.MusicianSocialMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MediaName")
                        .HasMaxLength(69);

                    b.Property<int>("MusicianId");

                    b.Property<string>("UrlAddress");

                    b.HasKey("Id");

                    b.HasIndex("MusicianId");

                    b.ToTable("MusicianSocialMedias");
                });

            modelBuilder.Entity("APORG_v4.Model.Object", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image");

                    b.Property<string>("Stage_comments");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<bool>("acoustics");

                    b.Property<string>("acoustics_contact");

                    b.Property<bool>("backline");

                    b.Property<string>("backline_description");

                    b.Property<bool>("backstage");

                    b.Property<string>("backstage_description");

                    b.Property<double>("backstage_surface");

                    b.Property<bool>("bar");

                    b.Property<string>("bar_desc");

                    b.Property<bool>("cloakroom");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasMaxLength(69);

                    b.Property<int>("cubature");

                    b.Property<bool>("frontline");

                    b.Property<string>("frontline_description");

                    b.Property<bool>("garden");

                    b.Property<bool>("lighting_technician");

                    b.Property<string>("lighting_technician_contact");

                    b.Property<bool>("lights");

                    b.Property<string>("lights_description");

                    b.Property<string>("manager_contact");

                    b.Property<string>("manager_email");

                    b.Property<string>("manager_lastname")
                        .HasMaxLength(69);

                    b.Property<string>("manager_name")
                        .HasMaxLength(69);

                    b.Property<int>("no_building");

                    b.Property<string>("object_desc")
                        .HasMaxLength(300);

                    b.Property<string>("object_name")
                        .IsRequired()
                        .HasMaxLength(69);

                    b.Property<double>("object_surface");

                    b.Property<bool>("parking");

                    b.Property<string>("post_code")
                        .IsRequired();

                    b.Property<string>("region")
                        .IsRequired()
                        .HasMaxLength(69);

                    b.Property<bool>("safeguard");

                    b.Property<bool>("stage");

                    b.Property<float>("stage_surface");

                    b.Property<string>("street")
                        .IsRequired()
                        .HasMaxLength(69);

                    b.Property<string>("town")
                        .IsRequired()
                        .HasMaxLength(69);

                    b.HasKey("Id");

                    b.ToTable("Objects");
                });

            modelBuilder.Entity("APORG_v4.Model.ObjectMerchType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Availability");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<int>("ObjectId");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.HasIndex("ObjectId");

                    b.ToTable("ObjectMerchTypes");
                });

            modelBuilder.Entity("APORG_v4.Model.ObjectSocialMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MediaName")
                        .HasMaxLength(69);

                    b.Property<int>("ObjectId");

                    b.Property<string>("UrlAddress");

                    b.HasKey("Id");

                    b.HasIndex("ObjectId");

                    b.ToTable("ObjectSocialMedias");
                });

            modelBuilder.Entity("APORG_v4.Model.Organizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contact")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Region")
                        .IsRequired();

                    b.Property<string>("Town")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Organizers");
                });

            modelBuilder.Entity("APORG_v4.Model.OrganizerMerchType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Availability");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<int>("OrganizerId");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.ToTable("OrganizerMerchTypes");
                });

            modelBuilder.Entity("APORG_v4.Model.OrganizerSocialMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MediaName")
                        .HasMaxLength(69);

                    b.Property<int>("OrganizerId");

                    b.Property<string>("UrlAddress");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.ToTable("OrganizerSocialMedias");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("APORG_v4.Model.Event", b =>
                {
                    b.HasOne("APORG_v4.Model.Object", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("APORG_v4.Data.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APORG_v4.Model.Musician", b =>
                {
                    b.HasOne("APORG_v4.Data.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APORG_v4.Model.MusicianMerchType", b =>
                {
                    b.HasOne("APORG_v4.Model.Musician", "Musician")
                        .WithMany()
                        .HasForeignKey("MusicianId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APORG_v4.Model.MusicianSocialMedia", b =>
                {
                    b.HasOne("APORG_v4.Model.Musician", "Musician")
                        .WithMany()
                        .HasForeignKey("MusicianId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APORG_v4.Model.ObjectMerchType", b =>
                {
                    b.HasOne("APORG_v4.Model.Object", "Object")
                        .WithMany()
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APORG_v4.Model.ObjectSocialMedia", b =>
                {
                    b.HasOne("APORG_v4.Model.Object", "Object")
                        .WithMany()
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APORG_v4.Model.Organizer", b =>
                {
                    b.HasOne("APORG_v4.Data.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APORG_v4.Model.OrganizerMerchType", b =>
                {
                    b.HasOne("APORG_v4.Model.Organizer", "Organizer")
                        .WithMany()
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APORG_v4.Model.OrganizerSocialMedia", b =>
                {
                    b.HasOne("APORG_v4.Model.Organizer", "Organizer")
                        .WithMany()
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("APORG_v4.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("APORG_v4.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("APORG_v4.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("APORG_v4.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
