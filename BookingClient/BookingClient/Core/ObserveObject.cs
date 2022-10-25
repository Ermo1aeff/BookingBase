using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BookingClient.Core
{
    class ObserveObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
