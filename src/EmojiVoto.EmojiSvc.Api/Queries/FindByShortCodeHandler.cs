using AutoMapper;
using EmojiVoto.EmojiSvc.Application.Services;
using MediatR;

namespace EmojiVoto.EmojiSvc.Api.Queries
{

    // ReSharper disable once ClassNeverInstantiated.Global
    public class FindByShortCodeHandler: IRequestHandler<FindByShortCodeHandler.FindByShortcodeQuery, EmojiDto>
    {
        private readonly IEmojiService _service;
        private readonly IMapper _mapper;

        public FindByShortCodeHandler(IEmojiService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public class FindByShortcodeQuery : IRequest<EmojiDto>
        {
            public string ShortCode { get; init; } = null!;
        }

        public async Task<EmojiDto> Handle(FindByShortcodeQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<EmojiDto>(await _service.FindByShortCode(request.ShortCode));
        }
    }


}
