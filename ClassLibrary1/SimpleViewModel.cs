using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace App2
{
    public class SimpleViewModel : INotifyPropertyChanged
    {
        public SimpleViewModel()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), ()  =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    MainText = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                });

                return true;
            });
        }

        private string _mainText;

        public string MainText
        {
            get { return _mainText; }
            set
            {
                _mainText = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}