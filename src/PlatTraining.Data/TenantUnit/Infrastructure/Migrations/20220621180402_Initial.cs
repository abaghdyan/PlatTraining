using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatTraining.Data.TenantUnit.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "next");

            migrationBuilder.EnsureSchema(
                name: "some");

            migrationBuilder.CreateTable(
                name: "NextTenantData",
                schema: "next",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Next = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextTenantData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SomeTenantData",
                schema: "some",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SomeTenantData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NextTenantData",
                schema: "next");

            migrationBuilder.DropTable(
                name: "SomeTenantData",
                schema: "some");
        }
    }
}
