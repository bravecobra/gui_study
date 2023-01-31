using EmojiVoto.EmojiSvc.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EmojiVotoGUI.Tests.Backend.EmojiSvc;

public class EmojiDbFixture : IDisposable
{
    public EmojiDbContext Context { get; set; }

    public EmojiDbFixture()
    {
        var options = new DbContextOptionsBuilder<EmojiDbContext>()
            .UseInMemoryDatabase(databaseName: "EmojiDB")
            .Options;

        Context = new EmojiDbContext(options);
        Context.Emojies.Add(new EmojiVoto.EmojiSvc.Domain.Emoji() { Shortcode = "shortcode1", Unicode = "unicode1"});
        Context.Emojies.Add(new EmojiVoto.EmojiSvc.Domain.Emoji() { Shortcode = "shortcode2", Unicode = "unicode2" });
        Context.SaveChanges();
    }
    public void Dispose()
    {
        Context.Dispose();
    }
}
