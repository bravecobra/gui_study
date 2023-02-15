using EmojiVoto.EmojiSvc.Api.Queries;
using EmojiVoto.Voting.Application.Events;
using EmojiVotoWPF.Voting.Model;
using EmojiVotoWPF.Voting.ViewModel;
using Moq;

namespace EmojiVotoGUI.Tests.FrontEnd.EmojiVotoWPF.Voting;

public class VotingViewModelShould
{
    [Fact]
    public async Task UseTheModelToFetchEmojis()
    {
        var mock = new Mock<IVotingModel>();
        var notifierMock = new Mock<INotifier>();
        mock.Setup(model => model.GetAllEmojis()).ReturnsAsync(() => new List<EmojiDto>());
        var sut = new VotingViewModel(mock.Object, notifierMock.Object);
        await sut.GetEmojies();
        mock.Verify(model => model.GetAllEmojis(), Times.Once);
    }

    [Fact]
    public async Task HandlingANewVoteAddedEvent()
    {
        var shortCode = "some_code";
        var uniCode = "some_code";
        var voteAddedEvent = new NewVoteAdded{ ShortCode = shortCode };
        var mock = new Mock<IVotingModel>();
        var notifierMock = new Mock<INotifier>();
        mock.Setup(model => model.FindByShortCode(It.Is<string>(s => s==shortCode))).ReturnsAsync(() => new EmojiDto(){Shortcode = shortCode, Unicode = uniCode});
        var sut = new VotingViewModel(mock.Object, notifierMock.Object);
        await sut.Handle(voteAddedEvent, CancellationToken.None);
        mock.Verify(model => model.FindByShortCode(It.Is<string>(s => s==shortCode)), Times.Once);
        notifierMock.Verify(model => model.ShowSuccess(It.Is<string>(s => s.Contains(shortCode))), Times.Once);
    }

    [Fact]
    public async Task UseTheModelToVote()
    {
        var shortCode = "some_code";
        var mock = new Mock<IVotingModel>();
        var notifierMock = new Mock<INotifier>();
        mock.Setup(model => model.Vote(It.Is<string>(s => s==shortCode)));
        var sut = new VotingViewModel(mock.Object, notifierMock.Object);
        await sut.Vote(shortCode);
        mock.Verify(model => model.Vote(It.Is<string>(s => s==shortCode)), Times.Once);
    }

    [Fact]
    public void ShouldHaveTheTitleVoting()
    {
        var mock = new Mock<IVotingModel>();
        var notifierMock = new Mock<INotifier>();
        var sut = new VotingViewModel(mock.Object, notifierMock.Object);
        Assert.Equal("Voting", sut.Title);
    }
}