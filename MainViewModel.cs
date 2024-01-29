using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TinyClock
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string time;
        public string Time { get => time; set { time = value; OnPropertyChanged(); } }

        private void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        private void Refresh()
        {
            Time = DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss");
        }

        public MainViewModel()
        {
            Refresh();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += (s, e) => Refresh();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }
    }
}
