using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bodies",
                columns: table => new
                {
                    BodyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodies", x => x.BodyId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModelCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CarComplectationsCodes = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    DestinationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.DestinationId);
                });

            migrationBuilder.CreateTable(
                name: "DriversPositions",
                columns: table => new
                {
                    DriversPositionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversPositions", x => x.DriversPositionId);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    EngineId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.EngineId);
                });

            migrationBuilder.CreateTable(
                name: "GearShiftTypes",
                columns: table => new
                {
                    GearShiftTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearShiftTypes", x => x.GearShiftTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                });

            migrationBuilder.CreateTable(
                name: "NoOfDoors",
                columns: table => new
                {
                    NoOfDoorsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoOfDoors", x => x.NoOfDoorsId);
                });

            migrationBuilder.CreateTable(
                name: "Transmissions",
                columns: table => new
                {
                    TransmissionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.TransmissionId);
                });

            migrationBuilder.CreateTable(
                name: "CarComplectations",
                columns: table => new
                {
                    CarComplectationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarCompectationCode = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ComplectationNumber = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Engine1EngineId = table.Column<long>(type: "bigint", nullable: false),
                    BodyId = table.Column<long>(type: "bigint", nullable: false),
                    GradeId = table.Column<long>(type: "bigint", nullable: false),
                    TransmissionId = table.Column<long>(type: "bigint", nullable: false),
                    GearShiftTypeId = table.Column<long>(type: "bigint", nullable: false),
                    DriversPositionId = table.Column<long>(type: "bigint", nullable: false),
                    NoOfDoorsId = table.Column<long>(type: "bigint", nullable: false),
                    Destination1DestinationId = table.Column<long>(type: "bigint", nullable: false),
                    Destination2DestinationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarComplectations", x => x.CarComplectationId);
                    table.ForeignKey(
                        name: "FK_CarComplectations_Bodies_BodyId",
                        column: x => x.BodyId,
                        principalTable: "Bodies",
                        principalColumn: "BodyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarComplectations_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarComplectations_Destinations_Destination1DestinationId",
                        column: x => x.Destination1DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarComplectations_Destinations_Destination2DestinationId",
                        column: x => x.Destination2DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "DestinationId");
                    table.ForeignKey(
                        name: "FK_CarComplectations_DriversPositions_DriversPositionId",
                        column: x => x.DriversPositionId,
                        principalTable: "DriversPositions",
                        principalColumn: "DriversPositionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarComplectations_Engines_Engine1EngineId",
                        column: x => x.Engine1EngineId,
                        principalTable: "Engines",
                        principalColumn: "EngineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarComplectations_GearShiftTypes_GearShiftTypeId",
                        column: x => x.GearShiftTypeId,
                        principalTable: "GearShiftTypes",
                        principalColumn: "GearShiftTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarComplectations_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarComplectations_NoOfDoors_NoOfDoorsId",
                        column: x => x.NoOfDoorsId,
                        principalTable: "NoOfDoors",
                        principalColumn: "NoOfDoorsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarComplectations_Transmissions_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmissions",
                        principalColumn: "TransmissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarDetailGroups",
                columns: table => new
                {
                    CarDetailGroupId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Group = table.Column<int>(type: "int", nullable: false),
                    CarComplectationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDetailGroups", x => x.CarDetailGroupId);
                    table.ForeignKey(
                        name: "FK_CarDetailGroups_CarComplectations_CarComplectationId",
                        column: x => x.CarComplectationId,
                        principalTable: "CarComplectations",
                        principalColumn: "CarComplectationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarDetailSubGroups",
                columns: table => new
                {
                    CarDetailSubGroupId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubGroup = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    CarDetailGroupId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDetailSubGroups", x => x.CarDetailSubGroupId);
                    table.ForeignKey(
                        name: "FK_CarDetailSubGroups_CarDetailGroups_CarDetailGroupId",
                        column: x => x.CarDetailGroupId,
                        principalTable: "CarDetailGroups",
                        principalColumn: "CarDetailGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarDetails",
                columns: table => new
                {
                    CarDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarDetailSubGroupId = table.Column<long>(type: "bigint", nullable: false),
                    CarDetailCode = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreeCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    TreeName = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    ReplacmentCode = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageGUID = table.Column<string>(type: "nvarchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDetails", x => x.CarDetailId);
                    table.ForeignKey(
                        name: "FK_CarDetails_CarDetailSubGroups_CarDetailSubGroupId",
                        column: x => x.CarDetailSubGroupId,
                        principalTable: "CarDetailSubGroups",
                        principalColumn: "CarDetailSubGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarComplectations_BodyId",
                table: "CarComplectations",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_CarComplectations_CarCompectationCode",
                table: "CarComplectations",
                column: "CarCompectationCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarComplectations_CarId",
                table: "CarComplectations",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarComplectations_Destination1DestinationId",
                table: "CarComplectations",
                column: "Destination1DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarComplectations_Destination2DestinationId",
                table: "CarComplectations",
                column: "Destination2DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarComplectations_DriversPositionId",
                table: "CarComplectations",
                column: "DriversPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_CarComplectations_Engine1EngineId",
                table: "CarComplectations",
                column: "Engine1EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_CarComplectations_GearShiftTypeId",
                table: "CarComplectations",
                column: "GearShiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarComplectations_GradeId",
                table: "CarComplectations",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarComplectations_NoOfDoorsId",
                table: "CarComplectations",
                column: "NoOfDoorsId");

            migrationBuilder.CreateIndex(
                name: "IX_CarComplectations_TransmissionId",
                table: "CarComplectations",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDetailGroups_CarComplectationId",
                table: "CarDetailGroups",
                column: "CarComplectationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDetails_CarDetailSubGroupId",
                table: "CarDetails",
                column: "CarDetailSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDetailSubGroups_CarDetailGroupId",
                table: "CarDetailSubGroups",
                column: "CarDetailGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelName_ModelCode",
                table: "Cars",
                columns: new[] { "ModelName", "ModelCode" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarDetails");

            migrationBuilder.DropTable(
                name: "CarDetailSubGroups");

            migrationBuilder.DropTable(
                name: "CarDetailGroups");

            migrationBuilder.DropTable(
                name: "CarComplectations");

            migrationBuilder.DropTable(
                name: "Bodies");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "DriversPositions");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "GearShiftTypes");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "NoOfDoors");

            migrationBuilder.DropTable(
                name: "Transmissions");
        }
    }
}
