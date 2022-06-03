using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WPF_MVVM_Classes
{
    public abstract class ViewModelBase : DependencyObject, INotifyPropertyChanged, IDisposable
    {
        public void Dispose()
        {
            OnDispose();
        }


        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        protected virtual void OnDispose()
        {
        }

        public static Dictionary<ViewModelBase, IChildWindow> ChildWindows = new Dictionary<ViewModelBase, IChildWindow>();

        public void RegisterWindow<T>(T view, ViewModelBase viewModel, string title) where T : Window
        {
            var childWindow = new ChildWindow<T>(view, viewModel, title);
            ChildWindows.Add(viewModel, childWindow);
        }
    }

    public interface IChildWindow
    {
        bool Close();
        void Show();
    }
    public sealed class ChildWindow<T> : IChildWindow where T : Window
    {
        private T _view;
        private readonly ViewModelBase _viewModel;

        public ChildWindow(T view, ViewModelBase viewModel, string title)
        {
            _view = view;
            _viewModel = viewModel;

            _view.DataContext = _viewModel;
            _view.Title = title;
        }

        private void Closed()
        {

        }

        public bool Close()
        {
            var result = false;
            if (_view != null)
            {
                _view.Close();
                _view = null;
                ViewModelBase.ChildWindows.Remove(_viewModel);
                result = true;
            }
            return result;
        }

        public void Show()
        {
            _view.Closed += (sender, e) => Closed();
            _view.Show();
        }
    }
}
