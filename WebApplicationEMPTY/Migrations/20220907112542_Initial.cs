using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApplicationEMPTY.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carscategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    categoryName = table.Column<string>(type: "text", nullable: true),
                    categoryDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carscategory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    surname = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    orderTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    phonenumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    make = table.Column<string>(type: "text", nullable: true),
                    modelName = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    bodyStyle = table.Column<string>(type: "text", nullable: true),
                    img = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    isFavorite = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.id);
                    table.ForeignKey(
                        name: "FK_cars_carscategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "carscategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cartitems",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    carid = table.Column<int>(type: "integer", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    shopCartId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartitems", x => x.id);
                    table.ForeignKey(
                        name: "FK_cartitems_cars_carid",
                        column: x => x.carid,
                        principalTable: "cars",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orderdetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orderId = table.Column<int>(type: "integer", nullable: false),
                    carId = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderdetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_orderdetails_cars_carId",
                        column: x => x.carId,
                        principalTable: "cars",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderdetails_orders_orderId",
                        column: x => x.orderId,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_CategoryId",
                table: "cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_cartitems_carid",
                table: "cartitems",
                column: "carid");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_carId",
                table: "orderdetails",
                column: "carId");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_orderId",
                table: "orderdetails",
                column: "orderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartitems");

            migrationBuilder.DropTable(
                name: "orderdetails");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "carscategory");
        }
    }
}
