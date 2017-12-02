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
        public static bool Loaded { get; set; }

        public MainWindowViewModel(ISettingsRepository settingsRepository)
        {
            LoadedCommand = new RelayCommand(() => Loaded = true);
            OpenSettingsCommand = new RelayCommand(() => SettingsIsOpen ^= true);
            SettingsRepository = settingsRepository;
        }

        // 

        public string Words { get; set; }

        public bool SettingsIsOpen { get; set; }

        public RelayCommand LoadedCommand { get; set; }

        public RelayCommand OpenSettingsCommand { get; set; }

        public ISettingsRepository SettingsRepository { get; set; }
        
    }
}