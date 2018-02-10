using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Lab1
{
    class MainWindowViewModel : INotifyPropertyChanged 
    {
        private DateTime _date;
        private string _age;
        private string _westHoroscope;
        private string _chineseHoroscope;
        private bool _canExecute;
        private RelayCommand _countAge;
        private RelayCommand _setWestHoroscope;
        private RelayCommand _setChineseHoroscope;
        private Action<bool> _showLoaderAction;
        private readonly Action _closeAction; 

        public MainWindowViewModel(Action close, Action<bool> showLoader)
        {
            _closeAction = close;
            _showLoaderAction = showLoader;
            CanExecute = true;
        }

        public bool CanExecute
        {
            get { return _canExecute; }
            private set { _canExecute = value; OnPropertyChanged(); } //повідомляє що була змінена властивість 
            
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(); } //повідомляє що була змінена властивість 

        }
        public string Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged(); }
        }
        public RelayCommand CountAge
        {
            get
            {
                return _countAge ?? (_countAge = new RelayCommand(CountAgeImpl));
            }
        }
        public string WestHoroscope 
        {
            get { return _westHoroscope; }
            set { _westHoroscope = value; OnPropertyChanged(); }
        }

        public string ChineseHoroscope
        {
            get { return _chineseHoroscope; }
            set { _chineseHoroscope = value; OnPropertyChanged(); }
        }

        public RelayCommand SetWestHoroscope
        {
            get
            {
                return _setWestHoroscope ?? (_setWestHoroscope = new RelayCommand(WestHoroscopeImpl));
            }
        }

        public RelayCommand SetChineseHoroscope
        {
            get
            {
                return _setChineseHoroscope ?? (_setChineseHoroscope = new RelayCommand(ChineseHoroscopeImpl));
            }
        }

        private async void CountAgeImpl(object o)
        {
            _showLoaderAction.Invoke(true);
         
            //   Age = "";
            CanExecute = false;
            await Task.Run((() =>
            {
                StationManager.CurrentUser = UserAdapter.CreateUser(_date); //
                Thread.Sleep(3000);
            }));
            if (StationManager.CurrentUser == null)
                MessageBox.Show($"Date of birth {_date} is  invalid.");
            
            else 
            {
                if(_date.DayOfYear == DateTime.Today.DayOfYear)
                MessageBox.Show("HappyBirthday");
                Age = "" + StationManager.CurrentUser.Age;

                _closeAction.Invoke();
            }
            CanExecute = true;
            _showLoaderAction.Invoke(false);
        }

        private async void WestHoroscopeImpl(object o)
        {
            _showLoaderAction.Invoke(true);
           // WestHoroscope = WestHoroscope;
            CanExecute = false;
            await Task.Run((() =>
            {
                StationManager.CurrentUser = UserAdapter.CreateUser(_date); //
                Thread.Sleep(3000);
            }));
            if (StationManager.CurrentUser == null)
                MessageBox.Show($"Date of birth {_date} is  invalid.");

            else
            {
                if (_date.DayOfYear == DateTime.Today.DayOfYear)
                    MessageBox.Show("HappyBirthday");
                Age = "" + StationManager.CurrentUser.Age;

                _closeAction.Invoke();
            }
            CanExecute = true;
            _showLoaderAction.Invoke(false);
        }

        private async void ChineseHoroscopeImpl(object o)
        {
            _showLoaderAction.Invoke(true);
            CanExecute = false;
            await Task.Run((() =>
            {
                StationManager.CurrentUser = UserAdapter.CreateUser(_date); //
                Thread.Sleep(3000);
            }));
            if (StationManager.CurrentUser == null)
                MessageBox.Show($"Date of birth {_date} is  invalid.");

            else
            {
                if (_date.DayOfYear == DateTime.Today.DayOfYear)
                    MessageBox.Show("HappyBirthday");
                Age = "" + StationManager.CurrentUser.Age;

                _closeAction.Invoke();
            }
            CanExecute = true;
            _showLoaderAction.Invoke(false);
        }
        #region Implementation
        public event PropertyChangedEventHandler PropertyChanged;

    
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
