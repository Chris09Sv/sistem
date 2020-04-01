using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistem_Ventas.Data.Migrations
{
    public partial class migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TProvedores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Proveedor = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProvedores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TReportes_provedores",
                columns: table => new
                {
                    ReportesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Deuda = table.Column<string>(nullable: true),
                    FechaDeuda = table.Column<DateTime>(nullable: false),
                    Pago = table.Column<string>(nullable: true),
                    FechaPago = table.Column<DateTime>(nullable: false),
                    Ticket = table.Column<string>(nullable: true),
                    TProvedoresID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TReportes_provedores", x => x.ReportesID);
                    table.ForeignKey(
                        name: "FK_TReportes_provedores_TProvedores_TProvedoresID",
                        column: x => x.TProvedoresID,
                        principalTable: "TProvedores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TReportes_provedores_TProvedoresID",
                table: "TReportes_provedores",
                column: "TProvedoresID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TReportes_provedores");

            migrationBuilder.DropTable(
                name: "TProvedores");
        }
    }
}
