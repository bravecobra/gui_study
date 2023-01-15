using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmojiVoto.EmojiSvc.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emojies",
                columns: table => new
                {
                    Shortcode = table.Column<string>(type: "TEXT", nullable: false),
                    Unicode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emojies", x => x.Shortcode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emojies");
        }
    }
}
