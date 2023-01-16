using AutoMapper;
using EmojiVoto.Voting.Application;
using MediatR;

namespace EmojiVoto.Voting.Api.Queries
{
    public class ListVotingResultsHandler: IRequestHandler<ListVotingResultsHandler.ListVotingResultsQuery, IEnumerable<ListVotingResultsHandler.VotingResultDto>>
    {
        private readonly IVotingService _votingservice;
        private readonly IMapper _mapper;
        public ListVotingResultsHandler(IVotingService votingservice, IMapper mapper)
        {
            _votingservice = votingservice;
            _mapper = mapper;
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class VotingResultDto
        {
            public string Shortcode { get; set; } = null!;
            public int Votes { get; set; }
        }

        // ReSharper disable once ClassNeverInstantiated.Global
        public class ListVotingResultsQuery: IRequest<IEnumerable<VotingResultDto>>
        {
        }

        public async  Task<IEnumerable<VotingResultDto>> Handle(ListVotingResultsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<VotingResultDto>>(await _votingservice.Results(cancellationToken));
        }
    }
}
