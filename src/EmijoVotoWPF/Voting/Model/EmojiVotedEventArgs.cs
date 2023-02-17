using System;

namespace EmojiVotoWPF.Voting.Model;

public class EmojiVotedEventArgs: EventArgs
{
    public string ShortCode { get; set; }
    public string UniCode { get; set; }
}