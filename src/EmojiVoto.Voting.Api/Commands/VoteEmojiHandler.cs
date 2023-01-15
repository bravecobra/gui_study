using EmojiVoto.Voting.Application;
using MediatR;

namespace EmojiVoto.Voting.Api.Commands;

public class VoteEmojiHandler : IRequestHandler<VoteEmojiHandler.VoteEmojiCommand, Unit>
{
    private readonly IVotingService _votingservice;

    public VoteEmojiHandler(IVotingService votingservice)
    {
        _votingservice = votingservice;
    }

    public class VoteEmojiCommand : IRequest<Unit>
    {
        public string ShortCode { get; init; } = null!;
    }
    
    public async Task<Unit> Handle(VoteEmojiCommand request, CancellationToken cancellationToken)
    {
        await _votingservice.Vote(request.ShortCode, cancellationToken);
        return default;
    }
}