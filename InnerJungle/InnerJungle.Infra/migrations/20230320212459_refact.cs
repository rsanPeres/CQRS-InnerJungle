using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnerJungle.Infra.migrations
{
    public partial class refact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Research");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Research",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "CalibrationCurveId",
                table: "Research",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EletrodeId",
                table: "Research",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InstitutionId",
                table: "Research",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Research",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Electrochemical_Experiment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    ResearchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electrochemical_Experiment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Electrochemical_Experiment_Research_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "Research",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Institution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Strain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrowthMedium = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrowthTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageTemperature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dilution = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calibration_Curve",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calibration_Curve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calibration_Curve_Electrochemical_Experiment_Id",
                        column: x => x.Id,
                        principalTable: "Electrochemical_Experiment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Microorganism",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Species = table.Column<string>(type: "varchar(50)", nullable: false),
                    Phatogenicity = table.Column<int>(type: "int", nullable: false),
                    Virulence = table.Column<int>(type: "int", nullable: false),
                    StrainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResearchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Microorganism", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Microorganism_Research_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "Research",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Microorganism_Strain_StrainId",
                        column: x => x.StrainId,
                        principalTable: "Strain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MicroorganismId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResearchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiment_Microorganism_MicroorganismId",
                        column: x => x.MicroorganismId,
                        principalTable: "Microorganism",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiment_Research_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "Research",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Eletrode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ExperimentBaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eletrode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eletrode_Experiment_ExperimentBaseId",
                        column: x => x.ExperimentBaseId,
                        principalTable: "Experiment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nanomaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Polimer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nanomaterials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperimentBaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResearchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nanomaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nanomaterial_Experiment_ExperimentBaseId",
                        column: x => x.ExperimentBaseId,
                        principalTable: "Experiment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nanomaterial_Research_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "Research",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Research_CalibrationCurveId",
                table: "Research",
                column: "CalibrationCurveId");

            migrationBuilder.CreateIndex(
                name: "IX_Research_EletrodeId",
                table: "Research",
                column: "EletrodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Research_InstitutionId",
                table: "Research",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Research_UserId",
                table: "Research",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Electrochemical_Experiment_ResearchId",
                table: "Electrochemical_Experiment",
                column: "ResearchId");

            migrationBuilder.CreateIndex(
                name: "IX_Eletrode_ExperimentBaseId",
                table: "Eletrode",
                column: "ExperimentBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiment_MicroorganismId",
                table: "Experiment",
                column: "MicroorganismId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiment_ResearchId",
                table: "Experiment",
                column: "ResearchId");

            migrationBuilder.CreateIndex(
                name: "IX_Microorganism_ResearchId",
                table: "Microorganism",
                column: "ResearchId");

            migrationBuilder.CreateIndex(
                name: "IX_Microorganism_StrainId",
                table: "Microorganism",
                column: "StrainId");

            migrationBuilder.CreateIndex(
                name: "IX_Nanomaterial_ExperimentBaseId",
                table: "Nanomaterial",
                column: "ExperimentBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Nanomaterial_ResearchId",
                table: "Nanomaterial",
                column: "ResearchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Research_Calibration_Curve_CalibrationCurveId",
                table: "Research",
                column: "CalibrationCurveId",
                principalTable: "Calibration_Curve",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Research_Eletrode_EletrodeId",
                table: "Research",
                column: "EletrodeId",
                principalTable: "Eletrode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Research_Institution_InstitutionId",
                table: "Research",
                column: "InstitutionId",
                principalTable: "Institution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Research_User_UserId",
                table: "Research",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Research_Calibration_Curve_CalibrationCurveId",
                table: "Research");

            migrationBuilder.DropForeignKey(
                name: "FK_Research_Eletrode_EletrodeId",
                table: "Research");

            migrationBuilder.DropForeignKey(
                name: "FK_Research_Institution_InstitutionId",
                table: "Research");

            migrationBuilder.DropForeignKey(
                name: "FK_Research_User_UserId",
                table: "Research");

            migrationBuilder.DropTable(
                name: "Calibration_Curve");

            migrationBuilder.DropTable(
                name: "Eletrode");

            migrationBuilder.DropTable(
                name: "Institution");

            migrationBuilder.DropTable(
                name: "Nanomaterial");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Electrochemical_Experiment");

            migrationBuilder.DropTable(
                name: "Experiment");

            migrationBuilder.DropTable(
                name: "Microorganism");

            migrationBuilder.DropTable(
                name: "Strain");

            migrationBuilder.DropIndex(
                name: "IX_Research_CalibrationCurveId",
                table: "Research");

            migrationBuilder.DropIndex(
                name: "IX_Research_EletrodeId",
                table: "Research");

            migrationBuilder.DropIndex(
                name: "IX_Research_InstitutionId",
                table: "Research");

            migrationBuilder.DropIndex(
                name: "IX_Research_UserId",
                table: "Research");

            migrationBuilder.DropColumn(
                name: "CalibrationCurveId",
                table: "Research");

            migrationBuilder.DropColumn(
                name: "EletrodeId",
                table: "Research");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "Research");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Research");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Research",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Research",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
