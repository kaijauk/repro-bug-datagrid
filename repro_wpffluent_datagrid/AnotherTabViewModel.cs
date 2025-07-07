using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repro_wpffluent_datagrid
{
    public class AnotherTabViewModel : INotifyPropertyChanged
    {
        private string _title;
        private ObservableCollection<Car> _cars;
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
        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set
            {
                if (_cars != value)
                {
                    _cars = value;
                    OnPropertyChanged(nameof(Car));
                }
            }
        }   

        public event PropertyChangedEventHandler? PropertyChanged;

        public AnotherTabViewModel(string title)
        {
            Title = title;
            Cars = new ObservableCollection<Car>();
            FillData();
        }

        private void FillData()
        {
            for (int i = 0; i < 500; i++)
            {
                Cars.Add(new Car($"Future Car", i%100, 1900+(i%100), 4));
            }
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public record Car(string Brand, int HP, int Year, int Tires);
}
