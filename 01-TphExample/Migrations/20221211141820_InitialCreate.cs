using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _01TphExample.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "EmployeeIdSequence");

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "NEXT VALUE FOR EmployeeIdSequence"),
                    Expertise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomersBusinessManagers",
                columns: table => new
                {
                    ContactsId = table.Column<int>(type: "int", nullable: false),
                    PortfolioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersBusinessManagers", x => new { x.ContactsId, x.PortfolioId });
                    table.ForeignKey(
                        name: "FK_CustomersBusinessManagers_Persons_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersBusinessManagers_Persons_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomersBusinessManagers_PortfolioId",
                table: "CustomersBusinessManagers",
                column: "PortfolioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersBusinessManagers");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropSequence(
                name: "EmployeeIdSequence");
        }
    }
}
