using System.Diagnostics.CodeAnalysis;
using ToastNotifications;
using ToastNotifications.Messages;

namespace EmojiVotoWPF.Voting.ViewModel;

[ExcludeFromCodeCoverage]
internal class NotifierWrapper: INotifier
{
    private readonly Notifier _notifier;

    public NotifierWrapper(Notifier notifier)
    {
        _notifier = notifier;
    }

    public void ShowSuccess(string message)
    {
        _notifier.ShowSuccess(message);
    }
}