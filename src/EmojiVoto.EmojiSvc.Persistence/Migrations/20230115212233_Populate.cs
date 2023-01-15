using EmojiVoto.EmojiSvc.Persistence.Impl;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmojiVoto.EmojiSvc.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Populate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Emojies;");
            foreach (var emoji in EmojiDefinitions.Top100Emojis)
            {
                migrationBuilder.InsertData("Emojies", columns: new[] { "Shortcode", "Unicode" }, values: new object[]
                {
                    emoji,
                    EmojiDefinitions.CodeMap[emoji]
                });
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Emojies;");
        }
    }
}
