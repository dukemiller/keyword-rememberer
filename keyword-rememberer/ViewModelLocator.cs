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

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Viewmodels
            SimpleIoc.Default.Register<MainWindowViewModel>();
        }

        public MainWindowViewModel Main => SimpleIoc.Default.GetInstance<MainWindowViewModel>();
    }
}