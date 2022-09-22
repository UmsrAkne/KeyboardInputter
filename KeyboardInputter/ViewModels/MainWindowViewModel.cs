using System;
using System.Timers;
using KeyboardInputter.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace KeyboardInputter.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private KeySender keySender = new KeySender();
        private string title = "Prism Application";

        public MainWindowViewModel()
        {
            var timer = new Timer();
            timer.Interval = TimeSpan.FromMilliseconds(4500).TotalMilliseconds;
            timer.Start();

            timer.Elapsed += (_, _) =>
            {
                System.Diagnostics.Debug.WriteLine($"MainWindowViewModel : inputKey");
                keySender.SendKey((int)Keys.A, (int)Keys.LControlKey);
            };
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public DelegateCommand KeyCommand => new DelegateCommand(() =>
        {
        });
    }
}