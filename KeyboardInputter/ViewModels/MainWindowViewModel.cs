using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using KeyboardInputter.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace KeyboardInputter.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly KeySender keySender = new KeySender();
        private string title = "Prism Application";
        private ObservableCollection<string> operationNames;

        public MainWindowViewModel()
        {
            var timer = new Timer();
            timer.Interval = TimeSpan.FromMilliseconds(4500).TotalMilliseconds;
            timer.Start();

            timer.Elapsed += (_, _) => { System.Diagnostics.Debug.WriteLine($"MainWindowViewModel : inputKey"); };

            OperationNames = new ObservableCollection<string>(GenerateOperationNames());
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public ObservableCollection<string> OperationNames
        {
            get => operationNames;
            set => SetProperty(ref operationNames, value);
        }

        public DelegateCommand KeyCommand => new DelegateCommand(() => { });

        private List<string> GenerateOperationNames()
        {
            // 1文字キーとそれ以外で分割しないと、命令リストがきれいに並ばない。
            var names = Enum.GetNames<Keys>();
            var oneChars = names.Where(s => s.Length == 1).OrderBy(s => s).ToList();
            var other = names.Where(s => s.Length > 1).OrderBy(s => s).ToList();

            return oneChars.Concat(other).ToList();
        }
    }
}