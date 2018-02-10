using System.Windows;
using FontAwesome.WPF;
namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageAwesome _loader;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(UpdateResult, ShowLoader);
        }

        private void UpdateResult()
        {
            ((MainWindowViewModel)DataContext).Age = "You are " + ((MainWindowViewModel)DataContext).Age + " years of old";
            ((MainWindowViewModel)DataContext).WestHoroscope = "In the Western horoscope you are " + ((MainWindowViewModel)DataContext).WestHoroscope;
            ((MainWindowViewModel)DataContext).ChineseHoroscope = "In the Chinese horoscope you are " + ((MainWindowViewModel)DataContext).ChineseHoroscope;
        }

        public void ShowLoader(bool isShow)
        {
            LoaderHelper.OnRequestLoader(MainGrid, ref _loader, isShow);
        }
    }
}
