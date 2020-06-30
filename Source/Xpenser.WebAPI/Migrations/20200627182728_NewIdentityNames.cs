using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Xpenser.WebAPI.Migrations
{
    public partial class NewIdentityNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AcccountName = table.Column<string>(nullable: true),
                    AcNumber = table.Column<string>(nullable: true),
                    OpenBal = table.Column<double>(nullable: false),
                    AcType = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    AppUserId = table.Column<long>(nullable: false),
                    IconPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
