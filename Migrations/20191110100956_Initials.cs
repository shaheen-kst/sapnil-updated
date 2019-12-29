using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sapnil.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InvoiceNo = table.Column<uint>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CellNo = table.Column<string>(maxLength: 11, nullable: false),
                    Address = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(nullable: false),
                    TotalAmmount = table.Column<decimal>(nullable: false),
                    DiscountAmount = table.Column<decimal>(nullable: true),
                    NetAmount = table.Column<decimal>(nullable: false),
                    PaidAmount = table.Column<decimal>(nullable: true),
                    DueAmount = table.Column<decimal>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(nullable: false),
                    FrameName = table.Column<string>(nullable: true),
                    FrameQty = table.Column<uint>(nullable: true),
                    FramePrice = table.Column<decimal>(nullable: true),
                    PowerLense = table.Column<int>(nullable: true),
                    PowerLenseQty = table.Column<uint>(nullable: true),
                    PowerLensePrice = table.Column<decimal>(nullable: true),
                    ContactLense = table.Column<int>(nullable: true),
                    ContactLenseQty = table.Column<uint>(nullable: true),
                    ContactLensePrice = table.Column<decimal>(nullable: true),
                    LeftEyeSph = table.Column<string>(nullable: true),
                    LeftEyeCyl = table.Column<string>(nullable: true),
                    LeftEyeAxis = table.Column<string>(nullable: true),
                    LeftEyeAdd = table.Column<string>(nullable: true),
                    RightEyeSph = table.Column<string>(nullable: true),
                    RightEyeCyl = table.Column<string>(nullable: true),
                    RightEyeAxis = table.Column<string>(nullable: true),
                    RightEyeAdd = table.Column<string>(nullable: true),
                    FocalOption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustomerId",
                table: "Products",
                column: "CustomerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
