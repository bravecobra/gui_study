using EmojiVoto.EmojiSvc.Domain;

namespace EmojiVoto.EmojiSvc.Application.Services.Impl;

internal class AllEmoji : IAllEmoji
{
    private readonly IEmojiRepo _repo;

    public AllEmoji(IEmojiRepo repo)
    {
        _repo = repo;
    }

    public async Task<Emoji?> WithShortcode(string shortcode)
    {
        return await _repo.Get(shortcode);
    }

    public async Task<List<Emoji>> List()
    {
        return (await _repo.List()).ToList();
    }
}