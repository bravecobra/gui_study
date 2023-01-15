using EmojiVoto.Voting.Application;
using EmojiVoto.Voting.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmojiVoto.Voting.Persistence.Impl;

public class VotingRepository: IVotingRepository
{
    private readonly VotingDbContext _dbContext;

    public VotingRepository(VotingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<VotingResult?> GetResultByShortcode(string shortcode)
    {
        return await _dbContext.VotingResults.Where(result => result.Shortcode == shortcode).FirstOrDefaultAsync();
    }

    public async Task<bool> AddVote(VotingResult result)
    {
        await _dbContext.AddAsync(result);
        return await _dbContext.SaveChangesAsync() != 0;
    }

    public async Task<bool> UpdateVote(VotingResult result)
    {
        return await _dbContext.SaveChangesAsync() != 0;
    }

    public async Task<IEnumerable<VotingResult>> GetResults()
    {
        return (await _dbContext.VotingResults.AsNoTracking().ToListAsync(CancellationToken.None)).OrderByDescending(result => result.Votes).AsEnumerable();
    }
}