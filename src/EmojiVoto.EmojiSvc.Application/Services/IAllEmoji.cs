using EmojiVoto.EmojiSvc.Domain;

namespace EmojiVoto.EmojiSvc.Application.Services;

public interface IAllEmoji
{
    Task<Emoji?> WithShortcode(string shortcode);
    Task<List<Emoji>> List();
}