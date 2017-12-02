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

        private State _state = State.Initial;

        // 

        public MainWindowViewModel(ISettingsRepository settingsRepository)
        {
            LoadedCommand = new RelayCommand(() => Loaded = true);
            OpenSettingsCommand = new RelayCommand(() => SettingsIsOpen ^= true);
            SettingsRepository = settingsRepository;
            if (!IsInDesignMode)
                Main();
        }

        // 

        public string Word { get; set; }

        public string Words { get; set; }

        public int Index { get; set; } = -1;

        public bool SettingsIsOpen { get; set; }

        public RelayCommand LoadedCommand { get; set; }

        public ObservableCollection<string> WordsList { get; set; }
        
        public RelayCommand OpenSettingsCommand { get; set; }

        public ISettingsRepository SettingsRepository { get; set; }
        
        // 

        private async void Main()
        {
            var changed = false;
            var waited = 0;

            // Only have the possibility to change 'changed' from false to true, never true to false
            PropertyChanged += (sender, args) => changed = args.PropertyName.Equals(nameof(Words));

            while (true)
            {
                switch (_state)
                {
                    // On application launch
                    case State.Initial:
                        Words = "";
                        _state = State.Reset;
                        break;

                    // Changing from one word to the next
                    case State.Switching:
                        Index = Index + 1 >= WordsList.Count ? 0 : Index + 1;
                        Word = WordsList.Skip(Index).FirstOrDefault();
                        _state = State.Waiting;
                        break;

                    // Waiting for the duration of the delay or for a text change
                    case State.Waiting:
                        await Task.Delay(100);
                        waited += 100;

                        if (waited >= SettingsRepository.SecondsDelay * 1000 || changed)
                        {
                            _state = changed ? State.Reset : State.Switching;
                            waited = 0;
                        }

                        break;

                    // Reset the state 
                    case State.Reset:
                        Index = -1;
                        WordsList = new ObservableCollection<string>(Words.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
                        _state = State.Switching;
                        break;
                }
            }
        }
    }
}