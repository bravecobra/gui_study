using AutoMapper;
using EmojiVoto.Voting.Api.Queries;
using EmojiVoto.Voting.Domain;

namespace EmojiVoto.Voting.Api
{
    public class VotingProfile : Profile
    {
        public VotingProfile()
        {
            CreateMap<VotingResult, ListVotingResultsHandler.VotingResultDto>();
        }
    }
}
