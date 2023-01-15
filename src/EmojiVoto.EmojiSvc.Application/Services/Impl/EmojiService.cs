using EmojiVoto.EmojiSvc.Domain;

namespace EmojiVoto.EmojiSvc.Application.Services.Impl;

internal class EmojiService : IEmojiService
{
    private readonly IEmojiRepo _repository;

    public EmojiService(IEmojiRepo repository)
    {
        _repository = repository;
    }

    public async Task<Emoji?> FindByShortCode(string shortcode)
    {
        return await _repository.Get(shortcode);
    }

    public async Task<IEnumerable<Emoji>> ListEmojis()
    {
        return (await _repository.List()).AsEnumerable();
    }
}