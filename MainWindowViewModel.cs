using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
            private set { _canExecute = value; OnPropertyChanged(); }  
            
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(); } 

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


        private async void CountAgeImpl(object o)
        {
            _showLoaderAction.Invoke(true);
            CanExecute = false;
            await Task.Run((() =>
            {
                StationManager.CurrentUser = UserAdapter.CreateUser(_date); 
                Thread.Sleep(3000);
            }));
            if (StationManager.CurrentUser == null)
                MessageBox.Show($"Date of birth {_date} is  invalid.");
            
            else 
            {
                if(_date.DayOfYear == DateTime.Today.DayOfYear)
                MessageBox.Show("Happy Birthday");
                Age = "" + StationManager.CurrentUser.Age;
                WestHoroscope = StationManager.CurrentUser.WestHoroscope;
                ChineseHoroscope = StationManager.CurrentUser.ChineseHoroscope;

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
