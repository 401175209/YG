using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YG.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionLogs",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ModuleName = table.Column<string>(maxLength: 50, nullable: true),
                    ActionName = table.Column<string>(maxLength: 50, nullable: true),
                    ITCode = table.Column<string>(maxLength: 50, nullable: true),
                    ActionUrl = table.Column<string>(maxLength: 250, nullable: true),
                    ActionTime = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<double>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    IP = table.Column<string>(maxLength: 50, nullable: true),
                    LogType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLogs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FileAttachments",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    FileName = table.Column<string>(nullable: false),
                    FileExt = table.Column<string>(maxLength: 10, nullable: false),
                    Path = table.Column<string>(nullable: true),
                    Length = table.Column<long>(nullable: false),
                    UploadTime = table.Column<DateTime>(nullable: false),
                    IsTemprory = table.Column<bool>(nullable: false),
                    SaveFileMode = table.Column<int>(nullable: true),
                    GroupName = table.Column<string>(maxLength: 50, nullable: true),
                    FileData = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAttachments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FrameworkDomains",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    DomainName = table.Column<string>(maxLength: 50, nullable: false),
                    DomainAddress = table.Column<string>(maxLength: 50, nullable: false),
                    DomainPort = table.Column<int>(nullable: true),
                    EntryUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkDomains", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FrameworkGroups",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    GroupCode = table.Column<string>(maxLength: 100, nullable: false),
                    GroupName = table.Column<string>(maxLength: 50, nullable: false),
                    GroupRemark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkGroups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FrameworkRoles",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    RoleCode = table.Column<string>(maxLength: 100, nullable: false),
                    RoleName = table.Column<string>(maxLength: 50, nullable: false),
                    RoleRemark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkRoles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Organs",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    OrganCode = table.Column<string>(nullable: false),
                    OrganName = table.Column<string>(maxLength: 50, nullable: false),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Organs_Organs_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Organs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false),
                    RefreshToken = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Context = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FrameworkMenus",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    PageName = table.Column<string>(maxLength: 50, nullable: false),
                    ActionName = table.Column<string>(nullable: true),
                    ModuleName = table.Column<string>(nullable: true),
                    FolderOnly = table.Column<bool>(nullable: false),
                    IsInherit = table.Column<bool>(nullable: false),
                    ClassName = table.Column<string>(nullable: true),
                    MethodName = table.Column<string>(nullable: true),
                    DomainId = table.Column<Guid>(nullable: true),
                    ShowOnMenu = table.Column<bool>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    IsInside = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    ICon = table.Column<string>(maxLength: 50, nullable: true),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkMenus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FrameworkMenus_FrameworkDomains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "FrameworkDomains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FrameworkMenus_FrameworkMenus_ParentId",
                        column: x => x.ParentId,
                        principalTable: "FrameworkMenus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FrameworkUsers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    ITCode = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 32, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Sex = table.Column<int>(nullable: true),
                    CellPhone = table.Column<string>(nullable: true),
                    HomePhone = table.Column<string>(maxLength: 30, nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    PhotoId = table.Column<Guid>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    OrganId = table.Column<Guid>(nullable: true),
                    MAC = table.Column<string>(nullable: true),
                    Seal1Id = table.Column<Guid>(nullable: true),
                    Seal2Id = table.Column<Guid>(nullable: true),
                    Seal3Id = table.Column<Guid>(nullable: true),
                    Seal4Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FrameworkUsers_FileAttachments_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "FileAttachments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FrameworkUsers_Organs_OrganId",
                        column: x => x.OrganId,
                        principalTable: "Organs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FrameworkUsers_FileAttachments_Seal1Id",
                        column: x => x.Seal1Id,
                        principalTable: "FileAttachments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FrameworkUsers_FileAttachments_Seal2Id",
                        column: x => x.Seal2Id,
                        principalTable: "FileAttachments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FrameworkUsers_FileAttachments_Seal3Id",
                        column: x => x.Seal3Id,
                        principalTable: "FileAttachments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FrameworkUsers_FileAttachments_Seal4Id",
                        column: x => x.Seal4Id,
                        principalTable: "FileAttachments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FunctionPrivileges",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    RoleId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    MenuItemId = table.Column<Guid>(nullable: false),
                    Allowed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionPrivileges", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FunctionPrivileges_FrameworkMenus_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "FrameworkMenus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataPrivileges",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    GroupId = table.Column<Guid>(nullable: true),
                    TableName = table.Column<string>(maxLength: 50, nullable: false),
                    RelateId = table.Column<string>(nullable: true),
                    DomainId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPrivileges", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DataPrivileges_FrameworkDomains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "FrameworkDomains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataPrivileges_FrameworkGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "FrameworkGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataPrivileges_FrameworkUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "FrameworkUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FrameworkUserGroup",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkUserGroup", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FrameworkUserGroup_FrameworkGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "FrameworkGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FrameworkUserGroup_FrameworkUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "FrameworkUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FrameworkUserRole",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameworkUserRole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FrameworkUserRole_FrameworkRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "FrameworkRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FrameworkUserRole_FrameworkUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "FrameworkUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SearchConditions",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Condition = table.Column<string>(nullable: true),
                    VMName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchConditions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SearchConditions_FrameworkUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "FrameworkUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    WithDraw = table.Column<bool>(nullable: false),
                    StarterId = table.Column<Guid>(nullable: true),
                    ReceiverId = table.Column<Guid>(nullable: true),
                    WorkStatus = table.Column<int>(nullable: false),
                    TemplateId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Works_FrameworkUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "FrameworkUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Works_FrameworkUsers_StarterId",
                        column: x => x.StarterId,
                        principalTable: "FrameworkUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Works_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TWorkKeyValues",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    WorkId = table.Column<Guid>(nullable: true),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TWorkKeyValues", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TWorkKeyValues_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkHistories",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    WorkId = table.Column<Guid>(nullable: true),
                    ReceiverId = table.Column<Guid>(nullable: true),
                    Advice = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkHistories_FrameworkUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "FrameworkUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkHistories_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataPrivileges_DomainId",
                table: "DataPrivileges",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPrivileges_GroupId",
                table: "DataPrivileges",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPrivileges_UserId",
                table: "DataPrivileges",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkMenus_DomainId",
                table: "FrameworkMenus",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkMenus_ParentId",
                table: "FrameworkMenus",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUserGroup_GroupId",
                table: "FrameworkUserGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUserGroup_UserId",
                table: "FrameworkUserGroup",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUserRole_RoleId",
                table: "FrameworkUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUserRole_UserId",
                table: "FrameworkUserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUsers_ITCode",
                table: "FrameworkUsers",
                column: "ITCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUsers_PhotoId",
                table: "FrameworkUsers",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUsers_OrganId",
                table: "FrameworkUsers",
                column: "OrganId");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUsers_Seal1Id",
                table: "FrameworkUsers",
                column: "Seal1Id");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUsers_Seal2Id",
                table: "FrameworkUsers",
                column: "Seal2Id");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUsers_Seal3Id",
                table: "FrameworkUsers",
                column: "Seal3Id");

            migrationBuilder.CreateIndex(
                name: "IX_FrameworkUsers_Seal4Id",
                table: "FrameworkUsers",
                column: "Seal4Id");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionPrivileges_MenuItemId",
                table: "FunctionPrivileges",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Organs_ParentId",
                table: "Organs",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchConditions_UserId",
                table: "SearchConditions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TWorkKeyValues_WorkId",
                table: "TWorkKeyValues",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistories_ReceiverId",
                table: "WorkHistories",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistories_WorkId",
                table: "WorkHistories",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_ReceiverId",
                table: "Works",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_StarterId",
                table: "Works",
                column: "StarterId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_TemplateId",
                table: "Works",
                column: "TemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionLogs");

            migrationBuilder.DropTable(
                name: "DataPrivileges");

            migrationBuilder.DropTable(
                name: "FrameworkUserGroup");

            migrationBuilder.DropTable(
                name: "FrameworkUserRole");

            migrationBuilder.DropTable(
                name: "FunctionPrivileges");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "SearchConditions");

            migrationBuilder.DropTable(
                name: "TWorkKeyValues");

            migrationBuilder.DropTable(
                name: "WorkHistories");

            migrationBuilder.DropTable(
                name: "FrameworkGroups");

            migrationBuilder.DropTable(
                name: "FrameworkRoles");

            migrationBuilder.DropTable(
                name: "FrameworkMenus");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "FrameworkDomains");

            migrationBuilder.DropTable(
                name: "FrameworkUsers");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "FileAttachments");

            migrationBuilder.DropTable(
                name: "Organs");
        }
    }
}
