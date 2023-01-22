using AutoMapper;
using EmojiVoto.EmojiSvc.Api;
using EmojiVoto.EmojiSvc.Api.Queries;
using EmojiVoto.EmojiSvc.Domain;

namespace EmojiVotoGUI.Tests.Backend.EmojiSvc.Api;

public class EmojiProfileShould
{
    [Fact]
    public void HaveAValidConfiguration()
    {
        var configuration = new MapperConfiguration(cfg =>
            cfg.AddProfile(typeof(EmojiProfile)));

        configuration.AssertConfigurationIsValid();
    }

    [Fact]
    public void MapEmojiToAnEmojiDto()
    {
        var emoji = new Emoji() { Shortcode = "something", Unicode = "unicode" };
        var configuration = new MapperConfiguration(cfg =>
            cfg.AddProfile(typeof(EmojiProfile)));
        var sut = new Mapper(configuration);
        var result = sut.Map<EmojiDto>(emoji);

        Assert.Equal("something", result.Shortcode);
        Assert.Equal("unicode", result.Unicode);
    }
}