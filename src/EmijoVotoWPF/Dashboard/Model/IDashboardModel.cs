using System.Collections.Generic;
using System.Threading.Tasks;
using EmojiVotoWPF.Events;

namespace EmojiVotoWPF.Dashboard.Model;

public interface IDashboardModel: INewVoteObserver
{
    Task<IEnumerable<Result>> GetVotingResults();
}