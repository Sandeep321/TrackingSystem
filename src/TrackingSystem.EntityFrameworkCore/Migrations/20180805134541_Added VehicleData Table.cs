using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystem.Migrations
{
    public partial class AddedVehicleDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleData",
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
                    ObdNumber = table.Column<string>(maxLength: 50, nullable: false),
                    ObdSimImeiNumber = table.Column<string>(maxLength: 50, nullable: false),
                    VehicleNumber = table.Column<string>(maxLength: 50, nullable: false),
                    VehicleEngineNumber = table.Column<string>(maxLength: 50, nullable: false),
                    EngineStatus = table.Column<string>(nullable: true),
                    Altitude = table.Column<string>(nullable: true),
                    Angle = table.Column<string>(nullable: true),
                    Ignition = table.Column<string>(nullable: true),
                    Odometer = table.Column<string>(nullable: true),
                    Plate = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    ACStatus = table.Column<string>(nullable: true),
                    Accelerator = table.Column<string>(nullable: true),
                    FuelStatus = table.Column<string>(nullable: true),
                    AlarmStatus = table.Column<string>(nullable: true),
                    MainBattrey = table.Column<string>(nullable: true),
                    Temprature = table.Column<string>(nullable: true),
                    Speed = table.Column<string>(nullable: true),
                    Rpm = table.Column<string>(nullable: true),
                    Load = table.Column<string>(nullable: true),
                    FuelLevel = table.Column<string>(nullable: true),
                    RunTime = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleData_AbpUsers_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleData_AbpUsers_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleData_AbpUsers_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);

                    //Refferential integrity ON OBD TABLE
                    table.ForeignKey(
                        name: "FK_VehicleData_ObdMaster_ObdNumber",
                        column: x => x.ObdNumber,
                        principalTable: "ObdMaster",
                        principalColumn: "ObdNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleData_ObdMaster_ObdSimImeiNumber",
                        column: x => x.ObdSimImeiNumber,
                        principalTable: "ObdMaster",
                        principalColumn: "SimImeiNumber",
                        onDelete: ReferentialAction.Restrict);

                    //Refferential integrity ON VEHICLES TABLE
                    table.ForeignKey(
                        name: "FK_VehicleData_Vehicles_VehicleNumber",
                        column: x => x.VehicleNumber,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleData_Vehicles_VehicleEngineNumber",
                        column: x => x.VehicleEngineNumber,
                        principalTable: "Vehicles",
                        principalColumn: "EngineNumber",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleData");
        }
    }
}
