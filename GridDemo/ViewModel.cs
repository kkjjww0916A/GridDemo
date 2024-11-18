using System.Collections.ObjectModel;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace GridDemo
{
    public class CellData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private Person? _originalData;

        private string _name = "";
        private int _age;
        private bool _isNameModified = false;
        private bool _isAgeModified = false;

        public CellData(Person person)
        {
            _name = person.Name;
            _age = person.Age;

            _originalData = new Person { Name = person.Name, Age = person.Age };
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
                IsNameModified = _originalData != null && _name != _originalData.Name;
            }
        }
        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged();
                IsAgeModified = _originalData != null && _age != _originalData.Age;
            }
        }
        public bool IsNameModified
        {
            get => _isNameModified;
            set
            {
                _isNameModified = value;
                OnPropertyChanged();
            }
        }
        public bool IsAgeModified
        {
            get => _isAgeModified;
            set
            {
                _isAgeModified = value;
                OnPropertyChanged();
            }
        }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CellData> _cellData;
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<CellData> CellData
        {
            get => _cellData;
            set
            {
                _cellData = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            _cellData = new ObservableCollection<CellData>();
            _cellData.Add(new CellData (new Person { Name = "Jone", Age = 20}));
            _cellData.Add(new CellData(new Person { Name = "Doe", Age = 30 }));

        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
