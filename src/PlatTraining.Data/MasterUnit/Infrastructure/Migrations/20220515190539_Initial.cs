using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatTraining.Data.MasterUnit.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantConnectionInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InitialCatalog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoadBalanceTimeoutInSec = table.Column<int>(type: "int", nullable: false),
                    MinPoolSize = table.Column<int>(type: "int", nullable: false),
                    MaxPoolSize = table.Column<int>(type: "int", nullable: false),
                    Pooling = table.Column<bool>(type: "bit", nullable: false),
                    Encrypt = table.Column<bool>(type: "bit", nullable: false),
                    TrustServerCertificate = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantConnectionInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantConnectionInfo_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenantConnectionInfo_TenantId",
                table: "TenantConnectionInfo",
                column: "TenantId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantConnectionInfo");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}
