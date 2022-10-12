using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResurces.Infra.Data.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CargoFuncao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCargo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Funcao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoFuncao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoContrato = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    DataDeInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CargoFuncaoId = table.Column<int>(type: "int", nullable: false),
                    ContratoId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 9, 7, 11, 53, 47, 76, DateTimeKind.Utc).AddTicks(9437))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaborador_CargoFuncao_CargoFuncaoId",
                        column: x => x.CargoFuncaoId,
                        principalTable: "CargoFuncao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_Contrato_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_CargoFuncaoId",
                table: "Colaborador",
                column: "CargoFuncaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_ContratoId",
                table: "Colaborador",
                column: "ContratoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "CargoFuncao");

            migrationBuilder.DropTable(
                name: "Contrato");
        }
    }
}
