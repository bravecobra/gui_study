using EmojiVoto.EmojiSvc.Application.Services;
using EmojiVoto.EmojiSvc.Domain;

namespace EmojiVoto.EmojiSvc.Persistence.Impl
{
    // ReSharper disable once UnusedType.Global
    public class InMemoryRepository : IEmojiRepository
    {
        private readonly List<Emoji> _emojis = new();

        public InMemoryRepository()
        {
            foreach (var s in EmojiDefinitions.Top100Emojis)
            {
                _emojis.Add(new Emoji
                {
                    Shortcode = s,
                    Unicode = EmojiDefinitions.CodeMap[s]
                });
            }
        }

        public async Task<Emoji?> Get(string shortcode)
        {
            await Task.Delay(1);
            return _emojis.FirstOrDefault(emoji => emoji.Shortcode == shortcode);
        }

        public async Task<IReadOnlyCollection<Emoji>> List()
        {
            await Task.Delay(1);
            return _emojis.AsReadOnly();
        }
    }
}
