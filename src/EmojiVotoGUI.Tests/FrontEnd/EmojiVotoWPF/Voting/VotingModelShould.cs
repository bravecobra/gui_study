using EmojiVoto.EmojiSvc.Api.Queries;
using EmojiVoto.Voting.Api.Commands;
using EmojiVotoWPF.Voting.Model;
using MediatR;
using Moq;

namespace EmojiVotoGUI.Tests.FrontEnd.EmojiVotoWPF.Voting;

public class VotingModelShould
{
    [Fact]
    public async Task SendOutEmojiQueryByShortCode_GivenAShortCode()
    {
        var mock = new Mock<ISender>();
        var sut = new VotingModel(mock.Object);
        var shortcode = "some_code";
        var unicode = "some_code";
        mock.Setup(mediator =>
            mediator.Send(
                It.Is<FindByShortCodeHandler.FindByShortcodeQuery>(shortcodeQuery =>
                    shortcodeQuery.ShortCode == shortcode), CancellationToken.None)).ReturnsAsync(() => new EmojiDto()
        {
            Shortcode = shortcode,
            Unicode = unicode
        });
        
        var result = await sut.FindByShortCode(shortcode);
        Assert.Equal(shortcode, result.Shortcode);
        Assert.Equal(unicode, result.Unicode);

        mock.Verify(mediator => mediator.Send(
                It.Is<FindByShortCodeHandler.FindByShortcodeQuery>(shortcodeQuery => shortcodeQuery.ShortCode == shortcode), 
                CancellationToken.None), 
            Times.Once);
    }

    [Fact]
    public async Task SendOutVote_GivenAShortCode()
    {
        var mock = new Mock<ISender>();
        var sut = new VotingModel(mock.Object);
        var shortcode = "some_code";    
        mock.Setup(mediator =>
            mediator.Send(
                It.Is<VoteEmojiHandler.VoteEmojiCommand>(shortcodeQuery =>
                    shortcodeQuery.ShortCode == shortcode), CancellationToken.None));

        await sut.Vote(shortcode);
        

        mock.Verify(mediator => mediator.Send(
                It.Is<VoteEmojiHandler.VoteEmojiCommand>(shortcodeQuery => shortcodeQuery.ShortCode == shortcode), 
                CancellationToken.None), 
            Times.Once);
    }

    [Fact]
    public async Task SendOutEmojisQuery()
    {
        var mock = new Mock<ISender>();
        var sut = new VotingModel(mock.Object);
        var emojisList = new List<EmojiDto>(){new EmojiDto(){Shortcode = "", Unicode = ""}};
        mock.Setup(mediator =>
            mediator.Send(
                It.IsAny<ListAllEmojisHandler.ListAllEmojis>(), CancellationToken.None)).ReturnsAsync(() => emojisList);

        var result = await sut.GetAllEmojis();
        Assert.Equal(1, result.Count);


        mock.Verify(mediator => mediator.Send(
                It.IsAny<ListAllEmojisHandler.ListAllEmojis>(),
                CancellationToken.None),
            Times.Once);
    }
}