using EmojiVoto.EmojiSvc.Api.Queries;
using EmojiVoto.Voting.Application.Events;
using EmojiVotoWPF.Voting.Model;
using EmojiVotoWPF.Voting.ViewModel;
using Moq;
using Notifications.Wpf.Core;

namespace EmojiVotoWPF.Tests.FrontEnd.EmojiVotoWPF.Voting;

public class VotingViewModelShould
{
    [Fact]
    public async Task UseTheModelToFetchEmojis()
    {
        var mock = new Mock<IVotingModel>();
        var notifierMock = new Mock<INotificationManager>();
        mock.Setup(model => model.GetAllEmojis()).ReturnsAsync(() => new List<EmojiDto>());
        var sut = new VotingViewModel(mock.Object, notifierMock.Object);
        await sut.GetEmojies();
        mock.Verify(model => model.GetAllEmojis(), Times.Once);
    }

    [Fact]
    public async Task CallNotificationManager_WhenModelEventIsTriggered()
    {
        var shortCode = "some_code";
        var uniCode = "some_code";
        var mock = new Mock<IVotingModel>();
        mock.Setup(model => model.Update(It.IsAny<NewVoteAdded>(), It.IsAny<CancellationToken>()));
        var notifierMock = new Mock<INotificationManager>();
        mock.Setup(model => model.FindByShortCode(It.Is<string>(s => s==shortCode))).ReturnsAsync(() => new EmojiDto(){Shortcode = shortCode, Unicode = uniCode});
        var sut = new VotingViewModel(mock.Object, notifierMock.Object);
        //act
        mock.Raise(foo => foo.EmojiVoted += null, new EmojiVotedEventArgs(){ShortCode = shortCode, UniCode = uniCode});
        //assert
        notifierMock.Verify(model => model.ShowAsync(
            It.Is<NotificationContent>(content => content.Message!.Contains(uniCode)), null,null, null, null, It.IsAny<CancellationToken>()
            ), Times.Once);
    }

    [Fact]
    public async Task UseTheModelToVote()
    {
        var shortCode = "some_code";
        var mock = new Mock<IVotingModel>();
        var notifierMock = new Mock<INotificationManager>();
        mock.Setup(model => model.Vote(It.Is<string>(s => s==shortCode)));
        var sut = new VotingViewModel(mock.Object, notifierMock.Object);
        await sut.Vote(shortCode);
        mock.Verify(model => model.Vote(It.Is<string>(s => s==shortCode)), Times.Once);
    }

    [Fact]
    public void ShouldHaveTheTitleVoting()
    {
        var mock = new Mock<IVotingModel>();
        var notifierMock = new Mock<INotificationManager>();
        var sut = new VotingViewModel(mock.Object, notifierMock.Object);
        Assert.Equal("Voting", sut.Title);
    }
}