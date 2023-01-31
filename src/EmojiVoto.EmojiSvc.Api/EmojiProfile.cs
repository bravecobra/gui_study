using AutoMapper;
using EmojiVoto.EmojiSvc.Api.Queries;
using EmojiVoto.EmojiSvc.Domain;

namespace EmojiVoto.EmojiSvc.Api
{
    internal class EmojiProfile: Profile
    {
        public EmojiProfile()
        {
            CreateMap<Emoji, EmojiDto>();
        }
    }
}
