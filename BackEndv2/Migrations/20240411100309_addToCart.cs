using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndv2.Migrations
{
    /// <inheritdoc />
    public partial class addToCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Cart",
            columns: table => new
            {
                CartID = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PerfumeDetailID = table.Column<int>(nullable: false),
                CustomerID = table.Column<int>(nullable: false),
                Quantity = table.Column<int>(nullable: false),
                CreatedAt = table.Column<DateTime>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Cart", x => x.CartID);
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
           name: "Cart");
        }
    }
}
