using EmojiVoto.Voting.Domain;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace EmojiVoto.Voting.Application.Impl;

internal class VotingService : IVotingService
{
    private readonly IVotingRepository _repository;
    private readonly ILogger<VotingService> _logger;

    public VotingService(IVotingRepository repository, ILogger<VotingService> logger)
    {
        _repository = repository;
        _logger = logger;
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
        var meter = new Meter(Assembly.GetEntryAssembly()?.GetName().Name ?? "EmojiVoting");
        var counter = meter.CreateCounter<int>("Votes");
        counter.Add(1, KeyValuePair.Create<string, object?>("name", choice));
        _logger.LogInformation("Voted for {choice}, which now has a total of {vote.Votes}", choice, vote.Votes);
    }

    public async Task<List<VotingResult>> Results(CancellationToken cancellationToken)
    {
        var list = await _repository.GetResults();
        return list.ToList();
    }
}