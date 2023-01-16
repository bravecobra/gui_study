using System.Threading.Tasks;

namespace EmojiVotoWPF.Dashboard.ViewModel;

public interface IDashboardViewModel: IMenuItem
{
    Task GetResults();
}