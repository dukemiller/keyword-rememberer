using System;
using System.IO;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using keyword_rememberer.Repositories.Interface;
using keyword_rememberer.ViewModels;
using Newtonsoft.Json;

namespace keyword_rememberer.Repositories
{
    [Serializable]
    public class SettingsRepository: ObservableObject, ISettingsRepository
    {
        [JsonIgnore]
        private static readonly string SavePath = Path.Combine(ViewModelLocator.ApplicationPath, "settings.json");

        [JsonIgnore]
        private DateTime LastSaved { get; set; } = DateTime.MinValue;

        // 

        public SettingsRepository()
        {
            PropertyChanged += async (sender, args) =>
            {
                if (MainWindowViewModel.Loaded && (DateTime.Now - LastSaved).TotalSeconds > 2)
                {
                    await Save();
                    LastSaved = DateTime.Now;
                }
            };
        }

        // 

        [JsonProperty("include_number")]
        public bool IncludeNumber { get; set; }

        [JsonProperty("seconds_delay")]
        public int SecondsDelay { get; set; } = 5;

        // 

        private async Task Save()
        {
            using (var stream = new StreamWriter(SavePath))
                await stream.WriteAsync(JsonConvert.SerializeObject(this, Formatting.Indented));
        }

        public static SettingsRepository Load()
        {
            if (!Directory.Exists(ViewModelLocator.ApplicationPath))
                Directory.CreateDirectory(ViewModelLocator.ApplicationPath);

            if (File.Exists(SavePath))
                using (var stream = new StreamReader(SavePath))
                    return JsonConvert.DeserializeObject<SettingsRepository>(stream.ReadToEnd());

            return new SettingsRepository();
        }
    }
}