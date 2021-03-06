﻿// <auto-generated />
using System;
using Brainvest.Dscribe.MetadataDbAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Brainvest.Dscribe.MetadataDbAccess.Migrations
{
    [DbContext(typeof(MetadataDbContext))]
    [Migration("20181001111845_Initialize_Metadata")]
    partial class Initialize_Metadata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.AppInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppTypeId");

                    b.Property<string>("DataConnectionString")
                        .IsRequired();

                    b.Property<int>("DatabaseProviderId");

                    b.Property<bool>("IsEnabled");

                    b.Property<bool>("IsProduction");

                    b.Property<int?>("MetadataReleaseId");

                    b.Property<bool>("MigrateDatabase");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("UseUnreleasedMetadata");

                    b.HasKey("Id");

                    b.HasIndex("AppTypeId");

                    b.HasIndex("DatabaseProviderId");

                    b.HasIndex("MetadataReleaseId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("AppInstances");
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.AppType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("AppTypes");
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.DatabaseProvider", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DatabaseProviders");

                    b.HasData(
                        new { Id = 1, Name = "MySql" },
                        new { Id = 2, Name = "SqlServer" }
                    );
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.DataType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("ClrType");

                    b.Property<string>("Identifier")
                        .HasMaxLength(200);

                    b.Property<bool>("IsValueType");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("DataTypes");

                    b.HasData(
                        new { Id = 1, ClrType = "System.Int32", Identifier = "int", IsValueType = true, Name = "Integer" },
                        new { Id = 2, ClrType = "System.String", Identifier = "string", IsValueType = false, Name = "String" },
                        new { Id = 3, ClrType = "System.Boolean", Identifier = "bool", IsValueType = true, Name = "Boolean" },
                        new { Id = 4, ClrType = "System.DateTime", Identifier = "Date", IsValueType = true, Name = "Date" },
                        new { Id = 5, ClrType = "System.TimeSpan", Identifier = "Time", IsValueType = true, Name = "Time Of Day" },
                        new { Id = 6, ClrType = "System.DateTime", Identifier = "DateTime", IsValueType = true, Name = "Date and Time" },
                        new { Id = 7, Identifier = "ForeignKey", IsValueType = true, Name = "Foreign Key" },
                        new { Id = 8, Identifier = "NavigationEntity", IsValueType = false, Name = "Navigation Property" },
                        new { Id = 9, Identifier = "Enum", IsValueType = true, Name = "Enum" },
                        new { Id = 10, Identifier = "NavigationList", IsValueType = false, Name = "Navigation List" },
                        new { Id = 11, ClrType = "System.Guid", Identifier = "Guid", IsValueType = true, Name = "Guid" },
                        new { Id = 12, ClrType = "System.Decimal", Identifier = "decimal", IsValueType = true, Name = "Decimal" },
                        new { Id = 13, ClrType = "System.Int64", Identifier = "long", IsValueType = true, Name = "Long Integer" },
                        new { Id = 14, ClrType = "System.Int16", Identifier = "short", IsValueType = true, Name = "Short Integer" },
                        new { Id = 15, ClrType = "System.Byte", Identifier = "byte", IsValueType = true, Name = "Tiny Integer" },
                        new { Id = 16, ClrType = "System.Double", Identifier = "double", IsValueType = true, Name = "Double" }
                    );
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppTypeId");

                    b.Property<int?>("BaseEntityId");

                    b.Property<string>("CodePath");

                    b.Property<string>("DisplayNamePath");

                    b.Property<int>("GeneralUsageCategoryId");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PluralTitle");

                    b.Property<string>("SchemaName");

                    b.Property<string>("SingularTitle");

                    b.Property<string>("TableName");

                    b.HasKey("Id");

                    b.HasIndex("BaseEntityId");

                    b.HasIndex("GeneralUsageCategoryId");

                    b.HasIndex("AppTypeId", "Name")
                        .IsUnique();

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.EntityActionType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EntityActionTypes");

                    b.HasData(
                        new { Id = 1, Name = "GetMetadata" },
                        new { Id = 2, Name = "Select" },
                        new { Id = 3, Name = "Insert" },
                        new { Id = 4, Name = "Delete" },
                        new { Id = 5, Name = "Update" },
                        new { Id = 6, Name = "ManageMetadata" },
                        new { Id = 7, Name = "CustomNamedAction" }
                    );
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.EntityFacetDefaultValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AppInstanceId");

                    b.Property<int?>("AppTypeId");

                    b.Property<string>("DefaultValue");

                    b.Property<int>("FacetDefinitionId");

                    b.Property<int>("GeneralUsageCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("AppInstanceId");

                    b.HasIndex("AppTypeId");

                    b.HasIndex("FacetDefinitionId");

                    b.HasIndex("GeneralUsageCategoryId");

                    b.ToTable("EntityFacetDefaultValues");
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.EntityFacetDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EnumTypeId");

                    b.Property<int>("FacetTypeId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EnumTypeId");

                    b.HasIndex("FacetTypeId");

                    b.ToTable("EntityFacetDefinitions");
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.EntityFacetValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EntityId");

                    b.Property<int>("FacetDefinitionId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("FacetDefinitionId");

                    b.ToTable("EntityFacetValues");
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.EntityGeneralUsageCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EntityGeneralUsageCategories");

                    b.HasData(
                        new { Id = 1, Name = "WorkingData" },
                        new { Id = 2, Name = "BasicInfo" }
                    );
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.EnumType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Identifier")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EnumTypes");
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.EnumValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EnumTypeId");

                    b.Property<string>("Identifier")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EnumTypeId");

                    b.ToTable("EnumValues");
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.ExpressionBody", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("Comments");

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("DefinitionId");

                    b.Property<int>("FormatId");

                    b.Property<DateTime?>("InvalidationTime");

                    b.Property<bool>("IsActive");

                    b.HasKey("Id");

                    b.HasIndex("DefinitionId");

                    b.HasIndex("FormatId");

                    b.ToTable("ExpressionBodies");
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.ExpressionDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ActiveBodyId");

                    b.Property<int>("AppTypeId");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("LongDescription");

                    b.Property<int>("MainInputEntityId");

                    b.Property<string>("ShortDescription")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ActiveBodyId");

                    b.HasIndex("MainInputEntityId");

                    b.HasIndex("AppTypeId", "Identifier")
                        .IsUnique();

                    b.ToTable("ExpressionDefinitions");
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.ExpressionFormat", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Identifier");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("ExpressionFormats");

                    b.HasData(
                        new { Id = 1, Identifier = "SimplePath", Title = "Simple Path" },
                        new { Id = 2, Identifier = "Json", Title = "Json" },
                        new { Id = 3, Identifier = "C#", Title = "C#" }
                    );
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.FacetType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Identifier")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FacetTypes");

                    b.HasData(
                        new { Id = 1, Identifier = "bool", Name = "Boolean" },
                        new { Id = 2, Identifier = "int", Name = "Integer" },
                        new { Id = 3, Identifier = "string", Name = "String" }
                    );
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.MetadataRelease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppTypeId");

                    b.Property<int>("CreatedByUserId");

                    b.Property<byte[]>("MetadataSnapshot")
                        .IsRequired();

                    b.Property<DateTime>("ReleaseTime");

                    b.Property<string>("Version")
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("VersionCode");

                    b.HasKey("Id");

                    b.HasIndex("AppTypeId");

                    b.ToTable("MetadataReleases");
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DataTypeEntityId");

                    b.Property<int?>("DataTypeId");

                    b.Property<int>("EntityId");

                    b.Property<int?>("ExpressionDefinitionId");

                    b.Property<int?>("ForeignKeyPropertyId");

                    b.Property<int>("GeneralUsageCategoryId");

                    b.Property<int?>("InversePropertyId");

                    b.Property<bool>("IsExpression");

                    b.Property<bool>("IsNullable");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("DataTypeEntityId");

                    b.HasIndex("DataTypeId");

                    b.HasIndex("ExpressionDefinitionId");

                    b.HasIndex("ForeignKeyPropertyId");

                    b.HasIndex("GeneralUsageCategoryId");

                    b.HasIndex("InversePropertyId");

                    b.HasIndex("EntityId", "Name")
                        .IsUnique();

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.PropertyFacetDefaultValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AppInstanceId");

                    b.Property<int?>("AppTypeId");

                    b.Property<string>("DefaultValue");

                    b.Property<int>("FacetDefinitionId");

                    b.Property<int>("GeneralUsageCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("AppInstanceId");

                    b.HasIndex("AppTypeId");

                    b.HasIndex("FacetDefinitionId");

                    b.HasIndex("GeneralUsageCategoryId");

                    b.ToTable("PropertyFacetDefaultValues");

                    b.HasData(
                        new { Id = 1, DefaultValue = "false", FacetDefinitionId = 1, GeneralUsageCategoryId = 1 },
                        new { Id = 2, DefaultValue = "true", FacetDefinitionId = 1, GeneralUsageCategoryId = 2 },
                        new { Id = 3, DefaultValue = "false", FacetDefinitionId = 2, GeneralUsageCategoryId = 1 },
                        new { Id = 4, DefaultValue = "true", FacetDefinitionId = 2, GeneralUsageCategoryId = 2 },
                        new { Id = 5, DefaultValue = "false", FacetDefinitionId = 3, GeneralUsageCategoryId = 2 },
                        new { Id = 6, DefaultValue = "true", FacetDefinitionId = 4, GeneralUsageCategoryId = 2 },
                        new { Id = 7, DefaultValue = "true", FacetDefinitionId = 5, GeneralUsageCategoryId = 2 },
                        new { Id = 8, DefaultValue = "true", FacetDefinitionId = 4, GeneralUsageCategoryId = 5 },
                        new { Id = 9, DefaultValue = "true", FacetDefinitionId = 4, GeneralUsageCategoryId = 4 },
                        new { Id = 10, DefaultValue = "false", FacetDefinitionId = 3, GeneralUsageCategoryId = 4 },
                        new { Id = 11, DefaultValue = "false", FacetDefinitionId = 3, GeneralUsageCategoryId = 5 },
                        new { Id = 12, DefaultValue = "true", FacetDefinitionId = 1, GeneralUsageCategoryId = 5 },
                        new { Id = 13, DefaultValue = "true", FacetDefinitionId = 2, GeneralUsageCategoryId = 5 },
                        new { Id = 14, DefaultValue = "true", FacetDefinitionId = 1, GeneralUsageCategoryId = 4 },
                        new { Id = 15, DefaultValue = "true", FacetDefinitionId = 2, GeneralUsageCategoryId = 4 }
                    );
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.PropertyFacetDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EnumTypeId");

                    b.Property<int>("FacetTypeId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EnumTypeId");

                    b.HasIndex("FacetTypeId");

                    b.ToTable("PropertyFacetDefinitions");

                    b.HasData(
                        new { Id = 1, FacetTypeId = 1, Name = "HideInInsert" },
                        new { Id = 2, FacetTypeId = 1, Name = "HideInEdit" },
                        new { Id = 3, FacetTypeId = 1, Name = "IsRequired" },
                        new { Id = 4, FacetTypeId = 1, Name = "HideInList" },
                        new { Id = 5, FacetTypeId = 1, Name = "ReadOnlyInEdit" }
                    );
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.PropertyFacetValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FacetDefinitionId");

                    b.Property<int>("PropertyId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("FacetDefinitionId");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyFacetValues");
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.PropertyGeneralUsageCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PropertyGeneralUsageCategories");

                    b.HasData(
                        new { Id = 1, Name = "NormalData" },
                        new { Id = 2, Name = "PrimaryKey" },
                        new { Id = 3, Name = "ForeignKey" },
                        new { Id = 4, Name = "NavigationProperty" },
                        new { Id = 5, Name = "NavigationList" }
                    );
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.SavedFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<int>("InputEntityId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("InputEntityId");

                    b.ToTable("SavedFilters");
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.Security.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionName")
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("ActionTypeId");

                    b.Property<int?>("AppInstanceId");

                    b.Property<int?>("EntityId");

                    b.Property<int>("PermissionType");

                    b.Property<Guid?>("RoleId");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ActionTypeId");

                    b.HasIndex("AppInstanceId");

                    b.HasIndex("EntityId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("Permissions");

                    b.HasData(
                        new { Id = 1, PermissionType = 1, RoleId = new Guid("7555dd25-ee7f-4a21-9156-3867dcbced77") }
                    );
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.Security.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new { Id = new Guid("2e17424d-9a7c-44ee-962e-0a0e12176cff"), Name = "Anonymous" },
                        new { Id = new Guid("7555dd25-ee7f-4a21-9156-3867dcbced77"), Name = "Admin" }
                    );
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.Security.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.AppInstance", b =>
                {
                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.AppType", "AppType")
                        .WithMany()
                        .HasForeignKey("AppTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.DatabaseProvider", "DatabaseProvider")
                        .WithMany()
                        .HasForeignKey("DatabaseProviderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.MetadataRelease", "MetadataRelease")
                        .WithMany()
                        .HasForeignKey("MetadataReleaseId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.Entity", b =>
                {
                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.AppType", "AppType")
                        .WithMany()
                        .HasForeignKey("AppTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.Entity", "BaseEntity")
                        .WithMany()
                        .HasForeignKey("BaseEntityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.EntityGeneralUsageCategory", "GeneralUsageCategory")
                        .WithMany()
                        .HasForeignKey("GeneralUsageCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.EntityFacetDefaultValue", b =>
                {
                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.AppInstance", "AppInstance")
                        .WithMany()
                        .HasForeignKey("AppInstanceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.AppType", "AppType")
                        .WithMany()
                        .HasForeignKey("AppTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.EntityFacetDefinition", "FacetDefinition")
                        .WithMany()
                        .HasForeignKey("FacetDefinitionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.EntityGeneralUsageCategory", "GeneralUsageCategory")
                        .WithMany()
                        .HasForeignKey("GeneralUsageCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.EntityFacetDefinition", b =>
                {
                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.EnumType", "EnumType")
                        .WithMany()
                        .HasForeignKey("EnumTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.FacetType", "FacetType")
                        .WithMany()
                        .HasForeignKey("FacetTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.EntityFacetValue", b =>
                {
                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.Entity", "Entity")
                        .WithMany("FacetValues")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.EntityFacetDefinition", "FacetDefinition")
                        .WithMany()
                        .HasForeignKey("FacetDefinitionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.EnumValue", b =>
                {
                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.EnumType", "EnumType")
                        .WithMany("Values")
                        .HasForeignKey("EnumTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.ExpressionBody", b =>
                {
                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.ExpressionDefinition", "Definition")
                        .WithMany("Bodies")
                        .HasForeignKey("DefinitionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.ExpressionFormat", "Format")
                        .WithMany()
                        .HasForeignKey("FormatId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.ExpressionDefinition", b =>
                {
                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.ExpressionBody", "ActiveBody")
                        .WithMany()
                        .HasForeignKey("ActiveBodyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.AppType", "AppType")
                        .WithMany()
                        .HasForeignKey("AppTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.Entity", "MainInputEntity")
                        .WithMany()
                        .HasForeignKey("MainInputEntityId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.MetadataRelease", b =>
                {
                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.AppType", "AppType")
                        .WithMany()
                        .HasForeignKey("AppTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.Property", b =>
                {
                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.Entity", "DataTypeEntity")
                        .WithMany()
                        .HasForeignKey("DataTypeEntityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.DataType", "DataType")
                        .WithMany()
                        .HasForeignKey("DataTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.Entity", "Entity")
                        .WithMany("Properties")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.ExpressionDefinition", "ExpressionDefinition")
                        .WithMany()
                        .HasForeignKey("ExpressionDefinitionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.Property", "ForeignKeyProperty")
                        .WithMany("Unused1")
                        .HasForeignKey("ForeignKeyPropertyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.PropertyGeneralUsageCategory", "GeneralUsageCategory")
                        .WithMany()
                        .HasForeignKey("GeneralUsageCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.Property", "InverseProperty")
                        .WithMany("Unused2")
                        .HasForeignKey("InversePropertyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.PropertyFacetDefaultValue", b =>
                {
                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.AppInstance", "AppInstance")
                        .WithMany()
                        .HasForeignKey("AppInstanceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.AppType", "AppType")
                        .WithMany()
                        .HasForeignKey("AppTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.PropertyFacetDefinition", "FacetDefinition")
                        .WithMany()
                        .HasForeignKey("FacetDefinitionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.PropertyGeneralUsageCategory", "GeneralUsageCategory")
                        .WithMany()
                        .HasForeignKey("GeneralUsageCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.PropertyFacetDefinition", b =>
                {
                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.EnumType", "EnumType")
                        .WithMany()
                        .HasForeignKey("EnumTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.FacetType", "FacetType")
                        .WithMany()
                        .HasForeignKey("FacetTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.PropertyFacetValue", b =>
                {
                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.PropertyFacetDefinition", "FacetDefinition")
                        .WithMany()
                        .HasForeignKey("FacetDefinitionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.Property", "Property")
                        .WithMany("PropertyFacetValues")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.SavedFilter", b =>
                {
                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.Entity", "InputEntity")
                        .WithMany()
                        .HasForeignKey("InputEntityId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Brainvest.Dscribe.MetadataDbAccess.Entities.Security.Permission", b =>
                {
                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.EntityActionType", "ActionType")
                        .WithMany()
                        .HasForeignKey("ActionTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.AppInstance", "AppInstance")
                        .WithMany()
                        .HasForeignKey("AppInstanceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.Security.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Brainvest.Dscribe.MetadataDbAccess.Entities.Security.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
