using MediatR;

namespace EmojiVoto.Voting.Application.Events;

public class NewVoteAdded : INotification
{
    public string ShortCode { get; set; } = null!;
}