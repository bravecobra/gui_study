using EmojiVoto.EmojiSvc.Domain;

namespace EmojiVoto.EmojiSvc.Application.Services.Impl;

public class EmojiService : IEmojiService
{
    private readonly IEmojiRepository _repository;

    public EmojiService(IEmojiRepository repository)
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