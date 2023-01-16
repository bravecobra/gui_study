using System.Collections.Generic;
using System.Threading.Tasks;
using EmojiVoto.Voting.Api.Queries;

namespace EmojiVotoWPF.Dashboard.Model;

internal interface IDashboardModel
{
    Task<IEnumerable<Result>> GetVotingResults();
}