using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmojiVoto.Voting.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VotingResults",
                columns: table => new
                {
                    Shortcode = table.Column<string>(type: "TEXT", nullable: false),
                    Votes = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingResults", x => x.Shortcode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VotingResults");
        }
    }
}
