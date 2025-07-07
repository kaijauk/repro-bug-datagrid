using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repro_wpffluent_datagrid
{
    public class TabViewModel : INotifyPropertyChanged
    {
        private string _title;
        private ObservableCollection<Person> _people;
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }
        public ObservableCollection<Person> People
        {
            get => _people;
            set
            {
                if (_people != value)
                {
                    _people = value;
                    OnPropertyChanged(nameof(People));
                }
            }
        }   

        public event PropertyChangedEventHandler? PropertyChanged;

        public TabViewModel(string title)
        {
            Title = title;
            People = new ObservableCollection<Person>();
            FillData();
        }

        private void FillData()
        {
            for (int i = 0; i < 500; i++)
            {
                People.Add(new Person($"Name {i}", i, $"name{i}@{Title}.com"));
            }
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public record Person(string Name, int Age, string Mail);
}
