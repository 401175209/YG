﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YG;

namespace YG.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WalkingTec.Mvvm.Core.ActionLog", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ActionName")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ActionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ActionUrl")
                        .HasColumnType("varchar(250) CHARACTER SET utf8mb4")
                        .HasMaxLength(250);

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Duration")
                        .HasColumnType("double");

                    b.Property<string>("IP")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("ITCode")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<int>("LogType")
                        .HasColumnType("int");

                    b.Property<string>("ModuleName")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("ActionLogs");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.DataPrivilege", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("DomainId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("char(36)");

                    b.Property<string>("RelateId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("DomainId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("DataPrivileges");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FileAttachment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<byte[]>("FileData")
                        .HasColumnType("longblob");

                    b.Property<string>("FileExt")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("GroupName")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<bool>("IsTemprory")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("Length")
                        .HasColumnType("bigint");

                    b.Property<string>("Path")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("SaveFileMode")
                        .HasColumnType("int");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UploadTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("FileAttachments");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkDomain", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("DomainAddress")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EntryUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("DomainName")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<int?>("Port")
                        .HasColumnName("DomainPort")
                        .HasColumnType("int");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("FrameworkDomains");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkGroup", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("GroupCode")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("GroupRemark")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("FrameworkGroups");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkMenu", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ActionName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClassName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DisplayOrder")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<Guid?>("DomainId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("FolderOnly")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ICon")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<bool>("IsInherit")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsInside")
                        .IsRequired()
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MethodName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ModuleName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PageName")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("ShowOnMenu")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.HasIndex("DomainId");

                    b.HasIndex("ParentId");

                    b.ToTable("FrameworkMenus");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkRole", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("RoleCode")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("RoleRemark")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("FrameworkRoles");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkUserBase", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<string>("CellPhone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("HomePhone")
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<string>("ITCode")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<bool>("IsValid")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(32) CHARACTER SET utf8mb4")
                        .HasMaxLength(32);

                    b.Property<Guid?>("PhotoId")
                        .HasColumnType("char(36)");

                    b.Property<int?>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.HasIndex("ITCode")
                        .IsUnique();

                    b.HasIndex("PhotoId");

                    b.ToTable("FrameworkUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("FrameworkUserBase");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkUserGroup", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("char(36)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("FrameworkUserGroup");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkUserRole", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("FrameworkUserRole");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FunctionPrivilege", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool?>("Allowed")
                        .IsRequired()
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("MenuItemId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("MenuItemId");

                    b.ToTable("FunctionPrivileges");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.PersistedGrant", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Type")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.ToTable("PersistedGrants");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.SearchCondition", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Condition")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("VMName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("SearchConditions");
                });

            modelBuilder.Entity("YG.Models.Organ", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsValid")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("OrganCode")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OrganName")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("char(36)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.HasIndex("ParentId");

                    b.ToTable("Organs");
                });

            modelBuilder.Entity("YG.Models.Template", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Context")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsValid")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("YG.Models.Work", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsValid")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<Guid?>("ReceiverId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("StarterId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("TemplateId")
                        .HasColumnType("char(36)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("WithDraw")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("WorkStatus")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("StarterId");

                    b.HasIndex("TemplateId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("YG.Models.WorkHistory", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Advice")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CreateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsValid")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid?>("ReceiverId")
                        .HasColumnType("char(36)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("WorkId")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("WorkId");

                    b.ToTable("WorkHistories");
                });

            modelBuilder.Entity("YG.Models.WorkKeyValue", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Key")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("WorkId")
                        .HasColumnType("char(36)");

                    b.HasKey("ID");

                    b.HasIndex("WorkId");

                    b.ToTable("TWorkKeyValues");
                });

            modelBuilder.Entity("YG.Models.Admin", b =>
                {
                    b.HasBaseType("WalkingTec.Mvvm.Core.FrameworkUserBase");

                    b.Property<string>("MAC")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("OrganId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("Seal1Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("Seal2Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("Seal3Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("Seal4Id")
                        .HasColumnType("char(36)");

                    b.HasIndex("OrganId");

                    b.HasIndex("Seal1Id");

                    b.HasIndex("Seal2Id");

                    b.HasIndex("Seal3Id");

                    b.HasIndex("Seal4Id");

                    b.ToTable("FrameworkUsers");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.DataPrivilege", b =>
                {
                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkDomain", "Domain")
                        .WithMany()
                        .HasForeignKey("DomainId");

                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkUserBase", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkMenu", b =>
                {
                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkDomain", "Domain")
                        .WithMany()
                        .HasForeignKey("DomainId");

                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkMenu", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkUserBase", b =>
                {
                    b.HasOne("WalkingTec.Mvvm.Core.FileAttachment", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId");
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkUserGroup", b =>
                {
                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkGroup", "Group")
                        .WithMany("UserGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkUserBase", "User")
                        .WithMany("UserGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FrameworkUserRole", b =>
                {
                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkUserBase", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.FunctionPrivilege", b =>
                {
                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkMenu", "MenuItem")
                        .WithMany("Privileges")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WalkingTec.Mvvm.Core.SearchCondition", b =>
                {
                    b.HasOne("WalkingTec.Mvvm.Core.FrameworkUserBase", "User")
                        .WithMany("SearchConditions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YG.Models.Organ", b =>
                {
                    b.HasOne("YG.Models.Organ", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("YG.Models.Work", b =>
                {
                    b.HasOne("YG.Models.Admin", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId");

                    b.HasOne("YG.Models.Admin", "Starter")
                        .WithMany()
                        .HasForeignKey("StarterId");

                    b.HasOne("YG.Models.Template", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId");
                });

            modelBuilder.Entity("YG.Models.WorkHistory", b =>
                {
                    b.HasOne("YG.Models.Admin", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId");

                    b.HasOne("YG.Models.Work", "Work")
                        .WithMany("WorkHistories")
                        .HasForeignKey("WorkId");
                });

            modelBuilder.Entity("YG.Models.WorkKeyValue", b =>
                {
                    b.HasOne("YG.Models.Work", "Work")
                        .WithMany("WorkKeyValues")
                        .HasForeignKey("WorkId");
                });

            modelBuilder.Entity("YG.Models.Admin", b =>
                {
                    b.HasOne("YG.Models.Organ", "Organ")
                        .WithMany()
                        .HasForeignKey("OrganId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WalkingTec.Mvvm.Core.FileAttachment", "Seal1")
                        .WithMany()
                        .HasForeignKey("Seal1Id");

                    b.HasOne("WalkingTec.Mvvm.Core.FileAttachment", "Seal2")
                        .WithMany()
                        .HasForeignKey("Seal2Id");

                    b.HasOne("WalkingTec.Mvvm.Core.FileAttachment", "Seal3")
                        .WithMany()
                        .HasForeignKey("Seal3Id");

                    b.HasOne("WalkingTec.Mvvm.Core.FileAttachment", "Seal4")
                        .WithMany()
                        .HasForeignKey("Seal4Id");
                });
#pragma warning restore 612, 618
        }
    }
}
