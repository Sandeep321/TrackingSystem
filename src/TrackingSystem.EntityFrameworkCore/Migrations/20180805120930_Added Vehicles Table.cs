using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystem.Migrations
{
    public partial class AddedVehiclesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    VehicleNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Model = table.Column<string>(maxLength: 50, nullable: false),
                    EngineNumber = table.Column<string>(maxLength: 50, nullable: false),
                    ChassisNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Company = table.Column<string>(maxLength: 65536, nullable: false),
                    Color = table.Column<string>(maxLength: 50, nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    LastRepairedOn = table.Column<DateTime>(nullable: false),
                    LastConnectedOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 65536, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_AbpUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_AbpUsers_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_AbpUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);

                    table.UniqueConstraint(
                        name: "Unique_Vehicles_ChassisNumber",
                        columns: x => x.ChassisNumber
                        );
                    table.UniqueConstraint(
                        name: "Unique_Vehicles_EngineNumber",
                        columns: x => x.EngineNumber
                        );
                    table.UniqueConstraint(
                        name: "Unique_Vehicles_VehicleNumber",
                        columns: x => x.VehicleNumber
                        );
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
