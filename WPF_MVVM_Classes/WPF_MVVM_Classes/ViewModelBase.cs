using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_MVVM_Classes
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public void Dispose()
        {
            OnDispose();
        }


        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


        protected virtual void OnDispose()
        {
        }
    }
}