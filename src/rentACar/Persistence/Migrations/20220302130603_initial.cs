using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fuel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transmission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DailyPrice = table.Column<double>(type: "float", nullable: false),
                    TransmissionId = table.Column<int>(type: "int", nullable: false),
                    FuelId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Model_Fuel_FuelId",
                        column: x => x.FuelId,
                        principalTable: "Fuel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Model_Transmission_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ModelYear = table.Column<short>(type: "smallint", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Audi" },
                    { 2, "BMW" },
                    { 3, "Mercedes" },
                    { 4, "Volkswagen" },
                    { 5, "Volvo" },
                    { 6, "Ford" }
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Black" },
                    { 2, "White" },
                    { 3, "Red" },
                    { 4, "Blue" },
                    { 5, "Silver" },
                    { 6, "Yellow" },
                    { 7, "Green" },
                    { 8, "Orange" },
                    { 9, "Pink" },
                    { 10, "Purple" },
                    { 11, "Brown" },
                    { 12, "Grey" },
                    { 13, "Maroon" },
                    { 14, "Navy" },
                    { 15, "Lime" },
                    { 16, "Aqua" },
                    { 17, "Teal" },
                    { 18, "Olive" },
                    { 19, "Maroon" },
                    { 20, "Aquamarine" },
                    { 21, "Coral" },
                    { 22, "Crimson" },
                    { 23, "Cyan" },
                    { 24, "Fuchsia" },
                    { 25, "Gold" },
                    { 26, "Khaki" },
                    { 27, "Lavender" },
                    { 28, "Lime" },
                    { 29, "Magenta" },
                    { 30, "Navy" },
                    { 31, "Olive" },
                    { 32, "Plum" },
                    { 33, "Salmon" },
                    { 34, "Silver" },
                    { 35, "Tan" },
                    { 36, "Teal" }
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 37, "Violet" },
                    { 38, "Yellow" },
                    { 39, "Beige" },
                    { 40, "Brown" },
                    { 41, "Cream" },
                    { 42, "Gold" },
                    { 43, "Grey" },
                    { 44, "Ivory" },
                    { 45, "Mauve" },
                    { 46, "Ochre" },
                    { 47, "Puce" },
                    { 48, "Rust" },
                    { 49, "Tan" },
                    { 50, "Teal" }
                });

            migrationBuilder.InsertData(
                table: "Fuel",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Petrol" },
                    { 2, "Diesel" },
                    { 3, "Gas" },
                    { 4, "Electric" },
                    { 5, "Hybrid" },
                    { 6, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Transmission",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Manual" },
                    { 2, "Automatic" }
                });

            migrationBuilder.InsertData(
                table: "Model",
                columns: new[] { "Id", "BrandId", "DailyPrice", "FuelId", "ImageUrl", "Name", "TransmissionId" },
                values: new object[,]
                {
                    { 1, 1, 1000.0, 1, "", "A1", 1 },
                    { 2, 2, 600.0, 2, "", "A3", 2 },
                    { 3, 3, 1000.0, 3, "", "A4", 1 },
                    { 4, 4, 750.0, 4, "", "A5", 2 },
                    { 5, 5, 500.0, 5, "", "A6", 1 },
                    { 6, 6, 2000.0, 6, "", "A7", 2 }
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "State", "ColorId", "ModelId", "ModelYear", "Plate" },
                values: new object[,]
                {
                    { 1, 0, 1, 1, (short)2001, "60TR60" },
                    { 2, 1, 2, 2, (short)2002, "34TR60" },
                    { 3, 2, 3, 3, (short)2003, "45TR60" },
                    { 4, 0, 4, 4, (short)2004, "35TR60" },
                    { 5, 1, 5, 5, (short)2005, "55TR60" },
                    { 6, 2, 6, 6, (short)2006, "66TR60" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_ColorId",
                table: "Car",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ModelId",
                table: "Car",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_BrandId",
                table: "Model",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_FuelId",
                table: "Model",
                column: "FuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_TransmissionId",
                table: "Model",
                column: "TransmissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Fuel");

            migrationBuilder.DropTable(
                name: "Transmission");
        }
    }
}
