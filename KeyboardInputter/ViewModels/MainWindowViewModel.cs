using KeyboardInputter.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Timers;

namespace KeyboardInputter.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private KeySender keySender = new KeySender();
        private string title = "Prism Application";

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public MainWindowViewModel()
        {
            var timer = new Timer();
            timer.Interval = TimeSpan.FromMilliseconds(4500).TotalMilliseconds;
            timer.Start();

            timer.Elapsed += (_, _) =>
            {
                System.Diagnostics.Debug.WriteLine($"MainWindowViewModel : inputKey");
            };
        }

        public DelegateCommand KeyCommand => new DelegateCommand(() =>
        {
        });
    }
}