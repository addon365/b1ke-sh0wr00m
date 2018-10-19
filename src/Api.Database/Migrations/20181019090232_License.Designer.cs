﻿// <auto-generated />
using System;
using Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Database.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20181019090232_License")]
    partial class License
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("swc")
                .HasAnnotation("ProductVersion", "2.2.0-preview2-35157")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Database.Entity.BranchMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<string>("BranchName");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<Guid>("LicenseId");

                    b.Property<string>("Location");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("ProgrammerID");

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.ToTable("BranchMaster");
                });

            modelBuilder.Entity("Api.Database.Entity.Enquiries.Enquiry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<Guid>("EnquiryTypeId");

                    b.Property<string>("Identifier");

                    b.Property<DateTime>("Modified");

                    b.Property<Guid>("ProfileId");

                    b.Property<Guid>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.HasIndex("EnquiryTypeId");

                    b.HasIndex("ProfileId");

                    b.HasIndex("StatusId");

                    b.ToTable("Enquiries");
                });

            modelBuilder.Entity("Api.Database.Entity.Enquiries.EnquiryAccessories", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccessoriesId");

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<Guid>("EnquiryId");

                    b.Property<string>("Identifier");

                    b.Property<DateTime>("Modified");

                    b.Property<Guid>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.HasIndex("EnquiryId");

                    b.HasIndex("ProductId");

                    b.ToTable("EnquiryAccessories");
                });

            modelBuilder.Entity("Api.Database.Entity.Enquiries.EnquiryExchangeQuotation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<Guid>("EnquiryId");

                    b.Property<double>("Expected");

                    b.Property<string>("Identifier");

                    b.Property<string>("Model");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("NoOfOwner");

                    b.Property<double>("Quotated");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.HasIndex("EnquiryId");

                    b.ToTable("EnquiryExchangeQuotations");
                });

            modelBuilder.Entity("Api.Database.Entity.Enquiries.EnquiryFinanceQuotation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<double>("DownPayment");

                    b.Property<double>("EMIAmount");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<Guid>("EnquiryId");

                    b.Property<string>("Identifier");

                    b.Property<DateTime>("Modified");

                    b.Property<Guid>("ProductId");

                    b.Property<int>("TenureInMonths");

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.HasIndex("EnquiryId");

                    b.HasIndex("ProductId");

                    b.ToTable("EnquiryFinanceQuotations");
                });

            modelBuilder.Entity("Api.Database.Entity.Enquiries.EnquiryProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AccessoriesAmount");

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<Guid>("EnquiryId");

                    b.Property<DateTime>("Modified");

                    b.Property<double>("OnRoadPrice");

                    b.Property<Guid>("ProductId");

                    b.Property<double>("TotalAmount");

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.HasIndex("EnquiryId");

                    b.HasIndex("ProductId");

                    b.ToTable("EnquiryProducts");
                });

            modelBuilder.Entity("Api.Database.Entity.Enquiries.EnquiryStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<Guid?>("EmployeeId");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<int>("ProgrammerId");

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.ToTable("EnquiryStatuses");
                });

            modelBuilder.Entity("Api.Database.Entity.Enquiries.EnquiryType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ProgrammerId");

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.ToTable("EnquriyType");
                });

            modelBuilder.Entity("Api.Database.Entity.LicenseMaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessName");

                    b.Property<string>("LicenseId");

                    b.Property<string>("Location");

                    b.Property<int>("ProgrammerID");

                    b.HasKey("Id");

                    b.ToTable("LicenseMasters");
                });

            modelBuilder.Entity("Api.Database.Entity.MarketingZone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<string>("Identifier");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("ZonalDescription");

                    b.Property<string>("ZonalName");

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.ToTable("marketingZones");
                });

            modelBuilder.Entity("Api.Database.Entity.Products.ExtraFittingsAccessories", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccessoriesProductId");

                    b.Property<Guid?>("AccessoriesProductsId");

                    b.Property<double>("Amount");

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<DateTime>("Modified");

                    b.Property<Guid>("ProductId");

                    b.Property<double>("Unit");

                    b.Property<double>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("AccessoriesProductsId");

                    b.HasIndex("BranchMasterId");

                    b.HasIndex("ProductId");

                    b.ToTable("ExtraFittings");
                });

            modelBuilder.Entity("Api.Database.Entity.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<Guid>("CompanyId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<double>("GST");

                    b.Property<string>("HSN");

                    b.Property<string>("Identifier");

                    b.Property<double>("InsuranceAmount");

                    b.Property<DateTime>("Modified");

                    b.Property<double>("Price");

                    b.Property<string>("ProductName");

                    b.Property<double>("RoadTax");

                    b.Property<Guid>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Api.Database.Entity.Products.ProductCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<string>("CompanyName");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<string>("Identifier");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("ProgrammerID");

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.ToTable("ProductCompanies");
                });

            modelBuilder.Entity("Api.Database.Entity.Products.ProductType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<string>("Identifier");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<Guid>("ParentId");

                    b.Property<int>("ProgrammerId");

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("Api.Database.Entity.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<string>("Identifier");

                    b.Property<string>("MobileNumber");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<string>("Place");

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Api.Database.Entity.Threats.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<Guid?>("EmployeeId");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Api.Database.Entity.Threats.Threat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<string>("Host");

                    b.Property<string>("Identifier")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("CONCAT('swc-',[Id])");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Protocol");

                    b.Property<string>("QueryString");

                    b.Property<string>("Referer")
                        .HasMaxLength(255);

                    b.Property<Guid>("StatusId");

                    b.Property<Guid>("TypeId");

                    b.Property<string>("UserAgent");

                    b.Property<string>("XForwardHost");

                    b.Property<string>("XForwardProto");

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.HasIndex("Referer")
                        .IsUnique()
                        .HasFilter("[Referer] IS NOT NULL");

                    b.HasIndex("StatusId");

                    b.HasIndex("TypeId");

                    b.ToTable("Threats");
                });

            modelBuilder.Entity("Api.Database.Entity.Threats.ThreatType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("Api.Database.Entity.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BranchMasterId");

                    b.Property<string>("ConfirmPassword");

                    b.Property<DateTime>("Created");

                    b.Property<Guid?>("CreatedDeviceId");

                    b.Property<Guid?>("CreatedUserId");

                    b.Property<DateTime>("Deleted");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Password");

                    b.Property<string>("SessionToken");

                    b.Property<string>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("BranchMasterId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Api.Database.Entity.BranchMaster", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");
                });

            modelBuilder.Entity("Api.Database.Entity.Enquiries.Enquiry", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");

                    b.HasOne("Api.Database.Entity.Enquiries.EnquiryType", "EnquiryType")
                        .WithMany("Enquiries")
                        .HasForeignKey("EnquiryTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Database.Entity.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Database.Entity.Enquiries.EnquiryStatus", "Status")
                        .WithMany("Enquiries")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Database.Entity.Enquiries.EnquiryAccessories", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");

                    b.HasOne("Api.Database.Entity.Enquiries.Enquiry", "enquiry")
                        .WithMany()
                        .HasForeignKey("EnquiryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Database.Entity.Products.Product", "product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Database.Entity.Enquiries.EnquiryExchangeQuotation", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");

                    b.HasOne("Api.Database.Entity.Enquiries.Enquiry", "enquiry")
                        .WithMany()
                        .HasForeignKey("EnquiryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Database.Entity.Enquiries.EnquiryFinanceQuotation", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");

                    b.HasOne("Api.Database.Entity.Enquiries.Enquiry", "enquiry")
                        .WithMany()
                        .HasForeignKey("EnquiryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Database.Entity.Products.Product", "product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Database.Entity.Enquiries.EnquiryProduct", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");

                    b.HasOne("Api.Database.Entity.Enquiries.Enquiry", "enquiry")
                        .WithMany()
                        .HasForeignKey("EnquiryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Database.Entity.Products.Product", "product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Database.Entity.Enquiries.EnquiryStatus", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");
                });

            modelBuilder.Entity("Api.Database.Entity.Enquiries.EnquiryType", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");
                });

            modelBuilder.Entity("Api.Database.Entity.MarketingZone", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");
                });

            modelBuilder.Entity("Api.Database.Entity.Products.ExtraFittingsAccessories", b =>
                {
                    b.HasOne("Api.Database.Entity.Products.Product", "AccessoriesProducts")
                        .WithMany()
                        .HasForeignKey("AccessoriesProductsId");

                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");

                    b.HasOne("Api.Database.Entity.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Database.Entity.Products.Product", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");
                });

            modelBuilder.Entity("Api.Database.Entity.Products.ProductCompany", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");
                });

            modelBuilder.Entity("Api.Database.Entity.Products.ProductType", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");
                });

            modelBuilder.Entity("Api.Database.Entity.Profile", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");
                });

            modelBuilder.Entity("Api.Database.Entity.Threats.Status", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");
                });

            modelBuilder.Entity("Api.Database.Entity.Threats.Threat", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");

                    b.HasOne("Api.Database.Entity.Threats.Status", "Status")
                        .WithMany("Threats")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Database.Entity.Threats.ThreatType", "ThreatType")
                        .WithMany("Threats")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Api.Database.Entity.Threats.ThreatType", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");
                });

            modelBuilder.Entity("Api.Database.Entity.User.User", b =>
                {
                    b.HasOne("Api.Database.Entity.BranchMaster", "BranchMaster")
                        .WithMany()
                        .HasForeignKey("BranchMasterId");
                });
#pragma warning restore 612, 618
        }
    }
}
