using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BestiaryDB.Migrations
{
    /// <inheritdoc />
    public partial class BestiaryCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HP = table.Column<int>(type: "int", nullable: false),
                    ArmorClass = table.Column<int>(type: "int", nullable: false),
                    AttacksPerRound = table.Column<int>(type: "int", nullable: false),
                    AttackModifier = table.Column<int>(type: "int", nullable: false),
                    DamageDiceType = table.Column<int>(type: "int", nullable: false),
                    DamageDiceThrowsNumber = table.Column<int>(type: "int", nullable: false),
                    DamageModifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Entities",
                columns: new[] { "Id", "ArmorClass", "AttackModifier", "AttacksPerRound", "DamageDiceThrowsNumber", "DamageDiceType", "DamageModifier", "HP", "Name" },
                values: new object[,]
                {
                    { 1, 10, 3, 1, 6, 8, 6, 33, "Firenewt warlock of Imix" },
                    { 2, 12, 0, 4, 1, 8, 2, 24, "Swarm of ravens" },
                    { 3, 12, 2, 1, 8, 12, 8, 60, "Enormous Tentacle" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entities");
        }
    }
}
