using System.Diagnostics.CodeAnalysis;
using EmojiVoto.EmojiSvc.Application.Services;
using EmojiVoto.EmojiSvc.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmojiVoto.EmojiSvc.Persistence.Impl;

public class DatabaseEmojiRepository : IEmojiRepository
{
    private readonly EmojiDbContext _dbContext;

    public DatabaseEmojiRepository(EmojiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [SuppressMessage("ReSharper.DPA", "DPA0006: Large number of DB commands", MessageId = "count: 56")]
    public async Task<Emoji?> Get(string shortcode)
    {
        return await _dbContext.Emojies.FirstOrDefaultAsync(emoji => emoji.Shortcode == shortcode);
    }

    [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 100")]
    public async Task<IReadOnlyCollection<Emoji>> List()
    {
        return (await _dbContext.Emojies.ToListAsync()).AsReadOnly();
    }
}