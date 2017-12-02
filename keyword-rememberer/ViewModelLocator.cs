using System;
using System.IO;
using GalaSoft.MvvmLight.Ioc;
using keyword_rememberer.Repositories;
using keyword_rememberer.Repositories.Interface;
using keyword_rememberer.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace keyword_rememberer
{
    public class ViewModelLocator
    {
        public static string ApplicationPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "keyword_rememberer");

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Create directories
            if (!Directory.Exists(ApplicationPath))
                Directory.CreateDirectory(ApplicationPath);

            // Repositories
            SimpleIoc.Default.Register<ISettingsRepository>(SettingsRepository.Load);

            // Viewmodels
            SimpleIoc.Default.Register<MainWindowViewModel>();
        }

        public MainWindowViewModel Main => SimpleIoc.Default.GetInstance<MainWindowViewModel>();
    }
}