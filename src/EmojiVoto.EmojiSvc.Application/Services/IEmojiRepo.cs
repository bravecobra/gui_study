using EmojiVoto.EmojiSvc.Domain;

namespace EmojiVoto.EmojiSvc.Application.Services
{
    public interface IEmojiRepo
    {
        Task<IReadOnlyCollection<Emoji>> List();
        Task<Emoji?> Get(string shortcode);
    }
}
