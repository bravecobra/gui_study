using EmojiVoto.EmojiSvc.Domain;

namespace EmojiVoto.EmojiSvc.Application.Services
{
    public interface IEmojiService
    {
        Task<Emoji?> FindByShortCode(string shortcode);
        Task<IEnumerable<Emoji>> ListEmojis();
    }
}
