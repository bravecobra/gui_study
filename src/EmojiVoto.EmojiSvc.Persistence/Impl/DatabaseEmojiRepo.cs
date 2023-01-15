using EmojiVoto.EmojiSvc.Application.Services;
using EmojiVoto.EmojiSvc.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmojiVoto.EmojiSvc.Persistence.Impl;

public class DatabaseEmojiRepo : IEmojiRepo
{
    private readonly EmojiDbContext _dbContext;

    public DatabaseEmojiRepo(EmojiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Emoji?> Get(string shortcode)
    {
        return await _dbContext.Emojies.FirstOrDefaultAsync(emoji => emoji.Shortcode == shortcode);
    }

    public async Task<IReadOnlyCollection<Emoji>> List()
    {
        return (await _dbContext.Emojies.ToListAsync()).AsReadOnly();
        
    }
}