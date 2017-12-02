using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using keyword_rememberer.Enums;
using keyword_rememberer.Repositories.Interface;

namespace keyword_rememberer.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel(ISettingsRepository settingsRepository) {}

    }
}