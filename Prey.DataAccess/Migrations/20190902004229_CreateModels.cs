using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prey.DataAccess.Migrations
{
    public partial class CreateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DeviceBase",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    OwnerID = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    CPU = table.Column<string>(nullable: true),
                    GPU = table.Column<string>(nullable: true),
                    Memory = table.Column<string>(nullable: true),
                    Disk = table.Column<string>(nullable: true),
                    MAC = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceBase", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DeviceBase_Persons_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceBase_Persons_OwnerID1",
                        column: x => x.OwnerID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeviceBase_Persons_OwnerID2",
                        column: x => x.OwnerID,
                        principalTable: "Persons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DeviceID = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contacts_DeviceBase_DeviceID",
                        column: x => x.DeviceID,
                        principalTable: "DeviceBase",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DeviceID = table.Column<string>(nullable: true),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Locations_DeviceBase_DeviceID",
                        column: x => x.DeviceID,
                        principalTable: "DeviceBase",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UploadFiles",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DeviceID = table.Column<string>(nullable: true),
                    SourcePath = table.Column<string>(nullable: false),
                    TargetPath = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadFiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UploadFiles_DeviceBase_DeviceID",
                        column: x => x.DeviceID,
                        principalTable: "DeviceBase",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Contact_Index",
                table: "Contacts",
                columns: new[] { "DeviceID", "CreateTime", "ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "DesktopComputer_Index",
                table: "DeviceBase",
                columns: new[] { "OwnerID", "ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "LaptopComputer_Index",
                table: "DeviceBase",
                columns: new[] { "OwnerID", "ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Phone_Index",
                table: "DeviceBase",
                columns: new[] { "OwnerID", "ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Location_Index",
                table: "Locations",
                columns: new[] { "DeviceID", "CreateTime", "ID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Person_Index",
                table: "Persons",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UploadFile_Index",
                table: "UploadFiles",
                columns: new[] { "DeviceID", "CreateTime", "ID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "UploadFiles");

            migrationBuilder.DropTable(
                name: "DeviceBase");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
