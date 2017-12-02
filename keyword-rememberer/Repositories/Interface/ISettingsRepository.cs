using System.ComponentModel;

namespace keyword_rememberer.Repositories.Interface
{
    public interface ISettingsRepository: INotifyPropertyChanged
    {
        bool IncludeNumber { get; set; }

        int SecondsDelay { get; set; }
    }
}