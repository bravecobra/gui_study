using AutoMapper;
using EmojiVoto.EmojiSvc.Application.Services;
using MediatR;

namespace EmojiVoto.EmojiSvc.Api.Queries
{
    public class ListAllEmojisHandler: IRequestHandler<ListAllEmojisHandler.ListAllEmojis, IEnumerable<ListAllEmojisHandler.EmojiDto>>
    {
        private readonly IEmojiService _emojiService;
        private readonly IMapper _mapper;

        public ListAllEmojisHandler(IEmojiService emojiService, IMapper mapper)
        {
            _emojiService = emojiService;
            _mapper = mapper;
        }

        public class ListAllEmojis : IRequest<IEnumerable<EmojiDto>>
        {

        }
        public class EmojiDto
        {
            public string Unicode { get; set; } = null!;
            public string Shortcode { get; set; } = null!;
        }


        public async Task<IEnumerable<EmojiDto>> Handle(ListAllEmojis request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<EmojiDto>>(await _emojiService.ListEmojis());
        }
    }
}
