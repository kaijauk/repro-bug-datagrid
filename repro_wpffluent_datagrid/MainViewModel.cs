using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repro_wpffluent_datagrid
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<object> _tabs;

        public MainViewModel()
        {
            Tabs = new ObservableCollection<object>
            {
                new TabViewModel("tab1"),
                new AnotherTabViewModel("tab2"),
            };
        }

        public ObservableCollection<object> Tabs
        {
            get { return _tabs; }
            set
            {
                if (_tabs != value)
                {
                    _tabs = value;
                    OnPropertyChanged(nameof(Tabs));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
