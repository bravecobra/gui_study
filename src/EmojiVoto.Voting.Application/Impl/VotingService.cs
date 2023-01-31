using EmojiVoto.Voting.Domain;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;
using System.Reflection;
using EmojiVoto.Voting.Application.Events;
using MediatR;

namespace EmojiVoto.Voting.Application.Impl;

internal class VotingService : IVotingService
{
    private readonly IVotingRepository _repository;
    private readonly ILogger<VotingService> _logger;
    private readonly IMediator _mediator;

    public VotingService(IVotingRepository repository, ILogger<VotingService> logger, IMediator mediator)
    {
        _repository = repository;
        _logger = logger;
        _mediator = mediator;
    }
    public async Task Vote(string choice, CancellationToken cancellationToken)
    {
        var vote = await _repository.GetResultByShortcode(choice);
        if (vote != null)
        {
            vote.Votes++;
            await _repository.UpdateVote(vote);
        }
        else
        {
            vote = new VotingResult { Votes = 1, Shortcode = choice };
            await _repository.AddVote(vote);
        }
        await _mediator.Publish(new NewVoteAdded{ShortCode = choice}, cancellationToken);
        _logger.LogInformation("Voted for {choice}, which now has a total of {vote.Votes}", choice, vote.Votes);
    }

    public async Task<List<VotingResult>> Results(CancellationToken cancellationToken)
    {
        var list = await _repository.GetResults();
        return list.ToList();
    }
}