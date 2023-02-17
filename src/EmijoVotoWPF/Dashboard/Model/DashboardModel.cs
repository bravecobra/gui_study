using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmojiVoto.EmojiSvc.Api.Queries;
using EmojiVoto.Voting.Api.Queries;
using EmojiVoto.Voting.Application.Events;
using EmojiVotoWPF.Events;
using MediatR;

namespace EmojiVotoWPF.Dashboard.Model
{
    internal class DashboardModel: IDashboardModel
    {
        private readonly ISender _mediator;
        private readonly INewVoteCollector _collector;
        private readonly List<Result> _votingResults = new();

        public DashboardModel(ISender mediator, INewVoteCollector collector)
        {
            _mediator = mediator;
            _collector = collector;
            collector.Attach(this);
        }

         ~DashboardModel()
         {
             _collector.Detach(this);
         }

        public async Task<IEnumerable<Result>> GetVotingResults()
        {
            var votingResultDtos = (await _mediator.Send(new ListVotingResultsHandler.ListVotingResultsQuery(),
                CancellationToken.None)).ToList();
            _votingResults.Clear();
            foreach (var votingResult in votingResultDtos)
            {
                var emoji = await _mediator.Send(new FindByShortCodeHandler.FindByShortcodeQuery { ShortCode = votingResult.Shortcode });
                _votingResults.Add(new Result
                {
                    Votes = votingResult.Votes,
                    Shortcode = votingResult.Shortcode,
                    Unicode = emoji.Unicode
                });
            }
            return _votingResults;
        }

        /// <summary>
        /// When a new vote has been cast, get the latest voting result again.
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Update(NewVoteAdded notification, CancellationToken cancellationToken)
        {
            await GetVotingResults();
        }
    }
}
