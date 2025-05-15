using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace challenger.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Capacidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Created = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataCreated = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Updated = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataUpadated = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Placa = table.Column<string>(type: "NVARCHAR2(8)", maxLength: 8, nullable: false),
                    Modelo = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PatioId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Created = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    DataCreated = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Updated = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataUpadated = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moto_Patio_PatioId",
                        column: x => x.PatioId,
                        principalTable: "Patio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moto_PatioId",
                table: "Moto",
                column: "PatioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moto");

            migrationBuilder.DropTable(
                name: "Patio");
        }
    }
}
